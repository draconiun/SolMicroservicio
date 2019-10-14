using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFactura.Contexto;
using ApiFactura.Model;

namespace ApiFactura.Services
{
    public class FacturaServiceSQL : IFacturaService
    {
        private readonly DbVentasContext contexto;

        public FacturaServiceSQL(DbVentasContext contexto)
        {
            this.contexto = contexto;
        }


        public void Eliminar(int id)
        {
            Factura f = contexto.Factura.FirstOrDefault(s => s.IdFactura == id);
            contexto.Factura.Remove(f);
            contexto.SaveChanges();
        }

        public Factura Insertar(Factura factura)
        {
            contexto.Factura.Add(factura);
            contexto.SaveChanges();
            return factura;
        }

        public List<Factura> Listar()
        {
            return contexto.Factura.ToList();
        }

        public Factura Recuperar(int id)
        {
            return contexto.Factura.FirstOrDefault(x => x.IdFactura == id);
        }
    }
}
