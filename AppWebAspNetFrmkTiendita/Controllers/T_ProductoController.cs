using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AplicacionTiendita.Models;

namespace AppWebAspNetFrmkTiendita.Controllers
{
    public class T_ProductoController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: T_Producto
        public ActionResult Index()
        {
            var t_producto = db.t_producto.Include(t => t.categoria);
            return View(t_producto.ToList());
        }

        // GET: T_Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Producto t_Producto = db.t_producto.Find(id);
            if (t_Producto == null)
            {
                return HttpNotFound();
            }
            return View(t_Producto);
        }

        // GET: T_Producto/Create
        public ActionResult Create()
        {
            ViewBag.codcat = new SelectList(db.t_categoria, "codcat", "nomcat");
            return View();
        }

        // POST: T_Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codpro,nompro,despro,prepro,canpro,estpro,codcat")] T_Producto t_Producto)
        {
            if (ModelState.IsValid)
            {
                db.t_producto.Add(t_Producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codcat = new SelectList(db.t_categoria, "codcat", "nomcat", t_Producto.codcat);
            return View(t_Producto);
        }

        // GET: T_Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Producto t_Producto = db.t_producto.Find(id);
            if (t_Producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.codcat = new SelectList(db.t_categoria, "codcat", "nomcat", t_Producto.codcat);
            return View(t_Producto);
        }

        // POST: T_Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codpro,nompro,despro,prepro,canpro,estpro,codcat")] T_Producto t_Producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codcat = new SelectList(db.t_categoria, "codcat", "nomcat", t_Producto.codcat);
            return View(t_Producto);
        }

        // GET: T_Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Producto t_Producto = db.t_producto.Find(id);
            if (t_Producto == null)
            {
                return HttpNotFound();
            }
            return View(t_Producto);
        }

        // POST: T_Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Producto t_Producto = db.t_producto.Find(id);
            db.t_producto.Remove(t_Producto);
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
