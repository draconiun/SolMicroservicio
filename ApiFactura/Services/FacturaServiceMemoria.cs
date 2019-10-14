using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFactura.Model;

namespace ApiFactura.Services
{
    public class FacturaServiceMemoria : IFacturaService
    {
        private List<Factura> contexto = null;

        public FacturaServiceMemoria()
        {
            contexto = new List<Factura>();
            contexto.Add(new Factura { IdFactura = 1, NombreCliente = "Juan Perez", Precio = 2500 });
            contexto.Add(new Factura { IdFactura = 2, NombreCliente = "Maria Lopez", Precio = 32432 });
            contexto.Add(new Factura { IdFactura = 3, NombreCliente = "Miguel Salvador", Precio = 3423 });
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Factura Insertar(Factura factura)
        {
            throw new NotImplementedException();
        }

        public List<Factura> Listar()
        {
            return contexto;
            //throw new NotImplementedException();
        }

        public Factura Recuperar(int id)
        {
            //Factura f = null;

            //f = (from x in contexto
            //     where x.IdFactura == id
            //     select x).FirstOrDefault();

            return contexto.FirstOrDefault(x => x.IdFactura == id);


            //throw new NotImplementedException();
        }
    }
}
