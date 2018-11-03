using AutoMapper;
using CalcTest.API.Configurations;
using CalcTest.IoC;
using CalcTest.Service.Automapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CalcTest.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebApi(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                options.UseCentralRoutePrefix(new RouteAttribute("api/v{versao:apiVersion}"));
            });

            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(new DateTime(2018, 11, 3));
            });

            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }

        private static void RegisterServices(IServiceCollection services)
            => NativeInjectorBootStrapper.RegisterServices(services);
    }
}
