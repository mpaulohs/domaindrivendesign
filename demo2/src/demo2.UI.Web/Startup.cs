using System;
using demo2.Application.Behaviors;
using demo2.Domain.AggregatesModel;
using demo2.Domain.SeedWork;
using demo2.Infrastructure.Data;
using demo2.Infrastructure.Repository;
using demo2.UI.Web.Configuration.Startup;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace demo2.UI.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment enviroment)
        {
            Configuration = configuration;
            Enviroment = enviroment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Enviroment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<Demo2DbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureDatabase(Configuration, Enviroment);
            AddMediatr(services);


            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void AddMediatr(IServiceCollection services)
        {
            const string applicationAssemblyName = "demo2.Application";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));

            services.AddMediatR();
        }
    }
}
