using FluentValidation.AspNetCore;
using Qurbanet.Extensions;
using Qurbanet.Validators.User;

var builder = WebApplication.CreateBuilder(args);

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
