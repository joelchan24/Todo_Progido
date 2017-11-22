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
        ContactosDAO Obj = new ContactosDAO();

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
                return View(Obj.ObtenerContactos());
            }

            return View(Obj.ObtenerContactos());
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
        public ActionResult Guardar_puntos(usuarioBO usu)
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
              
            }
            var r = usu.id > 0 ?
                pun.editar(usu) :
                pun.Guardar(usu,ViewBag.usuario.id);
                /*   
            var i = pel.id > 0 ?
                 peli.modificar(pel) :
                 peli.agregar(pel);
            return View("listalum", peli.listar()); */

            return View();
        }
        public ActionResult peligros()
        {
           peligros  viewModel = new peligros();
            viewModel.Peligrooooooo = pun.listartipo();
            return PartialView(viewModel);
        }
       



        //seccion de contactos
    }
}