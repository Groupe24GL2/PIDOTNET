using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PIDOTNET.DATA.DataModel;
using PIDOTNET.DATA.Infrastructure;
using PIDOTNET.SERVICEPATTERN;
using System.Net;

namespace PIDOTNET.WEB.Controllers
{
    public class EvalController : Controller
    {

        private Model4 db = new Model4();
        static IDatabaseFactory Factory = new DatabaseFactory();
        // GET: Eval
        public ActionResult Index()
        {


            List<evaluation360> appo = new List<evaluation360>();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<evaluation360> jbService = new Service<evaluation360>(Uok);
            List<evaluation360> t = new List<evaluation360>();
            appo = jbService.GetAll().ToList();
            return View(appo);
           
        }

        // GET: Eval/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<evaluation360> jbService = new Service<evaluation360>(Uok);
            evaluation360 app = jbService.GetById(id);
            return View(app);
            if (app == null)
            {
                return HttpNotFound();
            }
            return View(app);
        }

        // GET: Eval/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eval/Create
        [HttpPost]
        public ActionResult Create(evaluation360 e)
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<evaluation360> iser = new Service<evaluation360>(Uok);
            IService<evaluation360> jbServiceEmploye = new Service<evaluation360>(Uok);
            iser.Add(e);
            iser.Commit();


            return RedirectToAction("Index");
        }

        // GET: Eval/Edit/5
        public ActionResult Edit(int id)
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<evaluation360> jbService = new Service<evaluation360>(Uok);
            evaluation360 app = jbService.GetById(id);

            return View(app);
        }

        // POST: Eval/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<evaluation360> jbService = new Service<evaluation360>(Uok);
            evaluation360 app = jbService.GetById(id);
            app.nom = Request.Form["nom"];
            app.avis= Request.Form["avis"];
            app.description = Request.Form["description"];
            jbService.Commit();

            return RedirectToAction("Index");
        }

        // GET: Eval/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<evaluation360> jbService = new Service<evaluation360>(Uok);
            evaluation360 conge = jbService.GetById(id);
            if (conge == null)
            {
                return HttpNotFound();
            }
            return View(conge);
        }

        // POST: Eval/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);

            IService<evaluation360> iser = new Service<evaluation360>(Uok);
            evaluation360 conge = iser.GetById(id);
            iser.Delete(conge);
            iser.Commit();

            /*db.conge.Remove(conge);
            db.SaveChanges();*/
            return RedirectToAction("Index");
        }
    }
}
