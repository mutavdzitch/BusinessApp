using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using EfCommands;
using EfDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //BusinessContext
            services.AddDbContext<BusinessContext>();

            //Employees
            services.AddTransient<IGetEmployeesCommand, EfGetEmployeesCommand>();
            services.AddTransient<IGetEmployeeCommand, EfGetEmployeeCommand>();
            services.AddTransient<IAddEmployeeCommand, EfAddEmployeeCommand>();
            services.AddTransient<IDeleteEmployeeCommand, EfDeleteEmployeeCommand>();
            services.AddTransient<IEditEmployeeCommand, EfEditEmployeeCommand>();
            //Projects
            services.AddTransient<IGetProjectsCommand, EfGetProjectsCommand>();
            services.AddTransient<IGetProjectCommand, EfGetProjectCommand>();
            services.AddTransient<IAddProjectCommand, EfAddProjectCommand>();
            services.AddTransient<IDeleteProjectCommand, EfDeleteProjectCommand>();
            services.AddTransient<IEditProjectCommand, EfEditProjectCommand>();
            //Companies
            services.AddTransient<IGetCompaniesCommand, EfGetCompaniesCommand>();
            services.AddTransient<IGetCompanyCommand, EfGetCompanyCommand>();
            services.AddTransient<IAddCompanyCommand, EfAddCompanyCommand>();
            services.AddTransient<IDeleteCompanyCommand, EfDeleteCompanyCommand>();
            services.AddTransient<IEditCompanyCommand, EfEditCompanyCommand>();
            //Vocations
            services.AddTransient<IGetVocationsCommand, EfGetVocationsCommand>();
            services.AddTransient<IGetVocationCommand, EfGetVocationCommand>();
            services.AddTransient<IAddVocationCommand, EfAddVocationCommand>();
            services.AddTransient<IDeleteVocationCommand, EfDeleteVocationCommand>();
            services.AddTransient<IEditVocationCommand, EfEditVocationCommand>();
            //Statuses
            services.AddTransient<IGetStatusesCommand, EfGetStatusesCommand>();
            services.AddTransient<IGetStatusCommand, EfGetStatusCommand>();
            services.AddTransient<IAddStatusCommand, EfAddStatusCommand>();
            services.AddTransient<IDeleteStatusCommand, EfDeleteStatusCommand>();
            services.AddTransient<IEditStatusCommand, EfEditStatusCommand>();
            //Cities
            services.AddTransient<IGetCitiesCommand, EfGetCitiesCommand>();
            services.AddTransient<IGetCityCommand, EfGetCityCommand>();
            services.AddTransient<IAddCityCommand, EfAddCityCommand>();
            services.AddTransient<IDeleteCityCommand, EfDeleteCityCommand>();
            services.AddTransient<IEditCityCommand, EfEditCityCommand>();
            //Tasks
            services.AddTransient<IGetTasksCommand, EfGetTasksCommand>();
            services.AddTransient<IGetTaskCommand, EfGetTaskCommand>();
            services.AddTransient<IAddTaskCommand, EfAddTaskCommand>();
            services.AddTransient<IDeleteTaskCommand, EfDeleteTaskCommand>();
            services.AddTransient<IEditTaskCommand, EfEditTaskCommand>();
            //EmployeeProjects
            services.AddTransient<IGetEmployeeProjectsCommand, EfGetEmployeeProjectsCommand>();
            services.AddTransient<IGetEmployeeProjectCommand, EfGetEmployeeProjectCommand>();
            services.AddTransient<IAddEmployeeProjectCommand, EfAddEmployeeProjectCommand>();
            services.AddTransient<IDeleteEmployeeProjectCommand, EfDeleteEmployeeProjectCommand>();
            //ProjectCompanies
            services.AddTransient<IGetProjectCompaniesCommand, EfGetProjectCompaniesCommand>();
            services.AddTransient<IGetProjectCompanyCommand, EfGetProjectCompanyCommand>();
            services.AddTransient<IAddProjectCompanyCommand, EfAddProjectCompanyCommand>();
            services.AddTransient<IDeleteProjectCompanyCommand, EfDeleteProjectCompanyCommand>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Business API", Version = "v1" });
            });
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
