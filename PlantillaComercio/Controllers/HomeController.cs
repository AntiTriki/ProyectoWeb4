using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccesoDatos.Domain.Entities;
using AccesoDatos.Domain.Services;

namespace PlantillaComercio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categoria1()
        {
            ViewBag.Message = "Categoria 1";

            return View();
        }

        public ActionResult Categoria2()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult Upload()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(Server.MapPath("~/Temp/"), fileName);
                file.SaveAs(path);
            }
            var data = new { sucess = true};
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Prueba(string nota)
        {
            try
            {
                var notaVenta = ComunServicio.ObtenerDtoFromString<NotaDTO>(nota);

                var data = new { sucess = true };
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