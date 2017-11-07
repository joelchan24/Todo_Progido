using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto.BO;
using System.Data.SqlClient;
using System.Data;
namespace Proyecto.DAO
{
    public class usuarioDAO
    {
        public int guardar(object agregar)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("insert into usuario (nombre,contraseña,fecha,id_tipo,telefono,correo) values (@nom,@contra,@fecha,@id_tipo,@telefono,@correo)");
            usuario.id_tipo = 2;
            cmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = usuario.nombre;
            cmd.Parameters.Add("@contra", SqlDbType.VarChar).Value = usuario.contraseña;
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = usuario.fecha.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@id_tipo", SqlDbType.Int).Value =usuario.id_tipo;
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = usuario.telefono;
            cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = usuario.correo;
            cmd.CommandType = CommandType.Text;
        

            return conectar.EjecutarComando(cmd);



        }
    }
}