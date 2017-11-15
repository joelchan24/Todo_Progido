using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.DAO;

namespace Proyecto.Controllers
{
    public class VBackendController : Controller
    {
        // GET: VBackend
        BackEndDAO Obj = new BackEndDAO();
        public ActionResult Vprueba()
        {
            return View(Obj.ObtenerDatosIndex());
        }
        public ActionResult usuario()
        {
            return View();
        }
    }
}