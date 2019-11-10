using ApiHistorico.Helper;
using ApiHistorico.Model;
using ApiHistorico.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ApiHistorico
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
            string urlSeguridad = Environment.GetEnvironmentVariable("UrlSeguridad");
            if (!string.IsNullOrEmpty(urlSeguridad))
            {
                urlSeguridad = Configuration.GetValue<string>("UrlSeguridad");
            }

            string apiNameSeguridad = Environment.GetEnvironmentVariable("ApiNameSeguridad");
            if (!string.IsNullOrEmpty(apiNameSeguridad))
            {
                apiNameSeguridad = Configuration.GetValue<string>("ApiNameSeguridad");
            }

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddOptions();
            services.Configure<ParametroConfig>(Configuration);

            //Federar la seguridad con Identity Server 4
            services.AddAuthentication("Bearer")
                    .AddIdentityServerAuthentication(
                        options =>
                        {
                            options.Authority = urlSeguridad;
                            options.RequireHttpsMetadata = false;
                            options.ApiName = apiNameSeguridad;
                        }
                    );


            services.AddTransient<IFacturaService, FacturaService>();
            services.AddSingleton<IProcesaDatos, ProcesarDatos>();
            services.AddSingleton<IRecibeSuscripcion, RecibeSuscripcion>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();

            IRecibeSuscripcion suscripcion = app.ApplicationServices.GetService<IRecibeSuscripcion>();
            suscripcion.PreparaFiltro().GetAwaiter().GetResult();
        }
    }
}
