using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiHistorico.Model;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ApiHistorico.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly ParametroConfig options;

        private readonly IMongoClient mongoClient;
        private readonly IMongoDatabase database;
        private IMongoCollection<Factura> collection;

        public FacturaService(IOptions<ParametroConfig> options)
        {
            this.options = options.Value;

            mongoClient = new MongoClient(this.options.MongoServer);
            database = mongoClient.GetDatabase(this.options.MongoDbname);
            collection = database.GetCollection<Factura>(this.options.MongoColName);
        }
        public Factura Insertar(Factura factura)
        {
            factura.auto = ObjectId.GenerateNewId();
            factura.Autogenerado = Guid.NewGuid().ToString();
            collection.InsertOne(factura);
            return factura;
        }

        public List<Factura> Listar()
        {
            var facturas  = collection.Find(t => true).ToList();
            return facturas;
        }
    }
}
