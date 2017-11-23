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

        public ActionResult miscontactos(/*int id=0*/)
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View(Obj.ObtenerContactos());
            }
            //return View(id == 0 ? new usuarioBO() : Obj.Obtener(id));

            return View(Obj.ObtenerContactos());
        }
        // esto
        //public ActionResult Editar(int id = 0)
        //{
        //    return View(id == 0 ? new usuarioBO() : Obj.Obtener(id));
        //}

        //public ActionResult Guardar2(usuarioBO obj)
        //{
        //    var r = obj.idcontacto > 0 ?
        //      Obj.ModificarContactos(obj) :
        //    Obj.ModificarContactos(obj);


        //    return Redirect("~/usuariofron/miscontactos");
        //}
        ////aqui
        public ActionResult mis_puntos()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
               
            }
            ViewBag.mapa = pun.mandaedatos();
            return View();
        }
        public ActionResult Guardar_puntos(punto_peligrosoBO usu)
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
              
            }
            var r = usu.id > 0 ?
                pun.editar(usu) :
                pun.Guardar(usu, ViewBag.usuario.id);
                  
        

            return View();
        }
        public ActionResult peligros()
        {
           peligros  viewModel = new peligros();
            viewModel.Peligrooooooo = pun.listartipo();
            return PartialView(viewModel);
        }
        public ActionResult puntos_generados()
        {
            
            return View(pun.listar_eventos_con_peligro());
        }
        public ActionResult puntos_eliminar_act()
        {
           
            return View();
        }
        public ActionResult parcial()
        {

            return PartialView(pun.listar_eventos_con_peligro());
        }
        public ActionResult mensajes()
        {

            return View();
        }

        public ActionResult devolverpuntos()
        {
            return Json(pun.mandaedatos(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult eliminar(int id)
        {
            pun.eliminar(id);
            return Content("eliminado");
        }

        //seccion de contactos
    }
}