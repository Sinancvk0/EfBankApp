using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using SC.BankApp.Web.Data.Context;
using SC.BankApp.Web.Data.Interfaces;
using SC.BankApp.Web.Data.Repositories;
using SC.BankApp.Web.Mapping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SC.BankApp.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BankContext>(opt =>
            {
                opt.UseSqlServer("Server=.\\SQLEXPRESS;Database=BankDb;Integrated Security=True;TrustServerCertificate=True");

            });

            services.AddScoped(typeof(IRepository<>),typeof(Repository<>) );
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IUserMapper, UserMapper>();
            services.AddScoped<IAccountRepository, AccountRepositorty>();
            services.AddScoped<IAccountMapper, AccountMapper>();
            services.AddControllersWithViews(); //conroller views tanýmladýk
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();//wwwroot dýþarý açýyoruz 

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                RequestPath = "/node_modules"

            }); //node modules path ile geldiðinde açýlan yer
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute(); //default olarak home index id? 
            });
        }
    }
}
