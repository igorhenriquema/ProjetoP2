using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjProva2;

namespace ProjProva2.Controllers
{
    public class UnidadeMedidasController : Controller
    {
        private dbProva2Entities db = new dbProva2Entities();

        // GET: UnidadeMedidas
        public ActionResult Index()
        {
            return View(db.UnidadeMedida.ToList());
        }

        // GET: UnidadeMedidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeMedida unidadeMedida = db.UnidadeMedida.Find(id);
            if (unidadeMedida == null)
            {
                return HttpNotFound();
            }
            return View(unidadeMedida);
        }

        // GET: UnidadeMedidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnidadeMedidas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUnMedida,descricao")] UnidadeMedida unidadeMedida)
        {
            if (ModelState.IsValid)
            {
                db.UnidadeMedida.Add(unidadeMedida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unidadeMedida);
        }

        // GET: UnidadeMedidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeMedida unidadeMedida = db.UnidadeMedida.Find(id);
            if (unidadeMedida == null)
            {
                return HttpNotFound();
            }
            return View(unidadeMedida);
        }

        // POST: UnidadeMedidas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUnMedida,descricao")] UnidadeMedida unidadeMedida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidadeMedida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unidadeMedida);
        }

        // GET: UnidadeMedidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeMedida unidadeMedida = db.UnidadeMedida.Find(id);
            if (unidadeMedida == null)
            {
                return HttpNotFound();
            }
            return View(unidadeMedida);
        }

        // POST: UnidadeMedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnidadeMedida unidadeMedida = db.UnidadeMedida.Find(id);
            db.UnidadeMedida.Remove(unidadeMedida);
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
