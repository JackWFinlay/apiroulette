using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Text.Encodings.Web;

namespace apiroulette.Controllers
{
    public class APIController : Controller
    {
        [HttpGet]
        public async Task<JsonResult> Random(string q = "")
        {

            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://api.giphy.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "apiroulette.com" );

                if ( !String.IsNullOrWhiteSpace(q))
                {
                    UrlEncoder urlEncoder = UrlEncoder.Create();
                    string encodedUrl = urlEncoder.Encode(q);
                }
                
                string url = APIs.GetQueryString(q);

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<dynamic>(json);
                    return Json(result);
                }
            }
            return Json(new {});
        }
    }
}
