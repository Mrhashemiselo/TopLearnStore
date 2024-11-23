using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Parbad.Builder;
using Parbad.Gateway.Mellat;
using Parbad.Gateway.Melli;
using Parbad.Gateway.ParbadVirtual;
using Parbad.Gateway.ZarinPal;
using TopLearn.Core.Convertors;
using TopLearn.Core.Services.Implement;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

builder.Services.AddParbad()
    .ConfigureGateways(gateways =>
    {
        gateways
       .AddZarinPal()
       .WithAccounts(accounts =>
       {
           accounts.AddInMemory(account =>
           {
               account.MerchantId = "e739ea87-0e82-4a64-93b9-2a9443f3b6e2";
               account.IsSandbox = true;
           });
       });

        gateways
       .AddParbadVirtual()
       .WithOptions(options => options.GatewayPath = "/MyVirtualGateway");
    })
   .ConfigureHttpContext(httpContextBuilder => httpContextBuilder.UseDefaultAspNetCore())
   .ConfigureStorage(storageBuilder => storageBuilder.UseMemoryCache());

#region AddAuthentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(opt =>
{
    opt.LoginPath = "/login";
    opt.LogoutPath = "/logout";
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(6000);
});
#endregion

#region DataBaseContext
builder.Services.AddDbContext<TopLearnContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("TopLearnSql")));
#endregion

#region IoC
builder.Services.AddScoped<IUserServices, UserService>();
builder.Services.AddScoped<IWalletServices, WalletServices>();
builder.Services.AddScoped<IUserPanelServices, UserPanelServices>();
builder.Services.AddScoped<IViewRenderService, RenderViewToString>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IAdminPanel, AdminPanel>();
#endregion

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
   name: "areas",
   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseParbadVirtualGateway();

app.Run();
