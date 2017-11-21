using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.BO;
using Proyecto.Models;
using Proyecto.DAO;
using System.Data;

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
        public ActionResult Guardar_puntos(punto_peligrosoBO puntos)
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                
            }
            var r = puntos.id > 0 ?
                pun.editar(puntos) :
                pun.Guardar(puntos, ViewBag.usuario.id);


            return View();
        }
        public ActionResult peligros()
        {
            peligros viewModel = new peligros();
            ConexionDAO Conexion = new ConexionDAO();
            viewModel.Peligrooooooo = pun.listartipo();
            return PartialView(viewModel);
        }
        public ActionResult mis_puntos()
        {
           
            ViewBag.mapa = pun.mandaedatos(); 
            ViewData["datos"] =pun.mandaedatos();
            return View();
        }

        public ActionResult devolverpuntos()
        {
            return Json(pun.mandaedatos(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult mandar()
        {
           




            return Redirect("~/usuariofron/mis_puntos");
        }
    }
}