using Microsoft.AspNetCore.HttpOverrides;
using SuperHero.MVC.AutoMapper;
using SuperHero.MVC.Service.IService;
using SuperHero.MVC.Services;
// Configure the HTTP request pipeline.


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IHeroService, HeroService>();
builder.Services.AddAutoMapper(typeof(MappingConfigs).Assembly);

var app = builder.Build();



// ... rest of your code remains unchanged
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
