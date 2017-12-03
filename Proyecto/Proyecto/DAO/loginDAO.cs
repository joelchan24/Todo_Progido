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
        public string idtemp;
        public bool verificar(object agregar)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("select count(correo) ID from usuario where correo=@usuario and contraseña=@contra");
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
            SqlCommand cmd = new SqlCommand("select ID_tipo, correo from usuario where	correo=@usuario and contraseña=@contra");
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
            string strbuscar = string.Format("select *  from usuario where	correo='"+i+"' and contraseña='"+o+"'");
            DataTable datos = conexion.ejercutarsentrenciasdatable(strbuscar);
            DataRow row = datos.Rows[0];
            usuario.id = Convert.ToInt32(row["id"]);
            usuario.correo = row["correo"].ToString();
            usuario.nombre = row["nombre"].ToString();
            usuario.apellido = row["Apellido"].ToString();
            //usuario.foto = (byte[])row["foto"];
            idtemp = i;
          
            

            return usuario;
        }



        public usuarioBO obtenerperfil()
        {
            ConexionDAO conexion = new ConexionDAO();
            var usuario = new usuarioBO();
            string strbuscar = string.Format("select * from Usuario where ID='1006';");
            DataTable dats = conexion.ejercutarsentrenciasdatable(strbuscar);
            DataRow row = dats.Rows[0];
          
            usuario.correo = row["Correo"].ToString();
            usuario.nombre = row["Nombre"].ToString();
            usuario.apellido = row["Apellido"].ToString();
            usuario.sexo = row["sexo"].ToString();
            usuario.correo = row["Correo"].ToString();
            usuario.telefono = row["Telefono"].ToString();
            usuario.fecha = ((DateTime)row["fecha"]);
            usuario.foto = (byte[])row["foto"];


            return usuario;
        }
        public usuarioBO obtenerperfil_usuario(int id)
        {
            string val = "";
            ConexionDAO conexion = new ConexionDAO();
            var usuario = new usuarioBO();
            string strbuscar = string.Format("select * from Usuario where ID='"+id+"'");
            DataTable dats = conexion.ejercutarsentrenciasdatable(strbuscar);
            DataRow row = dats.Rows[0];
            usuario.id = int.Parse(row["id"].ToString());
            usuario.correo = row["Correo"].ToString();
            usuario.nombre = row["Nombre"].ToString();
            usuario.apellido = row["Apellido"].ToString();
            usuario.sexo = row["sexo"].ToString();
            usuario.correo = row["Correo"].ToString();
            usuario.telefono = row["Telefono"].ToString();
            usuario.contraseña = (Convert.ToDateTime(row["fecha"])).ToString("yyyy-MM-dd");
            usuario.foto = (byte[])row["foto"];


            return usuario;
        }


        public usuarioBO obtnerfoto()
        {
            ConexionDAO conexion = new ConexionDAO();
            var usuario = new usuarioBO();
            string strbuscar = string.Format("select * from Usuario where ID='1007';");
            DataTable dats = conexion.ejercutarsentrenciasdatable(strbuscar);
            DataRow row = dats.Rows[0];

      
            usuario.foto = (byte[])row["foto"];


            return usuario;
        }
    }
}