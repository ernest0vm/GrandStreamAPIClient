using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GrandstreamClient.Manager;
using GrandstreamClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GrandstreamClient.Controllers
{
    public class CDRController : Controller
    {
        RestManager manager;

        public CDRController()
        {
            manager = new RestManager();
        }

        public async Task<IActionResult> Index()
        {
            using (HttpClientHandler httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                var credential = new NetworkCredential("cdrapi", "cdrapi123");
                httpClientHandler.Credentials = credential;
                httpClientHandler.PreAuthenticate = true;

                using (HttpClient client = manager.Client(httpClientHandler))
                {
                    //HttpResponseMessage response = await client.GetAsync("todos/1");
                    HttpResponseMessage response = await client.GetAsync("cdrapi?format=json");

                    RootObject list = new RootObject();
                    List<CDR> ResultList = new List<CDR>();

                    if (response.IsSuccessStatusCode)
                    {

                        string result = await response.Content.ReadAsStringAsync();
                        //list = JsonConvert.DeserializeObject<ObjTest>(result);

                        list = JsonConvert.DeserializeObject<RootObject>(result);
                             
                        foreach(var item in list.cdr_root)
                        {
                            if (!string.IsNullOrEmpty(item.recordfiles))
                            {
                                item.recordfiles = $"{client.BaseAddress}recapi?filename={item.recordfiles}";
                            }

                            if (item.main_cdr != null)
                            {
                                item.main_cdr.recordfiles = string.IsNullOrEmpty(item.main_cdr.recordfiles) ? string.Empty : $"{client.BaseAddress}recapi?filename={item.main_cdr.recordfiles}";
                            }

                            if (item.sub_cdr_1 != null)
                            {
                                item.sub_cdr_1.recordfiles = string.IsNullOrEmpty(item.sub_cdr_1.recordfiles) ? string.Empty : $"{client.BaseAddress}recapi?filename={item.sub_cdr_1.recordfiles}";
                            }

                            if (item.sub_cdr_2 != null)
                            {
                                item.sub_cdr_2.recordfiles = string.IsNullOrEmpty(item.sub_cdr_2.recordfiles) ? string.Empty : $"{client.BaseAddress}recapi?filename={item.sub_cdr_2.recordfiles}";
                            }

                            if (item.sub_cdr_3 != null)
                            {
                                item.sub_cdr_3.recordfiles = string.IsNullOrEmpty(item.sub_cdr_3.recordfiles) ? string.Empty : $"{client.BaseAddress}recapi?filename={item.sub_cdr_3.recordfiles}";
                            }

                            if (item.sub_cdr_4 != null)
                            {
                                item.sub_cdr_4.recordfiles = string.IsNullOrEmpty(item.sub_cdr_4.recordfiles) ? string.Empty : $"{client.BaseAddress}recapi?filename={item.sub_cdr_4.recordfiles}";
                            }

                            ResultList.Add(item);
                        }
                    }

                    return View(ResultList);
                }
            }
            
        }
        
    }
}