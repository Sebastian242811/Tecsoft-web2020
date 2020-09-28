using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VirtualExpress.Domain.Persistence.Context;
using VirtualExpress.Domain.Repositories;
using VirtualExpress.Domain.Services;
using VirtualExpress.Domain.Services.Communications;
using VirtualExpress.Extensions;
using VirtualExpress.Persistence.Repository;
using VirtualExpress.Services;

namespace VirtualExpress
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
            services.AddControllers();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("transport-api-in-memory");
            });

            //Repositories
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ITerminalRepository, TerminalRepository>();

            services.AddRouting(options => options.LowercaseUrls = true);

            //Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Services
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ITerminalService, TerminalService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddCustomSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UserCustomSwagger();
        }
    }
}
