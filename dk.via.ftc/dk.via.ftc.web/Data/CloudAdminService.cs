using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace dk.via.ftc.web.Data
{
    public class CloudAdminService : IAdminService
    {
        private string uri = "https://localhost:44374/ds";
        private readonly HttpClient client;
        public CloudAdminService()
        {
            client = new HttpClient();
        }
    }
}
