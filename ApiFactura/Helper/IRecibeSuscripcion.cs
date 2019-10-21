using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFactura.Helper
{
    public interface IRecibeSuscripcion
    {
        Task PreparaFiltro();
        Task CierraSuscripcionCliente();
    }
}
