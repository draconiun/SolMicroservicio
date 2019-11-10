using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFactura.Contexto;
using ApiFactura.Helper;
using ApiFactura.Model;
using ApiFactura.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApiFactura
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

            string CnnBd = Environment.GetEnvironmentVariable("CnnBd");
            if (!string.IsNullOrEmpty(apiNameSeguridad))
            {
                CnnBd = Configuration.GetValue<string>("CnnBd");
            }

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddOptions();
            services.Configure<ParametroConfig>(Configuration);

            services.AddDbContext<DbVentasContext>(
                    options =>
                    {
                        options.UseSqlServer(CnnBd);
                    }
                );

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
            //services.AddTransient<IFacturaService, FacturaServiceMemoria>();
            services.AddTransient<IFacturaService, FacturaServiceSQL>();
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
