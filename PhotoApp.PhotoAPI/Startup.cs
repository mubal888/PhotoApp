using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PhotoApp.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PhotoApp.BLL.Entity.Abstract;
using PhotoApp.BLL.Entity.Base;
using PhotoApp.DAL.Abstract;
using PhotoApp.DAL.Base;
using AutoMapper;
using PhotoApp.DAL.EntityContext;
using System.Reflection;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Routing;
using PhotoApp.PhotoAPI.Filters.Exception;

namespace PhotoApp.PhotoAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddControllers(options =>
            //{
            //    options.Filters.Add<UnhandledExceptionFilterAttribute>();
            //});
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();

            services.AddDbContext<PhotoDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("PhotoApp.PhotoAPI")));
            services.AddControllers();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMvcCore();
            services.AddTransient<IFirmaRepository, FirmaRepository>();
            services.AddTransient<IFirmaBaseRepository, FirmaBaseRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserBaseRepository, UserBaseRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Hata/Error");
                //app.UseExceptionHandler("/Hata/Error");

            //app.UseStatusCodePagesWithReExecute("/Hata/Status", "?code={0}");
            app.UseHsts();
            }
            SeedDatabase.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    RequestPath = "/node_modules",
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules"))
            //});
            
            app.UseRouting();
            //app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //   name: "areas",
                //   pattern: "{Area}/{Controller=Home}/{Action=Index}/{id?}"
                //   );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{Controller}/{Action}/{id?}",
                    defaults: new { Controller = "Firma", Action = "Index" }
                    );

            });
        }
       
    }
}
