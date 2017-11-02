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
        public ActionResult inicio()
        {
            return View();
        }
        public ActionResult vacio1()
        {
            return View();
        }
        public ActionResult vacio()
        {
            // return View(id==""  ? new usuarioBO() :log.obtener(id));
            return View();
        }
        public ActionResult login(usuarioBO usuario)
        {
            if (log.verificar(usuario))
            {
                var i = log.buscarelid(usuario);
                Session["id_tipo"] = i;
                Response.Write("<script>alert('usuario correcto')</script>");


                if (i == 1)
                {
              return  Redirect("~/todo_pro/inicio");


                }
                else if (i == 2)
                {
              return     Redirect("~/todo_pro/inicio");
                }
                else if (i == 3)
                {

           return   Redirect("~/todo_pro/inicio");
                }
                
            }
           
        return Redirect("~/todo_pro/vacio");
            

            
      
        }
    }
}