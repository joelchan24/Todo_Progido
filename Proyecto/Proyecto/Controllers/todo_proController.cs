using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.BO;
using Proyecto.DAO;

namespace Proyecto.Controllers
{
    public class todo_proController : Controller
    {
        // GET: todo_pro
        loginDAO log = new loginDAO();
        usuarioDAO usuario_dao = new usuarioDAO();

        public ActionResult vacio()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View();
            }
            return View();
        }
        public ActionResult guardar(usuarioBO usuario)
        {
            usuario_dao.guardar(usuario);
            return Redirect("~/todo_pro/inicio");
        }
        public ActionResult cerrar()
        {

           

            Session.Remove("usuario");
            Session.Abandon();
            return Redirect("~/todo_pro/inicio");
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
        public ActionResult inicio( )
        {
            if (Session["usuario"]!=null)
            {
                ViewBag.usuario =(usuarioBO) Session["usuario"];
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
          
                    return View("vacio", usu);

                }
                else if (i == 2)
                {
                    return View("inicio", usu);
                }
                else if (i == 3)
                {

                    return View("inicio", usu);
                }
                
            }
           
        return Redirect("~/todo_pro/vacio");
            

            
      
        }
    }
}