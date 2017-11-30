using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.BO;
using Proyecto.DAO;
using System.IO;


namespace Proyecto.Controllers
{
    public class todo_proController : Controller
    {
        // GET: todo_pro
        loginDAO log = new loginDAO();
        usuarioDAO usuario_dao = new usuarioDAO();
        BackEndDAO Obj_back = new BackEndDAO();
        IndexDAO ObjIndex = new IndexDAO();

        public ActionResult IndexFinal()
        {
            return View(ObjIndex.Obtenerindex());
        }

        public ActionResult IndexPro()
        {
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
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(foto.InputStream))
                {
                    imageData = binaryReader.ReadBytes(foto.ContentLength);
                }
                //setear la imagen a la entidad que se creara
                cliente.foto = imageData;
            }
            if (ModelState.IsValid)
            {
                usuario_dao.guardar(cliente);

                return Redirect("~/VBackend/inicio");
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


                    return Redirect("~/usuariofron/puntos");

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
    }
}