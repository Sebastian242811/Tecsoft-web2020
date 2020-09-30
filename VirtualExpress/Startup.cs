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
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Persistence.Context;
using VirtualExpress.Domain.Repositories;
using VirtualExpress.Domain.Services;
using VirtualExpress.Domain.Services.Communications;
using VirtualExpress.Extensions;
using VirtualExpress.Persistence.Repository;
using VirtualExpress.Resource;
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
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IFreightRepository, FreightRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IPayRepository, PayRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerServiceEmployeeRepository, CustomerServiceEmployeeRepository>();
            services.AddScoped<IDispatcherRepository, DispatcherRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IComentaryRepository, ComentaryRepository>();
            services.AddRouting(options => options.LowercaseUrls = true);

            //Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Services
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ITerminalService, TerminalService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IFreightService, FreightService>();
            services.AddScoped<IPackageStateService, PackageStateService>();
            services.AddScoped<IPayService, PayService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerServiceEmployeeService, CustomerServiceEmployeeService>();
            services.AddScoped<IDispatcherService, DispatcherService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<ICommentaryService, CommentService>();

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
