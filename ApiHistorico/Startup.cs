using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiHistorico.Helper;
using ApiHistorico.Model;
using ApiHistorico.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddOptions();
            services.Configure<ParametroConfig>(Configuration);

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

            app.UseMvc();

            IRecibeSuscripcion suscripcion = app.ApplicationServices.GetService<IRecibeSuscripcion>();
            suscripcion.PreparaFiltro().GetAwaiter().GetResult();
        }
    }
}
