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

        public List<Factura> Listar()
        {
            return FacturaService.Listar();
        }
    }
}