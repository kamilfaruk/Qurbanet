using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Qurbanet.Extensions;
using Qurbanet.Validators.User;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => { options.LoginPath = "/Account/Login"; options.LogoutPath = "/Account/Logout"; });
app.UseAuthentication();
// Serilog yapýlandýrmasý
builder.AddSerilogLogging();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Middlewares
app.UseCustomMiddlewares();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
