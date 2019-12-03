using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PIDOTNET.DATA.DataModel;
using PIDOTNET.WEB.Models;
using PIDOTNET.DATA.DataModel;

namespace PIDOTNET.WEB.Controllers
{
    public class Evaluation360Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Evaluation360
        public ActionResult Index()
        {
            return View(db.Evaluation360.ToList());
        }

        // GET: Evaluation360/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation360 evaluation360 = db.Evaluation360.Find(id);
            if (evaluation360 == null)
            {
                return HttpNotFound();
            }
            return View(evaluation360);
        }

        // GET: Evaluation360/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evaluation360/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,etat,nameEvaluation,noteEvaluation,avisEvaluation")] Evaluation360 evaluation360)
        {
            if (ModelState.IsValid)
            {
                db.Evaluation360.Add(evaluation360);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(evaluation360);
        }

        // GET: Evaluation360/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation360 evaluation360 = db.Evaluation360.Find(id);
            if (evaluation360 == null)
            {
                return HttpNotFound();
            }
            return View(evaluation360);
        }

        // POST: Evaluation360/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,etat,nameEvaluation,noteEvaluation,avisEvaluation")] Evaluation360 evaluation360)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluation360).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evaluation360);
        }

        // GET: Evaluation360/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation360 evaluation360 = db.Evaluation360.Find(id);
            if (evaluation360 == null)
            {
                return HttpNotFound();
            }
            return View(evaluation360);
        }

        // POST: Evaluation360/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluation360 evaluation360 = db.Evaluation360.Find(id);
            db.Evaluation360.Remove(evaluation360);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
