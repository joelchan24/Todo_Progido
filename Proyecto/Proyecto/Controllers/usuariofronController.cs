using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.BO;
using Proyecto.DAO;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class usuariofronController : Controller
    {

        punto_DAO pun = new punto_DAO();
        
        public ActionResult puntos()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
             
            }
            return View();
        }
        public ActionResult miscontactos()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View();
            }
            return View();
        }
        public ActionResult mis_puntos()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
               
            }
            ViewBag.mapa = pun.mandaedatos();
            return View();
        }
        public ActionResult guardar()
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
           peligros  viewModel = new peligros();
            viewModel.Peligrooooooo = pun.listartipo();
            return PartialView(viewModel);
        }
    }
}