using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PIDOTNET.DATA.DataModel;
using PIDOTNET.DATA.Infrastructure;
using PIDOTNET.SERVICEPATTERN;
using System.Net;
using System.Net.Mail;
using PIDOTNET.SERVICE;

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


            //envoyer mail

            var verifyurl = "/Signup/VerifiyAccount/";
            var link = Request.Url.AbsolutePath.Replace(Request.Url.PathAndQuery, verifyurl);

            var fromEmail = new MailAddress("yassine.taktak@esprit.tn", "Yassine Taktak");
            var toEmail = new MailAddress("yassinetaktak9@gmail.com");

            var FromEmailPassword = "DJAPPA007";

            string subject = "EVALUATION UPDATE";

            string body = "The evaluation was successfuly updated";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, FromEmailPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true

            })
                smtp.Send(message);


            //envoyer mail


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

        public ActionResult stat()
        {
            Eval360Service rs = new Eval360Service();

            // var t = rs.GetReclamationbytype(TypeReclamation.Technique).Count();
            // var f = rs.GetReclamationbytype(TypeReclamation.Financiere).Count();
            // var rr = rs.GetReclamationbytype(TypeReclamation.Relationnelle).Count();
            var t = rs.GetEval360byavis("Bon").Count();
            var f= rs.GetEval360byavis("Moyen").Count();
           var r= rs.GetEval360byavis("Mauvais").Count();

            ViewBag.t = t;
            ViewBag.f = f;
            ViewBag.r = r;

            return View(rs.GetAll().ToList());

        }


    }
}
