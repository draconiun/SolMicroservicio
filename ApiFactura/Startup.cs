using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFactura.Contexto;
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
            services.AddDbContext<DbVentasContext>(
                    options =>
                    {
                        options.UseSqlServer(Configuration.GetValue<string>("CnnBd"));
                    }
                );

            //Federar la seguridad con Identity Server 4
            services.AddAuthentication("Bearer")
                    .AddIdentityServerAuthentication(
                        options =>
                        {
                            options.Authority = Configuration.GetValue<string>("UrlSeguridad");
                            options.RequireHttpsMetadata = false;
                            options.ApiName = Configuration.GetValue<string>("ApiNameSeguridad");
                        }
                    );
            //services.AddTransient<IFacturaService, FacturaServiceMemoria>();
            services.AddTransient<IFacturaService, FacturaServiceSQL>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
        }
    }
}
