using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using ApiHistorico.Model;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ApiHistorico.Services
{
    public class ProcesarDatos : IProcesaDatos
    {
        private readonly ParametroConfig options;

        private readonly IMongoClient mongoClient;
        private readonly IMongoDatabase database;
        private IMongoCollection<Factura> collection;
        public ProcesarDatos(IOptions<ParametroConfig> options)
        {
            this.options = options.Value;
            mongoClient = new MongoClient(this.options.MongoServer);
            database = mongoClient.GetDatabase(this.options.MongoDbname);
            collection = database.GetCollection<Factura>(this.options.MongoColName);
        }
        public void ProcesarFactura(Factura factura)
        {
            //factura.auto = ObjectId.GenerateNewId();
            //factura.Autogenerado = Guid.NewGuid().ToString();
            //collection.InsertOne(factura);
            collection = database.GetCollection<Factura>
                (this.options.MongoColName);

            factura.auto = ObjectId.GenerateNewId();
            factura.Autogenerado = "test";//Guid.NewGuid().ToString();
            collection.InsertOne(factura);

        }
    }
}
