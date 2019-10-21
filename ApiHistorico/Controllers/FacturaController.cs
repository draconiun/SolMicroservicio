using ApiHistorico.Model;
using ApiHistorico.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiHistorico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService facturaService;

        public FacturaController(IFacturaService facturaService)
        {
            this.facturaService = facturaService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(facturaService.Listar());
        }

        [HttpPost]
        public IActionResult Insertar([FromBody]Factura factura)
        {
            return Ok(facturaService.Insertar(factura));
        }
    }
}