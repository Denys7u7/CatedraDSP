using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Avance.Models;
using System.Data.Entity;

namespace Avance.Controllers
{
    public class ProductosController : Controller
    {
        SparesDSPEntities db = new SparesDSPEntities();
        // GET: Productos
        public ActionResult Index()
        {
            return View(db.producto.ToList<producto>());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            var query = (from A in db.producto
                        where A.id == id
                        select A).Single();

            return View((producto)query);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        public ActionResult Create(producto objProducto)
        {
            try
            {
                // TODO: Add insert logic here
                db.Entry(objProducto).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            var query = (from A in db.producto
                         where A.id == id
                         select A).Single();

            return View((producto)query);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        public ActionResult Edit(producto objProducto)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View();
                }
                db.Entry(objProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            var query = (from A in db.producto
                         where A.id == id
                         select A).Single();

            return View((producto)query);
        }

        // POST: Productos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, producto objproducto)
        {
            try
            {
                // TODO: Add delete logic here
                var query = (from A in db.producto
                             where A.id == id
                             select A).Single();
                objproducto = (producto)query;
                db.Entry(objproducto).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
