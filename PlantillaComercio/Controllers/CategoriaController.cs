using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccesoDatos.Domain.Services;

namespace PlantillaComercio.Controllers
{
    public class CategoriaController : Controller
    {

        private readonly CategoriaServicio _catServicio = new CategoriaServicio();
        // GET: Categoria
        public ActionResult Categoria()
        {
            ViewBag.Message = "Categoria";

            return View();
        }

        public ActionResult Prueba()
        {
            ViewBag.Message = "Categoria";

            return View();
        }

        public ActionResult Categoria1()
        {
            ViewBag.Message = "Categoria zxdsdf";

            return View();
        }

        public JsonResult ObtenerCategorias()
        {
            //var result = _catServicio.ObtenerCategorias();
            //var data = new { sucess = true, listaCategorias = result };
            //return Json(data, JsonRequestBehavior.AllowGet);
            try
            {
                var result = _catServicio.ObtenerCategorias();
                var data = new { sucess = true, listaCategorias = result };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var data = new { sucess = false, mensaje = ex.Message };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

    }
}