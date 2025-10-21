using IspManagementERP.Client;
using IspManagementERP.Client.Services.Identity;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Http; // necesario para FetchCredentialsOption
using System.Net.Http;
using MudBlazor.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("IspManagementERP.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("IspManagementERP.ServerAPI"));

builder.Services.AddApiAuthorization();

// register auth state provider etc. (ya debería estar en template)
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("CanManageUsers", policy =>
        policy.RequireAssertion(ctx =>
            ctx.User.IsInRole("Admin") ||
            ctx.User.HasClaim(c => c.Type == "permission" && c.Value == "users.manage")));

    options.AddPolicy("CanCreateInvoices", policy =>
        policy.RequireAssertion(ctx =>
            ctx.User.IsInRole("Admin") ||
            ctx.User.HasClaim(c => c.Type == "permission" && c.Value == "invoices.create")));

    // En cliente conviene priorizar claims (role puede variar en el JWT)
    options.AddPolicy("CanViewReports", policy =>
        policy.RequireAssertion(ctx =>
            ctx.User.IsInRole("Admin") ||
            ctx.User.IsInRole("Manager") ||
            ctx.User.HasClaim(c => c.Type == "permission" && c.Value == "reports.view")));
});



// Añadir en Client/Program.cs, junto a builder.Services...
builder.Services.AddSingleton<IspManagementERP.Client.Services.ToastService>();
// Después de haber registrado/factory del HttpClient de la plantilla
builder.Services.AddScoped<UserService>(sp =>
{
    var client = sp.GetRequiredService<IHttpClientFactory>().CreateClient("IspManagementERP.ServerAPI");
    return new UserService(client);
});

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = MudBlazor.MudBlazorDefaults.SnackbarPosition.BottomRight;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 3500;
});

await builder.Build().RunAsync();
