using demo1.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace demo1.UI.Configuration.Startup
{
    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration config, IHostingEnvironment env)
        {
              services.AddDbContext<DemoDbContext>(c =>
                {
                    try
                    {
                        c.UseSqlite(config.GetConnectionString("DemoDbProduction"), b => b.MigrationsAssembly("demo1.UI"));
                    }
                    catch (System.Exception ex)
                    {
                        var message = ex.Message;
                    }
                });

                       
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
