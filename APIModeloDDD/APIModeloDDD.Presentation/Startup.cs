 using System;
using System.IO;
using System.Reflection;
using APIModeloDDD.Infra.CrossCutting;
using APIModeloDDD.Presentation.Swagger;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Examples;
using Swashbuckle.AspNetCore.Swagger;

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

            //Configuração do Swagger
            //services.ConfigureSwaggerGen(x =>
            //{
            //    x.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            //    x.OperationFilter<ProducesOperatioFilter>();
            //});

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info
            //    {
            //        Version = "v1",
            //        Title = "API Modelo DDD",
            //        Description = "Exemplo de API usando padrão DDD",
            //        TermsOfService = "None",
            //        Contact = new Contact
            //        {
            //            Name = "Rafael Dias",
            //            Email = string.Empty,
            //            Url = "https://github.com/rafaeldias97"
            //        }
            //    });

            //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //    c.IncludeXmlComments(xmlPath);

            //    c.OperationFilter<ExamplesOperationFilter>();
            //});

            //AutoMapper
            services.AddAutoMapper(typeof(Startup));

            // IoC
            NativeInjectorBootStrapper.RegisterServices(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseSwagger();

            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint($"../swagger/v1/swagger.json", "apimodelo");
            //});

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
