using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.DAO;
using Proyecto.BO;
using System.IO;
using Microsoft.Reporting.WebForms;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Proyecto.Reportes;
using Proyecto.Models;
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
        mensajeDAO obj_mensaje = new mensajeDAO();
        public ActionResult Vprueba()
        {
            return View();
        }
        public ActionResult mensajes()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];

            }
            return View();
        }
        public ActionResult guardar_mensaje(mensajeBO mensaje)
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
    
            }
            obj_mensaje.Guardar(mensaje, ViewBag.usuario.id);
            return View();
        }
        
        public ActionResult Mapa_admin()
        {
            return View();
        }
        public ActionResult listadeusuarios()
        {
            return View();
        }
        public ActionResult buzon_de_sugerencias()
        {
            return View();
        }
        public ActionResult reporte_usuarios()
        {
            usuarios dataset_usuarios = new usuarios();
            ReportViewer reporte = new ReportViewer();
            reporte.ProcessingMode = ProcessingMode.Local;
            reporte.SizeToReportContent = true;
            string consulta = " select count( distinct estatus)  as total,count(  estatus)  as total1   from [Puntos-peligrosos]  where  Estatus=0";
            ConexionDAO cone = new ConexionDAO();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, cone.establecerConexion());
            adaptador.Fill(dataset_usuarios, "datos");
            reporte.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes/usuarios1.rdlc";
            reporte.LocalReport.DataSources.Add(new ReportDataSource("usuarios", dataset_usuarios.Tables[0]));
            ViewBag.repo = reporte;
          
            return View();
        }

        public ActionResult tiposdepeligro()
        {
            return View();
        }
       Proyecto.Reportes.peligros daset_reportes = new Proyecto.Reportes.peligros();
        //ReportViewer reporte = new ReportViewer();
        ////reporte.ProcessingMode = ProcessingMode.Local;
        //    reporte.SizeToReportContent = true;
        //    //reporte.Width = Unit.Percentage(900);
        //    //reporte.Height = Unit.Percentage(900);
        //    ConexionDAO cone = new ConexionDAO();
        //string instrucción = "select id,cliente,monto,tasa,plazo,fecha_inicio from prestamo";
        //SqlDataAdapter adaptador = new SqlDataAdapter(instrucción, cone.establecerConexion());
        ////ds.Tables.Add(sistema1.mostrar());
        //adaptador.Fill(ds, "prestamo1");
            
        //    reporte.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"reportes/Report1.rdlc";
        //    reporte.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ds.Tables[0]));
        //    ViewBag.reporte12 = reporte;
        //    return View();
        public ActionResult Reporte_peligros()
        {
            ReportViewer reporte = new ReportViewer();
            reporte.ProcessingMode = ProcessingMode.Local;
            reporte.SizeToReportContent = true;
            string consulta = "select n.Peligro as peligro , count( n.Peligro) as total from [Puntos-peligrosos] p inner join [niveles-peligro] n on n.ID=p.id_peligro   GROUP BY n.Peligro";
            ConexionDAO cone = new ConexionDAO();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, cone.establecerConexion());
            adaptador.Fill(daset_reportes, "peligros1");
            reporte.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes/peligros.rdlc";
            reporte.LocalReport.DataSources.Add(new ReportDataSource("peligros", daset_reportes.Tables[0]));
            ViewBag.repo = reporte;
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
       
        public ActionResult estadisticas()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View();
            }
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
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View();
            }
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
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View();
            }

            return View();
        }
        public ActionResult no_aprovados()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View();
            }

            return View();
        }
        public ActionResult parcial_peligros()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View();
            }

            return PartialView(peligrodao.peligros());
        }
        public ActionResult parcial_aprovados()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View();
            }

            return PartialView(objpunto.aprovados());
        }
        public ActionResult parcial_no_aprovados()
        {


            return PartialView(objpunto.listar_eventos_con_peligro_noaprovados());
        }
        public ActionResult parcia_drop_usuarios()
        {
            usuarios_modelo viewModel = new usuarios_modelo();
            viewModel.usuarios = objpunto.listartipo_usuarios();
            return PartialView(viewModel);

           
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
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View();
            }
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

        

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult in1([Bind(Include = "nom1,rol1,r1,re1,red1")]usuarioBO integrante1, HttpPostedFileBase foto1)
        {
            if (foto1 != null && foto1.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(foto1.InputStream))
                {
                    imageData = binaryReader.ReadBytes(foto1.ContentLength);
                }
                //setear la imagen a la entidad que se creara
                integrante1.foto1 = imageData;
            }
            
            Obj_indexdao.integrante1(integrante1);
            return Redirect("~/ VBackend / ConfiguracionIndex");
            

       
       

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult in2([Bind(Include = "nom2,rol2,r2,re2,red2")]usuarioBO obj, HttpPostedFileBase foto2)
        {
            if (foto2 != null && foto2.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(foto2.InputStream))
                {
                    imageData = binaryReader.ReadBytes(foto2.ContentLength);
                }
                //setear la imagen a la entidad que se creara
                obj.foto2 = imageData;
            }
           
            Obj_indexdao.integrante2(obj);
            return Redirect("~/ VBackend / ConfiguracionIndex");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult in3([Bind(Include = "nom3,rol3,r3,re3,red3")]usuarioBO obj, HttpPostedFileBase foto3)
        {
            if (foto3 != null && foto3.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(foto3.InputStream))
                {
                    imageData = binaryReader.ReadBytes(foto3.ContentLength);
                }
                //setear la imagen a la entidad que se creara
                obj.foto3 = imageData;
            }
         
            Obj_indexdao.integrante3(obj);
            return Redirect("~/ VBackend / ConfiguracionIndex");
        }

        public ActionResult obtenerbanner()
        {
            var Imagenbaner = Obj_indexdao.Obtenerindex();
            return File(Imagenbaner.imagenbanner, "image/jpeg");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult imagenizquierdasave(HttpPostedFileBase imagenizquierda)
        {
            usuarioBO cliente = new usuarioBO();
            if (imagenizquierda != null && imagenizquierda.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(imagenizquierda.InputStream))
                {
                    imageData = binaryReader.ReadBytes(imagenizquierda.ContentLength);
                }
                //setear la imagen a la entidad que se creara
                cliente.imagenizquierda = imageData;
            }
            if (ModelState.IsValid)
            {
                Obj_indexdao.Guardarizque(cliente);

                return Redirect("~/ VBackend / ConfiguracionIndex");
            }

            return View(cliente);
        }

        public ActionResult obtenerizque()
        {
            var Imagenbaner = Obj_indexdao.Obtenerindex();
            return File(Imagenbaner.imagenizquierda, "image/jpeg/png");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult imagenderechasave(HttpPostedFileBase imagenderecha)
        {
            usuarioBO cliente = new usuarioBO();
            if (imagenderecha != null && imagenderecha.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(imagenderecha.InputStream))
                {
                    imageData = binaryReader.ReadBytes(imagenderecha.ContentLength);
                }
                //setear la imagen a la entidad que se creara
                cliente.imagenderecha = imageData;
            }
            if (ModelState.IsValid)
            {
                Obj_indexdao.Guardardere(cliente);

                return Redirect("~/ VBackend / ConfiguracionIndex");
            }

            return View(cliente);
        }

        public ActionResult obtenerdere()
        {
            var Imagenbaner = Obj_indexdao.Obtenerindex();
            return File(Imagenbaner.imagenderecha, "image/jpeg");
        }

        public ActionResult obtenern1()
        {
            var Imagenbaner = Obj_indexdao.Obtenerindex();
            return File(Imagenbaner.foto1, "image/jpeg");
        }

        public ActionResult obtenern2()
        {
            var Imagenbaner = Obj_indexdao.Obtenerindex();
            return File(Imagenbaner.foto2, "image/jpeg");
        }

        public ActionResult obtenern3()
        {
            var Imagenbaner = Obj_indexdao.Obtenerindex();
            return File(Imagenbaner.foto3, "image/jpeg");
        }
        public ActionResult devolverpuntos_barras()
        {
            return Json(objpunto.mandaedatos_char_barras(), JsonRequestBehavior.AllowGet);
        }

    }
}