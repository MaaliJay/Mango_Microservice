using Mango.Web.Service;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Authorization.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Http Client Factory
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

//Inject Http Client Interfaces
builder.Services.AddHttpClient<ICuponService, CuponService>();
builder.Services.AddHttpClient<IAuthService, AuthService>();

builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<ICuponService, CuponService>();
builder.Services.AddScoped<IAuthService, AuthService>();

//Add  Base service
StaticDetails.CuponAPIBase = builder.Configuration["ServiceUrls:CuponAPI"];
StaticDetails.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
