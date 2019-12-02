using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PIDOTNET.WEB.ViewModel;

namespace PIDOTNET.WEB.Controllers
{
    public class EvaluationController : Controller
    {
        // GET: Evaluation
        public ActionResult Index()
        {

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/PIDEV4GL2-web/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("api/aaaa").Result;

            if (response.IsSuccessStatusCode)
            {  //Evaluation

                //    ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Evaluation>>().Result;
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Evaluation>>().Result;
            }

            else
            {
                ViewBag.result = "error";
            }



            return View();
        }




        [HttpGet]
        public ActionResult Create()
        {

            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(Evaluation eval)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/PIDEV4GL2-web/");

            var result = client.PostAsJsonAsync<Evaluation>("api/aaaa", eval).Result;

            return RedirectToAction("Index");
        }


    }
}