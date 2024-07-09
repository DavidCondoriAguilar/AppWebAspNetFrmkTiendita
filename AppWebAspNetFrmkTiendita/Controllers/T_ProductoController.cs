using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using AplicacionTiendita.Models;

namespace AppWebAspNetFrmkTiendita.Controllers
{
    public class T_ProductoController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: T_Producto
        public ActionResult Index(string searchString, int? page)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1);

            var t_producto = db.t_producto.Include(t => t.categoria);

            // Aplicar búsqueda por nombre si existe
            if (!String.IsNullOrEmpty(searchString))
            {
                t_producto = t_producto.Where(p => p.nompro.Contains(searchString));
            }

            // Aplicar ordenamiento
            t_producto = t_producto.OrderBy(p => p.nompro);

            // Convertir a IPagedList
            IPagedList<T_Producto> pagedProductos = t_producto.ToPagedList(pageNumber, pageSize);

            ViewBag.CurrentFilter = searchString;

            return View(pagedProductos);
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
