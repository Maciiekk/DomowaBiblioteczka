using DomowaBiblioteczka.Components;
using DomowaBiblioteczka.Components.Account;
using DomowaBiblioteczka.Data;
using DomowaBiblioteczka.Data.Seeder;
using DomowaBiblioteczka.Services.Roles;
using DomowaBiblioteczka.Services.Users;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<UserManager<ApplicationUser>>();



// Data Services
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IRolesService, RolesService>();

builder.Services.AddRadzenComponents();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

var mediaconnectionString = builder.Configuration.GetConnectionString("MediaConnection") ?? throw new InvalidOperationException("Connection string 'MediaConnection' not found.");

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddDbContextFactory<MediaDbContext>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => 
{ 
    options.SignIn.RequireConfirmedAccount = false; 
    options.User.RequireUniqueEmail = true;
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
})
    .AddSignInManager()
    .AddRoles<IdentityRole>()
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddRoleStore<RoleStore<IdentityRole, ApplicationDbContext>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        
        await IdentitySeeder.Seed(roleManager, userManager);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred seeding the database with Roles: {ex.Message}");
    }
}


using (var scope = app.Services.CreateScope())
{
    try
    {
        var context = scope.ServiceProvider.GetRequiredService<MediaDbContext>();
        await MediaContextSeeder.Seed(context,true);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred seeding the database with Media: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
