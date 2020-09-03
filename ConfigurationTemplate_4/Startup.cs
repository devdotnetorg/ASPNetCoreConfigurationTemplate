using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;

namespace ConfigurationTemplate_4
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            configuration = builder.Build();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IServiceCollection Services { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Services = services;
            //Считаем секцию AppSettings из конфигурации
            var appSettings = Configuration.GetSection("AppSettings").Get<AppSettings>();
            appSettings.ClientConfigBuild();
            SingletonAppSettings singletonAppSettings = SingletonAppSettings.Instance;
            singletonAppSettings.appSettings = appSettings;
            services.AddSingleton(singletonAppSettings);             
            services.AddScoped(sp => sp.GetService<SingletonAppSettings>().appSettings);
            //next
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ChangeToken.OnChange(() => Configuration.GetReloadToken(), onChange);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        private void onChange()
        {                        
            var newAppSettings = Configuration.GetSection("AppSettings").Get<AppSettings>();
            newAppSettings.ClientConfigBuild();
            var serviceAppSettings = Services.BuildServiceProvider().GetService<SingletonAppSettings>();
            serviceAppSettings.appSettings = newAppSettings;
            Console.WriteLine($"AppSettings has been changed! {DateTime.Now}");
        }
    }
}