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
            SqlCommand cmd = new SqlCommand("insert into usuario (nombre,contraseña,fecha,id_tipo,correo,Apellido,sexo,foto) values (@nom,@contra,@fecha,@id_tipo,@correo,@apellido,@sexo,@foto)");
            usuario.id_tipo = 1;
            cmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = usuario.nombre;
            cmd.Parameters.Add("@contra", SqlDbType.VarChar).Value = usuario.contraseña;
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = usuario.fecha.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@id_tipo", SqlDbType.Int).Value = usuario.id_tipo;
            cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = usuario.correo;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = usuario.apellido;
            cmd.Parameters.Add("@foto", SqlDbType.VarChar).Value = usuario.foto;

            cmd.Parameters.Add("@sexo", SqlDbType.VarChar).Value = usuario.sexo;
            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarComando(cmd);



        }

        public int guardarsf(object agregar)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("insert into usuario (nombre,contraseña,fecha,id_tipo,correo,Apellido,sexo,foto) values (@nom,@contra,@fecha,@id_tipo,@correo,@apellido,@sexo,@foto)");
            usuario.id_tipo = 1;
            cmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = usuario.nombre;
            cmd.Parameters.Add("@contra", SqlDbType.VarChar).Value = usuario.contraseña;
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = usuario.fecha.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@id_tipo", SqlDbType.Int).Value = usuario.id_tipo;
          
            cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = usuario.correo;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = usuario.apellido;
            cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = usuario.foto;

            cmd.Parameters.Add("@sexo", SqlDbType.VarChar).Value = usuario.sexo;
            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarComando(cmd);



        }


        public byte[] optenerimagenpel1()
        {
            ConexionDAO conex = new ConexionDAO();
            String strBuscar = string.Format("select imagen from evidencia where id=3");
            DataTable datos = conex.ejercutarsentrenciasdatable(strBuscar);
            DataRow row = datos.Rows[0];
            byte[] img = (byte[])row["imagen"];
            return img;
        }

        public int editar(object agregar , int id,string fecha)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("update  usuario set nombre=@nom,fecha=@fecha,correo=@correo,Apellido=@apellido,sexo=@sexo,foto=@foto where id=@id");          
            cmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = usuario.nombre;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value= Convert.ToDateTime(fecha).ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@id_tipo", SqlDbType.Int).Value = usuario.id_tipo;
    
            cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = usuario.correo;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = usuario.apellido;
            cmd.Parameters.Add("@foto", SqlDbType.VarChar).Value = usuario.foto;
            cmd.Parameters.Add("@sexo", SqlDbType.VarChar).Value = usuario.sexo;
            cmd.CommandType = CommandType.Text;
            return conectar.EjecutarComando(cmd);
        }

        public int editarsinf(object agregar, int id, string fecha)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("update  usuario set nombre=@nom,fecha=@fecha,correo=@correo,Apellido=@apellido,sexo=@sexo where id=@id");
            cmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = usuario.nombre;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Convert.ToDateTime(fecha).ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@id_tipo", SqlDbType.Int).Value = usuario.id_tipo;
         
            cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = usuario.correo;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = usuario.apellido;
            cmd.Parameters.Add("@sexo", SqlDbType.VarChar).Value = usuario.sexo;
            cmd.CommandType = CommandType.Text;
            return conectar.EjecutarComando(cmd);
        }
        
    }
}