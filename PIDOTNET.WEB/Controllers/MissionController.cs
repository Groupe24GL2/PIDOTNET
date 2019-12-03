using PIDOTNET.DATA.DataModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace PIDOTNET.WEB.Controllers
{
    public class MissionController : Controller
    {
        // GET: Mission
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/PIDEV4GL2-web/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("api/all").Result;
            if (response.IsSuccessStatusCode)
            {  

                
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<mission>>().Result;
            }

            else
            {
                ViewBag.result = "error";
            }

            return View();
        }







    }
}