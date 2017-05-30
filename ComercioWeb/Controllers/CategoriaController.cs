using System;
using System.Web.Mvc;
using AccesoDatos.Domain.Services;

namespace PlantillaComercio.Controllers
{
    public class CategoriaController : Controller
    {
        readonly CategoriaServicio _catServicio = new CategoriaServicio();
        // GET: Categoria
        public ActionResult Categoria()
        {
            ViewBag.Message = "Categoria";

            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ObtenerCategorias() {
            var result = _catServicio.ObtenerCategorias();
            var data = new { sucess = true, listaCategorias = result };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}