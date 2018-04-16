using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.BO;
using Proyecto.DAO;
using System.IO;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;


namespace Proyecto.Controllers
{
    public class todo_proController : Controller
    {
        // GET: todo_pro
        loginDAO log = new loginDAO();
        usuarioDAO usuario_dao = new usuarioDAO();
        BackEndDAO Obj_back = new BackEndDAO();
        IndexDAO ObjIndex = new IndexDAO();
        punto_DAO pun = new punto_DAO();

        public ActionResult IndexFinal()
        {
            ViewBag.usuario = (usuarioBO)Session["usuario"];


            if (Session["usuario"] == null)
            {
                return View(ObjIndex.Obtenerindex());
            }
            else if (Session["usuario"] != null & ViewBag.usuario.id_tipo == 2)
            {
                return Redirect("~/VBackend/estadisticas");
            }
            else if (Session["usuario"] != null & ViewBag.usuario.id_tipo == 1)
            {
                return Redirect("~/usuariofron/mis_puntos");
            }
            return View(ObjIndex.Obtenerindex());
        }

        public ActionResult IndexPro()
        {
            ViewBag.usuario = (usuarioBO)Session["usuario"];
            if (Session["usuario"] == null)
            {
                return View();
            }
            if (Session["usuario"] != null & ViewBag.usuario.id_tipo == 2)
            {
                return Redirect("~/VBackend/estadisticas");
            }
            else if (Session["usuario"] != null & ViewBag.usuario.id_tipo == 1)
            {
                return Redirect("~/usuariofron/mis_puntos");
            }
            return View();
        }



        public ActionResult vacio()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View();
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IndexPro([Bind(Include = "nombre,apellido,correo,contraseña,telefono,fecha,sexo")] usuarioBO cliente, HttpPostedFileBase foto)
        {
            if (foto != null && foto.ContentLength > 0)
            {
               
                //cliente.foto = imageData;
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
                    cliente.foto = uploadResult.SecureUri.ToString();
                    usuario_dao.guardar(cliente);
                    return Redirect("~/todo_pro/IndexFinal");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    cliente.foto = "https://res.cloudinary.com/dyhowxkye/image/upload/v1523834686/%C3%ADndice.jpg";
                    usuario_dao.guardar(cliente);
                    return Redirect("~/todo_pro/IndexFinal");
                }
            }
          

            return View(cliente);
        }








        public ActionResult cerrar()
        {
            Session.Remove("usuario");
            Session.Abandon();
            return Redirect("~/todo_pro/IndexFinal");
        }
        public ActionResult registro()
        {

            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View();
            }
            return View();
        }
      
        public ActionResult login(usuarioBO usuario)
        {
            if (log.verificar(usuario))
            {
                var i = log.buscarelid(usuario);

                Response.Write("<script>alert('usuario correcto')</script>");
                usuarioBO usu = log.obtener(usuario.nombre, usuario.contraseña);
                Session["usuario"] = usu;
                
                if (i == 1)
                {


                    return Redirect("~/usuariofron/mis_puntos");

                }
                else if (i == 2)
                {
                    return Redirect("~/VBackend/estadisticas");
                }
                            

            }
           
        return Redirect("~/todo_pro/indexPro");
            

            
      
        }


        public ActionResult obtenerbanner()
        {
            var Imagenbaner = ObjIndex.Obtenerindex();
            return File(Imagenbaner.imagenbanner, "image/jpeg");
        }


        public ActionResult obtenern1()
        {
            var Imagenbaner = ObjIndex.Obtenerindex();
            return File(Imagenbaner.foto1, "image/jpeg");
        }

        public ActionResult obtenern2()
        {
            var Imagenbaner = ObjIndex.Obtenerindex();
            return File(Imagenbaner.foto2, "image/jpeg");
        }

        public ActionResult obtenern3()
        {
            var Imagenbaner = ObjIndex.Obtenerindex();
            return File(Imagenbaner.foto3, "image/jpeg");
        }

        public ActionResult obtenerder()
        {
            var Imagenbaner = ObjIndex.Obtenerindex();
            return File(Imagenbaner.imagenderecha, "image/jpeg");
        }

        public ActionResult obtenerizq()
        {
            var Imagenbaner = ObjIndex.Obtenerindex();
            return File(Imagenbaner.imagenizquierda, "image/jpeg");
        }

        public ActionResult devolverpuntos()
        {
            return Json(pun.mandaedatosindex(), JsonRequestBehavior.AllowGet);
        }
    }
}