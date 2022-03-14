using _02_Authentication_Custom.Identity_Roles_Policies_Claims.Data;
using _02_Authentication_Custom.Identity_Roles_Policies_Claims.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaims>();
builder.Services.AddScoped<IAddressManager, AddressManager>();
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("AzureSql")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(x =>
{
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/auth/signin";
    x.AccessDeniedPath = "/auth/accessdenied";
});
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("Admins", x => x.RequireRole("admin"));
    x.AddPolicy("Users", x => x.RequireRole("admin", "user"));
});







var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();    // Vem är du?                       inloggning
app.UseAuthorization();     // Vad har du behörighet till?      roller, nycklar/apikeys

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
