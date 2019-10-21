using ApiHistorico.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiHistorico.Services
{
    public interface IFacturaService
    {
        List<Factura> Listar();
        Factura Insertar(Factura factura);
    }
}
