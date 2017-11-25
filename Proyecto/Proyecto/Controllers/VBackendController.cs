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
        IndexDAO Obj_indexdao = new IndexDAO();
        tipo_peligroDAO peligrodao = new tipo_peligroDAO();
        public ActionResult Vprueba()
        {
            return View();
        }
    
             public ActionResult tiposdepeligro()
        {
            return View();
        }
        public ActionResult guardar_peligro(PeligroBO peli)
        {
            var r = peli.id > 0 ?
                peligrodao.editar(peli) :
                peligrodao.Guardar(peli);

            return Redirect("~/VBackend/tiposdepeligro");
        }
        public ActionResult Borrar_peligro(int id)
        {
            peligrodao.eliminar(id);

            return Content("hecho");
        }
        public ActionResult EditarPerfilAdmin()
        {
            return View();
        }
        public ActionResult estadisticas()
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
        public ActionResult parcial_peligros()
        {

            return PartialView(peligrodao.peligros());
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

        public ActionResult ListaDePuntosM()
        {
            return View();
        }

        public ActionResult ConfiguracionIndex()
        {
            return View(Obj_indexdao.Obtenerindex());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Guardarimagenbanner( HttpPostedFileBase imagenbanner)
        {
            usuarioBO cliente = new usuarioBO();
            if (imagenbanner != null && imagenbanner.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(imagenbanner.InputStream))
                {
                    imageData = binaryReader.ReadBytes(imagenbanner.ContentLength);
                }
                //setear la imagen a la entidad que se creara
                cliente.imagenbanner = imageData;
            }
            if (ModelState.IsValid)
            {
                Obj_indexdao.GuardarImagen(cliente);

                return Redirect("~/ VBackend / ConfiguracionIndex");
            }

            return View(cliente);
        }
        [HttpPost,ValidateInput(false)]
        public ActionResult Guardarpresentacion(usuarioBO obj)
        {
            
            Obj_indexdao.Guardarpre(obj);
            return Redirect("~/ VBackend / ConfiguracionIndex");
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Guardarizquierda(usuarioBO obj)
        {

            Obj_indexdao.Guardarizquierda(obj);
            return Redirect("~/ VBackend / ConfiguracionIndex");
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Guardarderecha(usuarioBO obj)
        {

            Obj_indexdao.Guardarderecha(obj);
            return Redirect("~/ VBackend / ConfiguracionIndex");
         
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult in1(usuarioBO obj)
        {

            Obj_indexdao.integrante1(obj);
            return Redirect("~/ VBackend / ConfiguracionIndex");

        }

        [HttpPost, ValidateInput(false)]
        public ActionResult in2(usuarioBO obj)
        {
            Obj_indexdao.integrante2(obj);
            return Redirect("~/ VBackend / ConfiguracionIndex");
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult in3(usuarioBO obj)
        {
            Obj_indexdao.integrante3(obj);
            return Redirect("~/ VBackend / ConfiguracionIndex");
        }

    }
}