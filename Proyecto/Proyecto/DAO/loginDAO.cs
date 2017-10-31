using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto.BO;
using System.Data.SqlClient;
using System.Data;
namespace Proyecto.DAO
{
    public class loginDAO
    {
        public bool verificar(object agregar)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("select count(usuario) CODIGO from usuarios where usuario=@usuario and contraseña=@contra");
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario.nombre;
            cmd.Parameters.Add("@contra", SqlDbType.VarChar).Value = usuario.contraseña;
            cmd.CommandType = CommandType.Text;
            int resultado = conectar.EjecutarComando(cmd);

            return (resultado != 0) ? true : false;



        }
    }
}