using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiHistorico.Model
{
    public class ParametroConfig
    {
        public string UrlSeguridad { get; set; }
        public string ApiNameSeguridad { get; set; }
        public string BusUrl { get; set; }
        public string BusTopic { get; set; }
        public string BusSuscriptor { get; set; }
        public string MongoServer { get; set; }
        public string MongoDbname { get; set; }
        public string MongoColName { get; set; }
    }
}
