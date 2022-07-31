using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Organisasi_WebApi.Models
{
    public class AnggotaItem
    {
            private AnggotaContext context;

            public int id { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string address { get; set; }
    }
}
