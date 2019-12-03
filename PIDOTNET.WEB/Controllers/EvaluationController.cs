using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PIDOTNET.WEB.ViewModel;
using PIDOTNET.WEB.Models;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Web.Http;


namespace PIDOTNET.WEB.Controllers
{
    public class EvaluationController : Controller
    {
        public EvaluationController()
        { }

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




        [System.Web.Mvc.HttpGet]
        public ActionResult Create()
        {

            return View("Create");
        }

        //[HttpPost]
        //public  ActionResult Create(Evaluation eval)
        //{

        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://localhost:9080/PIDEV4GL2-web/");

        //    // var result = client.PostAsJsonAsync<Evaluation>("api/aaaa", eval).Result;
        //    var result = client.PostAsJsonAsync<Evaluation>("api/aaaa", eval).Result;


        //    return RedirectToAction("Index");
        //}
        [System.Web.Mvc.HttpPost, ValidateInput(false)]
        public async Task<ActionResult> Create([FromBody]Models.AddEvalViewModel eval)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:9080");
            var response = client.PostAsJsonAsync("/PIDEV4GL2-web/api/aaaa", eval).Result;
            return View("Create");

        }



        // GET: Project/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://localhost:9080/PIDEV4GL2-web/");
        //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //    HttpResponseMessage response = client.GetAsync("api/aaaa/" + id).Result;
        //    Evaluation project = new Evaluation();
        //    if (response.IsSuccessStatusCode)
        //    {

        //        project = response.Content.ReadAsAsync<Evaluation>().Result;

        //    }
        //    else
        //    {
        //        ViewBag.project = "erreur";
        //    }

        //    return View(project);
        //}

        //// POST: Project/Delete/5
        //[System.Web.Mvc.HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
        //        HttpClient client = new HttpClient();
        //        client.BaseAddress = new Uri("http://localhost:9080/PIDEV4GL2-web/");

        //        // TODO: Add insert logic here
        //        client.DeleteAsync("api/aaaa/" + id)
        //                .ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        [System.Web.Mvc.HttpGet]
        public async Task<ActionResult> Delete(long id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:9080");
            var response = client.DeleteAsync("/PIDEV4GL2-web/api/aaaa/" + id).Result;
            return RedirectToAction("Index", "evaluation");

        }

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{

        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://localhost:9080/");
        //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        // //   client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //    HttpResponseMessage response = client.GetAsync("PIDEV4GL2-web/api/aaaa/" + id).Result;
        //    Evaluation evaluation = new Evaluation();
        //    if (response.IsSuccessStatusCode)
        //    {

        //        evaluation = response.Content.ReadAsAsync<Evaluation>().Result;

        //    }
        //    else
        //    {
        //        ViewBag.project = "erreur";
        //    }

        //    return View(evaluation);
        //}


        [System.Web.Mvc.HttpGet]

        public ActionResult Edit(int id)
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

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(Evaluation evaluation)
        {

            HttpClient Client = new HttpClient();
      
                   Client.BaseAddress = new Uri("http://localhost:9080/PIDEV4GL2-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // EvaluationModel eval = evaluation;
            HttpResponseMessage result = Client.PutAsJsonAsync<Evaluation>("api/aaaa/" + evaluation.id, evaluation).Result;


            return RedirectToAction("Index");
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> Update([FromBody]PIDOTNET.DATA.DataModel.evaluation eval)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:9080");
            var response = client.PutAsJsonAsync("/PIDEV4GL2-web/api/aaaa", eval).Result;
            return View("Index");

        }






























    }
}