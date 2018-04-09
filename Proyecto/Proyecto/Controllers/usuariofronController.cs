using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.BO;
using Proyecto.DAO;
using Proyecto.Models;
using System.IO;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Proyecto.Controllers
{
    public class usuariofronController : Controller
    {

        punto_DAO pun = new punto_DAO();
        ContactosDAO Obj = new ContactosDAO();
        loginDAO objlogin = new loginDAO();
        usuarioDAO objeditar = new usuarioDAO();
        loginDAO log = new loginDAO();
        usuarioBO usuario = new usuarioBO();

        public ActionResult editar_datos()
        {
            ViewBag.usuario = (usuarioBO)Session["usuario"];
            

           
            if (Session["usuario"] == null )
            {
                return Redirect("~/todo_pro/IndexFinal");
            }
            else if (Session["usuario"] != null & ViewBag.usuario.id_tipo == 1)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
            }
            else if (Session["usuario"] != null & ViewBag.usuario.id_tipo == 2)
            {
                return Redirect("~/VBackend/estadisticas");
            }
            return View(objlogin.obtenerperfil_usuario(ViewBag.usuario.id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editar_datos([Bind(Include = "id,nombre,apellido,correo,telefono,mensajecontacto1,sexo,contraseña")]usuarioBO usu, HttpPostedFileBase foto)
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];

                if (foto != null && foto.ContentLength > 0)
                {
                   
                    //usu.foto = imageData;
                    if (ModelState.IsValid)
                    {
                        Account account = new Account(
                         "dyhowxkye",
                         "739723474219958",
                         "jQttMABV1zBRO8jkQ3_FAiRhkrE"
                         );
                        Cloudinary cloud = new Cloudinary(account);
                        var upload = new ImageUploadParams()
                        {
                            File = new FileDescription("Foto", foto.InputStream)
                        };
                        var uploadResult = cloud.Upload(upload);
                        usu.foto = uploadResult.SecureUri.ToString();
                        objeditar.editar(usu, ViewBag.usuario.id, usu.mensajecontacto1);
                        return Redirect("~/usuariofron/editar_datos");
                    }
                }
                else
                {
                    if(ModelState.IsValid)
                    {
                        objeditar.editarsinf(usu, ViewBag.usuario.id, usu.mensajecontacto1);
                        return Redirect("~/usuariofron/editar_datos");
                    }
                  
                }

            }
            else
            {
                return Redirect("~/todo_pro/IndexFinal");
            }
            return View(usu);    
        }



        public ActionResult puntos()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
               
            }
            return View();
        }

        public ActionResult CrearIncidencias()
        {
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

        public ActionResult puntos_usuario()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];

            }
            ViewBag.da = 1;
            return View();
        }
        public ActionResult mis_puntos()
        {
            ViewBag.usuario = (usuarioBO)Session["usuario"];

            if (Session["usuario"] == null)
            {
                return Redirect("~/todo_pro/IndexFinal");
            }
            else if  (Session["usuario"] != null & ViewBag.usuario.id_tipo == 2){
                return Redirect("~/VBackend/estadisticas"); 
            }
            else if (Session["usuario"] != null & ViewBag.usuario.id_tipo == 1)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
            }
           
            return View();
        } 
        
        public ActionResult Guardar_puntos(int id, int longitud, int latitud, string zona, string comentario, HttpPostedFileBase imagen )
        {
            punto_peligrosoBO usu = new punto_peligrosoBO();
            //string comentario, FormCollection frm, HttpPostedFileBase imagen



            if (Session["usuario"] != null)
            {
                //ViewBag.usuario = (usuarioBO)Session["usuario"];
                //usu.id_peligro = int.Parse(frm["Gender"].ToString());
                if (imagen != null && imagen.ContentLength > 0)
                {
                    Account account = new Account(
                     "dyhowxkye",
                     "739723474219958",
                     "jQttMABV1zBRO8jkQ3_FAiRhkrE"
                     );
                    Cloudinary cloud = new Cloudinary(account);
                    var upload = new ImageUploadParams()
                    {
                        File = new FileDescription("Foto", imagen.InputStream)
                    };
                    var uploadResult = cloud.Upload(upload);
                    usu.imagen = uploadResult.SecureUri.ToString();

                    if (ModelState.IsValid)
                    {
                        var jjj = usu.id > 0 ?
                          pun.editar(usu) :
                          pun.Guardar(usu, ViewBag.usuario.id);

                        return Redirect("~/usuariofron/Tablapuntousuario");
                    }
                }
                //else
                //{
                //    usu.imagen = "https://res.cloudinary.com/dyhowxkye/image/upload/v1521322391/image_placeholder.jpg";
                //    if (ModelState.IsValid)
                //    {
                //        var jjj = usu.id > 0 ?
                //          pun.editar(usu) :
                //          pun.Guardar(usu, ViewBag.usuario.id);

                //        return Redirect("~/usuariofron/Tablapuntousuario");
                //    }
                //}
            }
            return View(comentario);





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

        public ActionResult otrosdevolver()
        {
            return Json(pun.mandaedatosotros(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult d4()
        {
            return Json(pun.mandaedatos4(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult d5()
        {
            return Json(pun.mandaedatos5(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult d6()
        {
            return Json(pun.mandaedatos6(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult d7()
        {
            return Json(pun.mandaedatos7(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult d8()
        {
            return Json(pun.mandaedatos8(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult d9()
        {
            return Json(pun.mandaedatos9(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult d10()
        {
            return Json(pun.mandaedatos10(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult devolverpuntos_personales()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];

            }
            return Json(pun.mandaedatos__personales(ViewBag.usuario.id), JsonRequestBehavior.AllowGet);
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

        public ActionResult CrearPuntos()
        {
            ViewBag.usuario = (usuarioBO)Session["usuario"];

            if (Session["usuario"] == null)
            {
                return Redirect("~/todo_pro/IndexFinal");
            }
            else if (Session["usuario"] != null & ViewBag.usuario.id_tipo == 2)
            {
                return Redirect("~/VBackend/estadisticas");
            }
            else if (Session["usuario"] != null & ViewBag.usuario.id_tipo == 1)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
            }
            return View();
        }
        public ActionResult Imagen_usuario(int id)
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];

            }

            var imagenCliente = pun.Obtener_usuario_normal(id);
            return File(imagenCliente.foto, "image/jpeg");
        }
        //seccion de contactos

        public ActionResult Tablapuntousuario()
        {
            ViewBag.usuario = (usuarioBO)Session["usuario"];

            if (Session["usuario"] == null)
            {
                return Redirect("~/todo_pro/IndexFinal");
            }
            else if (Session["usuario"] != null & ViewBag.usuario.id_tipo == 2)
            {
                return Redirect("~/VBackend/estadisticas");
            }
            else if (Session["usuario"] != null & ViewBag.usuario.id_tipo == 1)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
            }
            return View(pun.CargarTablausuario(ViewBag.usuario.id));
        }


        public ActionResult cambioest()
        {
            
            return Redirect("~/ usuariofron / editar_datos");
        }

  

        public ActionResult cerrar_sesion()
        {
            Session.Remove("usuario");
            return Redirect("~/todo_pro/IndexFinal");


        }

        public ActionResult Incidencias()
        {
            return View();
        }

    }
}