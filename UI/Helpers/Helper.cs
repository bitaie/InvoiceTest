using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UI.Helpers
{
    public class ApiInitializer
    {
        public HttpClient initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8607");
            return Client;
        }
    }
}
