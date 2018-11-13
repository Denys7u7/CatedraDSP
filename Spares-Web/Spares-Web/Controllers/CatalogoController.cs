using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spares_Web.Models;

namespace Spares_Web.Controllers
{
    public class CatalogoController : Controller
    {
        // GET: Catalogo
        ProductoDAL _productos = new ProductoDAL();
        public ActionResult Index()
        {
            ViewBag.ListaProducto = _productos.Catalogo().ToList();
            return View();
        }
    }
}