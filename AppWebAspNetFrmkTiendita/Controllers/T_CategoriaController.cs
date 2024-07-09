using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AplicacionTiendita.Models;
using PagedList;

namespace AppWebAspNetFrmkTiendita.Controllers
{
    public class T_CategoriaController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: T_Categoria
        public ActionResult Index(string searchString, int? page)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1);

            var categorias = from c in db.t_categoria
                             select c;

            // Aplicar búsqueda por nombre si existe
            if (!String.IsNullOrEmpty(searchString))
            {
                categorias = categorias.Where(c => c.nomcat.Contains(searchString));
            }

            // Aplicar ordenamiento
            categorias = categorias.OrderBy(c => c.nomcat);

            // Convertir a IPagedList
            IPagedList<T_Categoria> pagedCategorias = categorias.ToPagedList(pageNumber, pageSize);

            ViewBag.CurrentFilter = searchString;

            return View(pagedCategorias);
        }



        // GET: T_Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Categoria t_Categoria = db.t_categoria.Find(id);
            if (t_Categoria == null)
            {
                return HttpNotFound();
            }
            return View(t_Categoria);
        }

        // GET: T_Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Categoria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codcat,nomcat,estcat")] T_Categoria t_Categoria)
        {
            if (ModelState.IsValid)
            {
                db.t_categoria.Add(t_Categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Categoria);
        }

        // GET: T_Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Categoria t_Categoria = db.t_categoria.Find(id);
            if (t_Categoria == null)
            {
                return HttpNotFound();
            }
            return View(t_Categoria);
        }

        // POST: T_Categoria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codcat,nomcat,estcat")] T_Categoria t_Categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Categoria);
        }

        // GET: T_Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Categoria t_Categoria = db.t_categoria.Find(id);
            if (t_Categoria == null)
            {
                return HttpNotFound();
            }
            return View(t_Categoria);
        }

        // POST: T_Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Categoria t_Categoria = db.t_categoria.Find(id);
            db.t_categoria.Remove(t_Categoria);
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
