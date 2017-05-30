using System;
using System.Web.Mvc;
using AccesoDatos.Domain.Services;

namespace PlantillaComercio.Controllers
{
    public class UsuarioController : Controller
    {
        readonly UsuarioServicio _usarioServicio = new UsuarioServicio();
        public ActionResult Usuario()
        {
            ViewBag.Message = "Pais";

            return View();
        }

        public JsonResult ObtenerUsuarios()
        {
            try
            {
                var result = _usarioServicio.ObtenerUsuariosAbm();
                var data = new { sucess = true, listas = result };
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
