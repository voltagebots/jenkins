using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Grocedy.Core.Core;
using Grocedy.Core.Repositories;
using Grocedy.Domain.Models;
using Grocedy.Infrastructure.Infrastructure;
using Grocedy.Infrastructure.Services;
using Grocedy.Infrastructure.Services.Account;
using Grocedy.Infrastructure.Services.Zoho;
using GrocedyAPI.Helpers;
using GrocedyAPI.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace GrocedyAPI
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:8088",
                                                          "http://localhost:4200")
                                             .AllowAnyHeader()
                                             .AllowAnyMethod()
                                             .WithMethods("POST", "DELETE", "GET");
                                  });
            });

            services.AddControllers();
            services.AddDbContext<GrocedyAPI.Models.GrocedyContext>();
            services.AddDbContext<GrocedyContext>();
            services.AddTransient<IRepository<WpUsers>, UsersRepository>();
            services.AddTransient<IRepository<WpUsermeta>, UsersMetaRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IHttpClientFactory, HttpClientFactory>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IRazorViewToStringRenderer, RazorViewToStringRenderer>();

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IZohoService, ZohoService>();
            services.AddTransient<IWebHooksService, WebHooksService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Grocedy API", Version = "v1" });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var builder = new ConfigurationBuilder()
           .SetBasePath(env.ContentRootPath)
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
           .AddEnvironmentVariables();

            this.Configuration = builder.Build();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UsePathBase("/Grocedy-API");

         

            app.UseSwaggerUI(c =>
            {
                if (env.IsDevelopment())
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                }
                else
                {
                    c.SwaggerEndpoint("http://ec2-18-218-159-62.us-east-2.compute.amazonaws.com/swagger/v1/swagger.json", "My API V1");
                }


            });
       
        }
    }
}
