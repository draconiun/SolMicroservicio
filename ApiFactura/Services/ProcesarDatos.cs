using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFactura.Model;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using ApiFactura.Contexto;

namespace ApiFactura.Services
{
    public class ProcesarDatos : IProcesaDatos
    {
        private readonly IOptions<ParametroConfig> options;

        public ProcesarDatos(IOptions<ParametroConfig> options)
        {
            this.options = options;
        }
        public void ProcesarFactura(Factura factura)
        {
            var opciones = new DbContextOptionsBuilder<DbVentasContext>();
                opciones.UseSqlServer(options.Value.CnnBd);

            using (DbVentasContext context = new DbVentasContext(opciones.Options))
            {
                context.Factura.Add(factura);
                context.SaveChanges();
            }
        }
    }
}
