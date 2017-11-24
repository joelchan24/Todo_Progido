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
        punto_DAO objpunto = new punto_DAO();
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

        public ActionResult Backud()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View();
            }

            return View();
        }

        public ActionResult Actividad()
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
        public ActionResult aprovados()
        {

            return View();
        }
        public ActionResult no_aprovados()
        {

            return View();
        }
        public ActionResult parcial_aprovados()
        {

            return PartialView(objpunto.aprovados());
        }
        public ActionResult parcial_no_aprovados()
        {


            return PartialView(objpunto.listar_eventos_con_peligro_noaprovados());
        }
        public ActionResult Actualizar_apro(int id)
        {
            objpunto.actaulzar_apro(id);

            return Content("hecho");
        }
        public ActionResult actualizar_no(int id)
        {
            objpunto.actaulzar_noapro(id);

            return Content("hecho");
        }

    }
}