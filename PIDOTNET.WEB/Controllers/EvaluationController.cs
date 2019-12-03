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




        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/PIDEV4GL2-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/aaaa/" + id).Result;
            Evaluation project = new Evaluation();
            if (response.IsSuccessStatusCode)
            {

                project = response.Content.ReadAsAsync<Evaluation>().Result;

            }
            else
            {
                ViewBag.project = "erreur";
            }

            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9080/PIDEV4GL2-web/");

                // TODO: Add insert logic here
                client.DeleteAsync("api/aaaa/" + id)
                        .ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }











    }
}