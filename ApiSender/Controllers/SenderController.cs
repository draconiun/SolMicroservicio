using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiSender.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ApiSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SenderController : ControllerBase
    {
        private readonly IOptions<ParametroConfig> configuration;
        public SenderController(IOptions<ParametroConfig> configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Send([FromBody]Factura request)
        {
            //string ruta = configuration.GetValue<string>("BusUrl");
            //string topicRuta = configuration.GetValue<string>("BusTopic");

            string ruta = configuration.Value.BusUrl;
            string topicRuta = configuration.Value.BusTopic;

            string data = JsonConvert.SerializeObject(request);
            Message message = new Message(Encoding.UTF8.GetBytes(data));
            TopicClient client = new TopicClient(ruta, topicRuta);

            try
            {
                await client.SendAsync(message);
                return Ok(new { msje = "Datos procesados" });
            }
            catch (Exception ex)
            {
                //ex
                return Ok(new { msje = "Error al procesar " + ex.Message });
            }

        }

    }
}