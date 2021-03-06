﻿using demo2.Domain.AggregatesModel;
using demo2.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace demo2.UI.Web.Configuration.Startup
{
    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration config, IHostingEnvironment env)
        {
            services.AddDbContext<Demo2DbContext>(options =>
                options.UseSqlite(
                    config.GetConnectionString("DefaultConnection"), b=>b.MigrationsAssembly("demo2.UI.Web")));
            services.AddIdentity<User, Role>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<Demo2DbContext>();

            //services.AddDbContext<Demo2DbContext>(c =>
            //    {
            //        try
            //        {
            //            c.UseSqlite(config.GetConnectionString("Demo2DbProduction"), b => b.MigrationsAssembly("demo2.UI.Web"));
            //        }
            //        catch (System.Exception ex)
            //        {
            //            var message = ex.Message;
            //        }
            //    });

                       
            //if (env.IsDevelopment())
            //{
            //    services.AddDbContext<DemoDbContext>(c =>
            //    {
            //        try
            //        {
            //            c.UseSqlite(config.GetConnectionString("DemoDbProduction"), b => b.MigrationsAssembly("demo1.UI"));
            //        }
            //        catch (System.Exception ex)
            //        {
            //            var message = ex.Message;
            //        }
            //    });

            //}
            
            return services;
        }

        //public static IApplicationBuilder ConfigureDatabase(this IApplicationBuilder app)
        //{
            
        //}
    }
}
