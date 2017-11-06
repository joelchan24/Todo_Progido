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
            SqlCommand cmd = new SqlCommand("select count(nombre) ID from usuario where nombre=@usuario and contraseña=@contra");
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario.nombre;
            cmd.Parameters.Add("@contra", SqlDbType.VarChar).Value = usuario.contraseña;
            cmd.CommandType = CommandType.Text;
            int resultado = conectar.EjecutarComando(cmd);

            return (resultado != 0) ? true : false;



        }
        public int buscarelid(object agregar)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("select ID_tipo, nombre from usuario where	Nombre=@usuario and contraseña=@contra");
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario.nombre;
            cmd.Parameters.Add("@contra", SqlDbType.VarChar).Value = usuario.contraseña;
            cmd.CommandType = CommandType.Text;
            int resultado = conectar.EjecutarComando(cmd);

            return resultado;



        }
        public usuarioBO obtener(string i,string o)
        {
            ConexionDAO conexion = new ConexionDAO();
            var usuario = new usuarioBO();
            string strbuscar = string.Format("select nombre  from usuario where	Nombre='"+i+"' and contraseña='"+o+"'");
            DataTable datos = conexion.ejercutarsentrenciasdatable(strbuscar);
            DataRow row = datos.Rows[0];
         
            usuario.nombre = row["nombre"].ToString();
           
            return usuario;
        }
    }
}