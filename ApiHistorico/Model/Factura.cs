using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiHistorico.Model
{
    public class Factura
    {
        [BsonId]
        [BsonElement("auto")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId auto { get; set; }

        [BsonElement("autogenerado")]
        public string Autogenerado { get; set; }

        [BsonElement("nombrecliente")]
        public string NombreCliente { get; set; }

        [BsonElement("precio")]
        public decimal Precio { get; set; }
    }
}
