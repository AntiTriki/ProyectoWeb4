using System;
using System.Web.Mvc;
using AccesoDatos.Domain.Services;

namespace PlantillaComercio.Controllers
{
    public class PaisController : Controller
    {
        readonly PaisServicio _paisServicio = new PaisServicio();

        public ActionResult Pais()
        {
            ViewBag.Message = "Pais";

            return View();
        }

        public JsonResult GuardarPais(string nombre, string descripcion, int idPais = 0)
        {
            try
            {
                var result = _paisServicio.GuardarPais(nombre, descripcion, idPais);
                var data = new { sucess = true, idPais = result };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var data = new { sucess = false, mensaje = ex.Message };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult EliminarPais(int idPais)
        {
            try
            {
                _paisServicio.EliminarPais(idPais);
                var data = new { sucess = true, mensaje = "OK" };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var data = new { sucess = false, mensaje = ex.Message };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerPaises()
        {
            try
            {
                var result = _paisServicio.ObtenerPaises();
                var data = new { sucess = true, listaPaises = result };
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
