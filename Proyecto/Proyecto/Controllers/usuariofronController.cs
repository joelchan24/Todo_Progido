using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.BO;
using Proyecto.DAO;
using Proyecto.Models;
using System.IO;

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
            ViewBag.nom = "pag";
            return View();
        }
        [HttpPost]
        public ActionResult Guardar_puntos([Bind(Include = "id_peligro,longitud,latitud,fecha,zona,comentario")]punto_peligrosoBO usu, HttpPostedFileBase imagen)
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];

            }
            if (imagen != null && imagen.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(imagen.InputStream))
                {
                    imageData = binaryReader.ReadBytes(imagen.ContentLength);
                }
                //setear la imagen a la entidad que se creara
                usu.imagen = imageData;
            }
            if (ModelState.IsValid)
            {
                var jjj = usu.id > 0 ?
                  pun.editar(usu) :
                  pun.Guardar(usu, ViewBag.usuario.id);

                return Redirect("~/usuariofron/puntos");
            }



            return View(usu);



          
        }

        //public ActionResult Guardar_puntos(punto_peligrosoBO usu)
        //{

        //    if (Session["usuario"] != null)
        //    {
        //        ViewBag.usuario = (usuarioBO)Session["usuario"];

        //    }
        //    var r = usu.id > 0 ?
        //        pun.editar(usu) :
        //        pun.Guardar(usu, ViewBag.usuario.id);



        //    return View();
        //}



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult IndexPro([Bind(Include = "nombre,apellido,correo,contraseña,telefono,fecha,sexo")] usuarioBO cliente, HttpPostedFileBase foto)
        //{
        //    if (foto != null && foto.ContentLength > 0)
        //    {
        //        byte[] imageData = null;
        //        using (var binaryReader = new BinaryReader(foto.InputStream))
        //        {
        //            imageData = binaryReader.ReadBytes(foto.ContentLength);
        //        }
        //        //setear la imagen a la entidad que se creara
        //        cliente.foto = imageData;
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        usuario_dao.guardar(cliente);

        //        return Redirect("~/VBackend/inicio");
        //    }

        //    return View(cliente);
        //}


        public ActionResult peligros()
        {
           peligros  viewModel = new peligros();
            viewModel.Peligrooooooo = pun.listartipo();
            return PartialView(viewModel);
        }
        public ActionResult puntos_generados()
        {
            
            return View(pun.aprovados());
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
        public ActionResult devolverchar()
        {
            return Json(pun.mandar_pie_char(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult eliminar(int id)
        {
            pun.eliminar(id);
            return Content("eliminado");
        }

        //seccion de contactos
    }
}