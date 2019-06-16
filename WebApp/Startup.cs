﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using EfCommands;
using EfDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //BusinessContext
            services.AddDbContext<BusinessContext>();

            //Projects
            services.AddTransient<IGetProjectsCommand, EfGetProjectsCommand>();
            services.AddTransient<IGetProjectCommand, EfGetProjectCommand>();
            services.AddTransient<IAddProjectCommand, EfAddProjectCommand>();
            services.AddTransient<IDeleteProjectCommand, EfDeleteProjectCommand>();
            services.AddTransient<IEditProjectCommand, EfEditProjectCommand>();
            //Employees
            services.AddTransient<IGetEmployeesCommand, EfGetEmployeesCommand>();
            services.AddTransient<IGetEmployeeCommand, EfGetEmployeeCommand>();
            services.AddTransient<IAddEmployeeCommand, EfAddEmployeeCommand>();
            services.AddTransient<IDeleteEmployeeCommand, EfDeleteEmployeeCommand>();
            services.AddTransient<IEditEmployeeCommand, EfEditEmployeeCommand>();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
