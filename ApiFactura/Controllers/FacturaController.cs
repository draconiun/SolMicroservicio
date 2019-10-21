using ApiFactura.Model;
using ApiFactura.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiFactura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FacturaController : ControllerBase
    {
        private IFacturaService FacturaService;
        public FacturaController(IFacturaService facturaService)
        {
            FacturaService = facturaService;
        }

        [HttpGet]
        public List<Factura> Listar()
        {
            return FacturaService.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult Recuperar(int id)
        {
            var factura = FacturaService.Recuperar(id);
            if (factura == null) return BadRequest("El código de la factura no existe");
            return Ok(FacturaService.Recuperar(id));
        }

        [HttpPost]
        public IActionResult Insertar([FromBody]Factura factura)
        {
            if (string.IsNullOrEmpty(factura.NombreCliente))
                return BadRequest("El nombre del cliente esta vacío");

            return Ok(FacturaService.Insertar(factura));
        }

        [HttpGet("{id}/eecc")]
        public Factura Recuperar2(int id)
        {
            return FacturaService.Recuperar(id);
        }
    }
}