using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto.BO;
using System.Data.SqlClient;
using System.Data;
using Proyecto.DAO;

namespace Proyecto.DAO
{
    public class BackudDAO
    {
        //public int Back()
        //{

        //    Conexion_DAOcomant conectar = new Conexion_DAOcomant();
        //    SqlCommand cmd = new SqlCommand("Exec  BD_BackUpCompleto");
        //    cmd.CommandType = CommandType.Text;
        //    int resultado = conectar.EjecutarComando(cmd);

        //    return resultado;
        //}
        public usuarioBO Back()
        {
        
            ConexionDAO conexion = new ConexionDAO();
            var usuario = new usuarioBO();
            string strbuscar = string.Format("Exec  BD_BackUpCompleto");
            DataTable datos = conexion.ejercutarsentrenciasdatable(strbuscar);
        
            return usuario;
        
    }
    }
}