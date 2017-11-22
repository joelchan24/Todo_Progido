using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.DAO;
using Proyecto.BO;
using System.IO;
namespace Proyecto.Controllers
{
    public class VBackendController : Controller
    {
        // GET: VBackend
        BackEndDAO Obj = new BackEndDAO();
        loginDAO ObjLogin = new loginDAO();
        usuarioBO ObjusuarioBO = new usuarioBO();
        public ActionResult Vprueba()
        {
            return View();
        }
        public ActionResult EditarPerfilAdmin()
        {
            return View();
        }


        public ActionResult PerfilAdmin()
        {
            return View(ObjLogin.obtenerperfil());
        }

        public ActionResult convertirImagen()
        {
            var ImagenCliente = ObjLogin.obtnerfoto();
            return File(ImagenCliente.foto, "image/jpeg");
        }
        public ActionResult inicio()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View();
            }

            return View();
        }

        public ActionResult Vusuario()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View();
            }

            return View();
        }

        public ActionResult prueba()
        {
            return Redirect("~/VBackend/Vprueba");
        }

        public ActionResult VistaUsuario()
        {

            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View(ObjLogin.obtenerperfil());
            }
            return View(ObjLogin.obtenerperfil());
        }

       
    }
}