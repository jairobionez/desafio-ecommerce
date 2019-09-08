using AutoMapper;
using DesafioEcommerce.Application.AutoMapper;
using DesafioEcommerce.Infra.CrossCutting.IoC;
using DesafioEcommerce.Infra.Data.Context;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace DesafioEcommerce.Application
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
            services.AddDbContext<EcommerceContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("EcommerceConnectionString")));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));

            var assembly = AppDomain.CurrentDomain.Load("DesafioEcommerce.Domain");
            services.AddMediatR(assembly);

            services.AddCors(options =>
            {

            options.AddPolicy("allow",
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Desafio E-commerce",
                    Description = "Descrição dos métodos da API do e-commerce",
                    Contact = new Contact { Name = "Jairo Bionez", Email = "jairo.d.b@hotmail.com", Url = "https://github.com/jairobionez" },
                });

                s.IncludeXmlComments(XmlCommentsFilePath(GetAssemblyName() + ".xml"));
                s.IncludeXmlComments(XmlCommentsFilePath("DesafioEcommerce.Domain.xml"));

            });
            services.AddMvc().AddFluentValidation();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // DI
            RegisterServices(services);
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

            app.UseCors("allow");
            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio E-commerce API v1.1");
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            InjectorBootStrapper.RegisterServices(services);
        }

        private static string XmlCommentsFilePath(string xmlDocFileName)
                                   => Path.Combine(AppContext.BaseDirectory, xmlDocFileName);
        private static string GetAssemblyName()
                                   => typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

    }
}
