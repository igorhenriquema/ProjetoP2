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
    public class PedidoComprasController : Controller
    {
        private dbProva2Entities db = new dbProva2Entities();

        // GET: PedidoCompras
        public ActionResult Index()
        {
            var pedidoCompra = db.PedidoCompra.Include(p => p.Fornecedor).Include(p => p.Material);
            return View(pedidoCompra.ToList());
        }

        // GET: PedidoCompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoCompra pedidoCompra = db.PedidoCompra.Find(id);
            if (pedidoCompra == null)
            {
                return HttpNotFound();
            }
            return View(pedidoCompra);
        }

        // GET: PedidoCompras/Create
        public ActionResult Create()
        {
            ViewBag.idFornecedor = new SelectList(db.Fornecedor, "idFornecedor", "nomeFornecedor");
            ViewBag.idMaterial = new SelectList(db.Material, "idMaterial", "descricao");
            return View();
        }

        // POST: PedidoCompras/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPedCompra,idMaterial,idFornecedor,quantidade")] PedidoCompra pedidoCompra)
        {
            if (ModelState.IsValid)
            {
                db.PedidoCompra.Add(pedidoCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFornecedor = new SelectList(db.Fornecedor, "idFornecedor", "nomeFornecedor", pedidoCompra.idFornecedor);
            ViewBag.idMaterial = new SelectList(db.Material, "idMaterial", "descricao", pedidoCompra.idMaterial);
            return View(pedidoCompra);
        }

        // GET: PedidoCompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoCompra pedidoCompra = db.PedidoCompra.Find(id);
            if (pedidoCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFornecedor = new SelectList(db.Fornecedor, "idFornecedor", "nomeFornecedor", pedidoCompra.idFornecedor);
            ViewBag.idMaterial = new SelectList(db.Material, "idMaterial", "descricao", pedidoCompra.idMaterial);
            return View(pedidoCompra);
        }

        // POST: PedidoCompras/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPedCompra,idMaterial,idFornecedor,quantidade")] PedidoCompra pedidoCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidoCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFornecedor = new SelectList(db.Fornecedor, "idFornecedor", "nomeFornecedor", pedidoCompra.idFornecedor);
            ViewBag.idMaterial = new SelectList(db.Material, "idMaterial", "descricao", pedidoCompra.idMaterial);
            return View(pedidoCompra);
        }

        // GET: PedidoCompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoCompra pedidoCompra = db.PedidoCompra.Find(id);
            if (pedidoCompra == null)
            {
                return HttpNotFound();
            }
            return View(pedidoCompra);
        }

        // POST: PedidoCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PedidoCompra pedidoCompra = db.PedidoCompra.Find(id);
            db.PedidoCompra.Remove(pedidoCompra);
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
