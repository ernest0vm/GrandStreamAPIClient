using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GrandstreamClient.Manager
{
    public class RestManager
    {
        public HttpClient Client(HttpClientHandler handler)
        {

            HttpClient httpClient = new HttpClient(handler)
            {
                //BaseAddress = new Uri("https://jsonplaceholder.typicode.com/"),
                BaseAddress = new Uri("https://<ip-server>:8443/"),
                Timeout = new TimeSpan(0,0,10)
            };

            //var authInfo = Encoding.Default.GetBytes("cdrapi:cdrapi123");
            //httpClient.DefaultRequestHeaders.Authorization =
            //    new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authInfo));

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

    }
    
}
