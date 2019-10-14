using ApiFactura.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFactura.Contexto
{
    public class DbVentasContext : DbContext
    {
        public DbVentasContext(DbContextOptions<DbVentasContext> options) : base (options)
        {

        }

        public DbSet<Factura> Factura { get; set; }
    }
}
