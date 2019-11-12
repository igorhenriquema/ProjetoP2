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
    public class PrecoesController : Controller
    {
        private dbProva2Entities db = new dbProva2Entities();

        // GET: Precoes
        public ActionResult Index()
        {
            var preco = db.Preco.Include(p => p.Material);
            return View(preco.ToList());
        }

        // GET: Precoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preco preco = db.Preco.Find(id);
            if (preco == null)
            {
                return HttpNotFound();
            }
            return View(preco);
        }

        // GET: Precoes/Create
        public ActionResult Create()
        {
            ViewBag.idMaterial = new SelectList(db.Material, "idMaterial", "descricao");
            return View();
        }

        // POST: Precoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPreco,idMaterial,preco1")] Preco preco)
        {
            if (ModelState.IsValid)
            {
                db.Preco.Add(preco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMaterial = new SelectList(db.Material, "idMaterial", "descricao", preco.idMaterial);
            return View(preco);
        }

        // GET: Precoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preco preco = db.Preco.Find(id);
            if (preco == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMaterial = new SelectList(db.Material, "idMaterial", "descricao", preco.idMaterial);
            return View(preco);
        }

        // POST: Precoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPreco,idMaterial,preco1")] Preco preco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMaterial = new SelectList(db.Material, "idMaterial", "descricao", preco.idMaterial);
            return View(preco);
        }

        // GET: Precoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preco preco = db.Preco.Find(id);
            if (preco == null)
            {
                return HttpNotFound();
            }
            return View(preco);
        }

        // POST: Precoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Preco preco = db.Preco.Find(id);
            db.Preco.Remove(preco);
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
