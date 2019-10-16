using APIModeloDDD.Infra.CrossCutting;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace APIModeloDDD.Presentation
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

            //AutoMapper
            services.AddAutoMapper(typeof(Startup));

            // IoC
            NativeInjectorBootStrapper.RegisterServices(services, Configuration);

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "API Modelo DDD",
                    Version = "v1",
                    Description = "A Base API using DDD(Domain Driven Design)",
                    Contact = new OpenApiContact {
                        Name = "Rafael Dias",
                        Email = "rafael.cdc97@gmail.com",
                        Url = new Uri("https://github.com/rafaeldias97")
                    }
                });
                var filePath = Path.Combine(AppContext.BaseDirectory, "APIModeloDDD.Presentation.xml");
                x.IncludeXmlComments(filePath);
            });
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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Modelo DDD");
            });
        }
    }
}
