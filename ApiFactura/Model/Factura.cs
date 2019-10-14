using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFactura.Model
{
    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }
        public string NombreCliente { get; set; }
        public decimal Precio { get; set; }

    }
}
