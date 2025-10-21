using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using IspManagementERP.Shared.Identity;

namespace IspManagementERP.Client.Services.Identity
{
    public class UserService
    {
        private readonly HttpClient _http;
        public UserService(HttpClient http) { _http = http; }

        // LIST PAGINADO
        public async Task<(IEnumerable<UserWithRolesClaimsDto> items, int total)> GetUsersPagedAsync(int page = 1, int pageSize = 20, string? q = null)
        {
            var url = $"api/admin/identity/users?page={page}&pageSize={pageSize}";
            if (!string.IsNullOrWhiteSpace(q)) url += $"&q={System.Uri.EscapeDataString(q)}";
            var resp = await _http.GetFromJsonAsync<PagedResponse<UserWithRolesClaimsDto>>(url);
            return (resp?.items ?? new List<UserWithRolesClaimsDto>(), resp?.total ?? 0);
        }

        // SINGLE USER
        public async Task<UserDto?> GetUserAsync(string id) => await _http.GetFromJsonAsync<UserDto>($"api/admin/identity/users/{id}");

        // CRUD usuarios
        public async Task<HttpResponseMessage> CreateUserAsync(CreateUserModel model) => await _http.PostAsJsonAsync("api/admin/identity/users", model);
        public async Task<HttpResponseMessage> UpdateUserAsync(string id, UpdateUserModel model) => await _http.PutAsJsonAsync($"api/admin/identity/users/{id}", model);
        public async Task<HttpResponseMessage> DeleteUserAsync(string id) => await _http.DeleteAsync($"api/admin/identity/users/{id}");

        // ROLES (listar global)
        public async Task<IEnumerable<string>> GetRolesAsync() => await _http.GetFromJsonAsync<IEnumerable<string>>("api/admin/identity/roles") ?? new List<string>();

        // CREATE / DELETE role
        public async Task<HttpResponseMessage> CreateRoleAsync(string role) => await _http.PostAsJsonAsync("api/admin/identity/roles", role);
        public async Task<HttpResponseMessage> DeleteRoleAsync(string role) => await _http.DeleteAsync($"api/admin/identity/roles/{System.Uri.EscapeDataString(role)}");

        // USER ROLES (usado por RoleAssignModal)
        public async Task<IEnumerable<string>> GetUserRolesAsync(string userId) => await _http.GetFromJsonAsync<IEnumerable<string>>($"api/admin/identity/users/{userId}/roles") ?? new List<string>();

        public async Task<HttpResponseMessage> AddUserRoleAsync(string userId, string role)
            => await _http.PostAsJsonAsync($"api/admin/identity/users/{userId}/roles", new { Role = role });

        public async Task<HttpResponseMessage> RemoveUserRoleAsync(string userId, string role)
            => await _http.DeleteAsync($"api/admin/identity/users/{userId}/roles/{System.Uri.EscapeDataString(role)}");

        // CLAIMS (user)

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAvailableClaimsAsync()
        {
            var resp = await _http.GetAsync("api/admin/identity/claims");
            var body = await resp.Content.ReadAsStringAsync();
            if (!resp.IsSuccessStatusCode)
                throw new Exception($"GetAvailableClaims failed {resp.StatusCode}: {body}");

            try
            {
                using var doc = System.Text.Json.JsonDocument.Parse(body);
                var list = new List<KeyValuePair<string, string>>();
                if (doc.RootElement.ValueKind == System.Text.Json.JsonValueKind.Array)
                {
                    foreach (var el in doc.RootElement.EnumerateArray())
                    {
                        string? t = null;
                        string? v = null;
                        if (el.TryGetProperty("Type", out var p1) || el.TryGetProperty("type", out p1)) t = p1.GetString();
                        if (el.TryGetProperty("Value", out var p2) || el.TryGetProperty("value", out p2)) v = p2.GetString();
                        if (!string.IsNullOrEmpty(t) && !string.IsNullOrEmpty(v))
                            list.Add(new KeyValuePair<string, string>(t!, v!));
                    }
                }
                return list;
            }
            catch (System.Text.Json.JsonException)
            {
                throw new Exception($"GetAvailableClaims invalid JSON: {body}");
            }
        }
        // --- Claims (cliente) ---
        public async Task<IEnumerable<KeyValuePair<string, string>>> GetUserClaimsAsync(string userId)
        {
            var url = $"api/admin/identity/users/{userId}/claims";
            var resp = await _http.GetAsync(url);
            var body = await resp.Content.ReadAsStringAsync();

            if (!resp.IsSuccessStatusCode)
                throw new Exception($"GetUserClaims failed {resp.StatusCode}: {body}");

            try
            {
                // Esperamos: [{ "type":"...", "value":"..." }, ...] o similar. Intentamos parsear flexible.
                using var doc = System.Text.Json.JsonDocument.Parse(body);
                var list = new List<KeyValuePair<string, string>>();
                if (doc.RootElement.ValueKind == System.Text.Json.JsonValueKind.Array)
                {
                    foreach (var el in doc.RootElement.EnumerateArray())
                    {
                        if (el.ValueKind == System.Text.Json.JsonValueKind.Object)
                        {
                            string? t = null;
                            string? v = null;
                            if (el.TryGetProperty("Type", out var p1) || el.TryGetProperty("type", out p1)) t = p1.GetString();
                            if (el.TryGetProperty("Value", out var p2) || el.TryGetProperty("value", out p2)) v = p2.GetString();

                            // Algunas implementaciones devuelven { "type": "...", "value": "..." }
                            if (t != null && v != null) list.Add(new KeyValuePair<string, string>(t, v));
                            // Otros pueden devolver KeyValuePair<string,string> directo (como JSON object), omitimos si no mapea
                        }
                    }
                }
                return list;
            }
            catch (System.Text.Json.JsonException)
            {
                throw new Exception($"GetUserClaims invalid JSON: {body}");
            }
        }

        public async Task<IEnumerable<ClaimDefinitionDTO>> GetClaimDefinitionsAsync()
        {
            var resp = await _http.GetAsync("api/admin/identity/claimdefinitions");
            var body = await resp.Content.ReadAsStringAsync();
            if (!resp.IsSuccessStatusCode)
                throw new Exception($"GetClaimDefinitions failed {resp.StatusCode}: {body}");
            return await resp.Content.ReadFromJsonAsync<IEnumerable<ClaimDefinitionDTO>>() ?? Enumerable.Empty<ClaimDefinitionDTO>();
        }

        public async Task<HttpResponseMessage> CreateClaimDefinitionAsync(ClaimDefinitionDTO dto)
            => await _http.PostAsJsonAsync("api/admin/identity/claimdefinitions", dto);

        public async Task<HttpResponseMessage> DeleteClaimDefinitionAsync(int id)
            => await _http.DeleteAsync($"api/admin/identity/claimdefinitions/{id}");

        public async Task<HttpResponseMessage> AddUserClaimAsync(string userId, KeyValuePair<string, string> claim) => await _http.PostAsJsonAsync($"api/admin/identity/users/{userId}/claims", claim);

        public async Task<HttpResponseMessage> RemoveUserClaimAsync(string userId, string type, string value) => await _http.DeleteAsync($"api/admin/identity/users/{userId}/claims?type={System.Uri.EscapeDataString(type)}&value={System.Uri.EscapeDataString(value)}");

        private class PagedResponse<T> { public int page { get; set; } public int pageSize { get; set; } public int total { get; set; } public List<T>? items { get; set; } }
    }
}