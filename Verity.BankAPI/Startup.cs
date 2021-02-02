using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Verity.BankAPI.Services.CurrentAccountService;

namespace Verity.BankAPI
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
            services.AddMvc()
                .ConfigureApiBehaviorOptions(options => {
                    options.SuppressModelStateInvalidFilter = true;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddEntityFrameworkSqlServer();
            services.AddSingleton<ICurrentAccountService, CurrentAccountService>();

            services.AddSwaggerGen(a =>
            {
                a.SwaggerDoc("Verity.BankAPI.v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Bank API",
                    Description = "This API is responsible for all transactions done to a given current account",
                    Version = "1.0"
                });

                var xmlPath = System.AppDomain.CurrentDomain.BaseDirectory + @"Verity.BankAPI.xml";
                a.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(a =>
            {
                a.SwaggerEndpoint("/swagger/Verity.BankAPI.v1/swagger.json", "Bank API");
            });
        }
    }
}
