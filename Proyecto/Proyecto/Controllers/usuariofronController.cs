using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.BO;
using Proyecto.Models;
using Proyecto.DAO;

namespace Proyecto.Controllers
{
    public class usuariofronController : Controller
    {
        // GET: usuariofron
        punto_DAO pun = new punto_DAO();
        public ActionResult miscontactos()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View();
            }
            return View();
         
        }
        public ActionResult puntos()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View();
            }
    
            return View();
        }
        public ActionResult Guardar_puntos()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View();
            }

            return View();
        }
        public ActionResult peligros()
        {
            peligros viewModel = new peligros();
            viewModel.Peligro = pun.listartipo();
            return PartialView(viewModel);
        }
    }
}