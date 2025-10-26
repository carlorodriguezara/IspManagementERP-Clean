using IspManagementERP.Server.Data;
using IspManagementERP.Server.Models;
using IspManagementERP.Server.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using Duende.IdentityServer.Services;
using IspManagementERP.Repositories.Identity;
using System.Data;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanManageUsers", policy =>
        policy.RequireAssertion(ctx =>
            ctx.User.IsInRole("Admin") ||
            ctx.User.HasClaim(c => c.Type == "permission" && c.Value == "users.manage")));

    options.AddPolicy("CanCreateInvoices", policy =>
        policy.RequireAssertion(ctx =>
            ctx.User.IsInRole("Admin") ||
            ctx.User.HasClaim(c => c.Type == "permission" && c.Value == "invoices.create")));

    options.AddPolicy("CanViewReports", policy =>
        policy.RequireAssertion(ctx =>
            ctx.User.IsInRole("Admin") ||
            ctx.User.IsInRole("Manager") ||
            ctx.User.HasClaim(c => c.Type == "permission" && c.Value == "reports.view")));
});

// Registrar IDbConnection para que cada inyección obtenga una nueva SqlConnection
builder.Services.AddTransient<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// Añade en Program.cs (Server)
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IspManagementERP.Server.Data.ITenantProvider, IspManagementERP.Server.Data.TenantProvider>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Seed identity data kept registered but NOT executed automatically
builder.Services.AddScoped<IdentityDataSeeder>();

// Registrar ProfileService (si lo usas)
builder.Services.AddScoped<Duende.IdentityServer.Services.IProfileService, IspManagementERP.Server.Service.ProfileService>();

// Añade en Program.cs (Server)
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IspManagementERP.Server.Data.ITenantProvider, IspManagementERP.Server.Data.TenantProvider>();


// Registrar repo
builder.Services.AddScoped<IIdentityAdminRepository, IdentityAdminRepository>();

// en la configuración de servicios
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClientWithCredentials", policy =>
    {
        policy.WithOrigins("https://localhost:7234", "https://localhost:5001") // -> pon aquí el origen del client EXACTO
              .AllowCredentials()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Asegúrate de que AddIdentity / UserManager / RoleManager ya están registrados (AddIdentity<ApplicationUser, IdentityRole>() ...)

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

// IMPORTANT: order matters
app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.UseCors("AllowClientWithCredentials");
app.MapFallbackToFile("index.html");

// Apply pending migrations at startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

// NOTE: Dev seeding removed from automatic startup. Run IdentityDataSeeder manually if needed.

app.Run();