﻿using ApiFactura.Model;
using ApiFactura.Services;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApiFactura.Helper
{
    public class RecibeSuscripcion : IRecibeSuscripcion
    {
        private readonly IOptions<ParametroConfig> options;
        private readonly ILogger<RecibeSuscripcion> logger;
        private readonly IProcesaDatos procesaDatos;

        private readonly SubscriptionClient subscriptionClient;

        public RecibeSuscripcion(IOptions<ParametroConfig> options,
                                 ILogger<RecibeSuscripcion> logger,
                                 IProcesaDatos procesaDatos)
        {
            this.options = options;
            this.logger = logger;
            this.procesaDatos = procesaDatos;

            subscriptionClient = new SubscriptionClient(options.Value.BusUrl,
                                                        options.Value.BusTopic,
                                                        options.Value.BusSuscriptor);
        }
        public async Task CierraSuscripcionCliente()
        {
            await subscriptionClient.CloseAsync(); ;
        }

        public async Task PreparaFiltro()
        {
            MessageHandlerOptions messageopt = new MessageHandlerOptions(ProcesaError)
            {
                //Acá dentro también se puede implementar patron SAGA
                AutoComplete = false, //Espera que se complete todo la trama, necesario para hacer rollbacks
                MaxConcurrentCalls = 1
            };

            subscriptionClient.RegisterMessageHandler(ProcesaMensaje, messageopt);
        }


        public Task ProcesaError(ExceptionReceivedEventArgs arg)
        {
            logger.LogError(arg.Exception, "No se pudo recibir");
            var contextError = arg.ExceptionReceivedContext;
            logger.LogDebug($"End point {contextError.Endpoint}");

            return Task.CompletedTask;
        }

        public async Task ProcesaMensaje(Message mensaje, CancellationToken token)
        {
            string texto = Encoding.UTF8.GetString(mensaje.Body);
            var factura = JsonConvert.DeserializeObject<Factura>(texto);
            procesaDatos.ProcesarFactura(factura);

            await subscriptionClient.CompleteAsync(mensaje.SystemProperties.LockToken);
        }
    }
}
