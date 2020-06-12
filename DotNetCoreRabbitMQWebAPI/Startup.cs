using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreRabbitMQ.ClientService.Models;
using DotNetCoreRabbitMQ.ClientService.Repositories;
using DotNetCoreRabbitMQ.ClientService.Services;
using DotNetCoreRabbitMQ.Common.Logging;
using EasyNetQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DotNetCoreRabbitMQWebAPI {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            // IoC - EventBus
            services.AddSingleton(RabbitHutch.CreateBus(Configuration["MQ:Dev"]));
            // IoC - Logger
            services.AddSingleton<DotNetCoreRabbitMQ.Common.Logging.ILogger, ExceptionlessLogger>();
            // IoC - Service & Repository
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IClientRepository, ClientRepository>();
            // IoC - DbContext
            services.AddDbContextPool<ClientDbContext>(
                options => options.UseSqlServer(Configuration["DB:Dev"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
