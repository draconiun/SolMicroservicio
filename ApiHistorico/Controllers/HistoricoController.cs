using ApiHistorico.Model;
using ApiHistorico.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiHistorico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HistoricoController : ControllerBase
    {
        private readonly IFacturaService facturaService;

        public HistoricoController(IFacturaService facturaService)
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