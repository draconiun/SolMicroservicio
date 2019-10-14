using ApiFactura.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFactura.Services
{
    public interface IFacturaService
    {
        List<Factura> Listar();
        Factura Insertar(Factura factura);
        Factura Recuperar(int id);
        void Eliminar(int id);
    }
}
