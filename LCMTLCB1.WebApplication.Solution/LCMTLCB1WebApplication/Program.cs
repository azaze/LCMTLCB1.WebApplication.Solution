using LCMTLCB1.WebAPI.Configuration;
using LCMTLCB1WebApplication.Repositories;
using LCMTLCB1WebApplication.Services.DataModels;
using Microsoft.AspNetCore.Localization;
using Microsoft.ServiceFabric.Services.Remoting;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<BookingRepository>();
builder.Services.AddScoped<ContainerRepository>();
builder.Services.AddScoped<BerthScheduleRepository>();
builder.Services.AddScoped<LoginRepository>();
builder.Services.AddSession();
// Add AppSetting config
ServiceProvider provider = builder.Services.BuildServiceProvider();
IConfiguration configuration = provider.GetRequiredService<IConfiguration>();
ApplicationSetting config = new ApplicationSetting();
configuration.Bind("ApplicationSetting", config);
builder.Services.AddSingleton<ApplicationSetting>(config);

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

var cultures = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("th-TH")
            };

var requestCulture = new RequestCulture("en-US", "en-US");

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = requestCulture,
    SupportedCultures = cultures,
    SupportedUICultures = cultures,
    RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new CookieRequestCultureProvider
                    {
                        CookieName = "LCB1Web.Language"
                    }
                }
});

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;

//namespace LCMTLCB1WebApplication
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            BuildWebHost(args).Run();
//        }

//        public static IWebHost BuildWebHost(string[] args) =>
//            WebHost.CreateDefaultBuilder(args)
//                .UseStartup<Startup>()
//                .Build();
//    }
//}
