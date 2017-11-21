using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Mvc;
using Proyecto.BO;


namespace Proyecto.DAO
{
    public class punto_DAO
    {
        Conexion_DAOcomant conectar = new Conexion_DAOcomant();
        ConexionDAO marisa = new ConexionDAO();
        public int Guardar(object agregar,int id_usuario)
        {
            punto_peligrosoBO usuario = (punto_peligrosoBO)agregar;
            usuario.status = 0;
            usuario.nom_imagen = "jj";
         
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Puntos-peligrosos]([id_peligro],[Longitud] ,[Latitud],[Zona],[id_usuario],[Estatus],[fecha] ,[imagen],[imagen_nom],[comentario]) VALUES(@id_peligro,@longitud,@latitud,@zona,@id_usuario,@estatus,@fecha,@imagen,@imagennom,@comentario )");
           
            cmd.Parameters.Add("@id_peligro", SqlDbType.Int).Value = usuario.id_peligro_tipo;
            cmd.Parameters.Add("@longitud", SqlDbType.VarChar).Value = usuario.longitud;
            cmd.Parameters.Add("@latitud", SqlDbType.VarChar).Value = usuario.latitud;
            cmd.Parameters.Add("@zona", SqlDbType.VarChar).Value = usuario.zona;
            cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id_usuario;
            cmd.Parameters.Add("@estatus", SqlDbType.Bit).Value = usuario.status;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = usuario.fecha.ToString("yyyy-MM-dd");
             cmd.Parameters.Add("@imagen", SqlDbType.Image).Value = usuario.imagen;
            cmd.Parameters.Add("@imagennom", SqlDbType.VarChar).Value = usuario.nom_imagen;
            cmd.Parameters.Add("@comentario", SqlDbType.VarChar).Value = usuario.comentario;
            cmd.CommandType = CommandType.Text;
          

            return conectar.EjecutarComando(cmd);



        }
        public int eliminar (object eliminar)
        {
            punto_peligrosoBO peligroso = (punto_peligrosoBO)eliminar;
            SqlCommand comando = new SqlCommand("delete from [Puntos-peligrosos] where id=@id");
            comando.Parameters.Add("@id", SqlDbType.Int).Value = peligroso.id;
            comando.CommandType = CommandType.Text;
            return conectar.EjecutarComando(comando);

        }
        public int editar(object edi)
        {
            punto_peligrosoBO usuario = (punto_peligrosoBO)edi;
            SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Puntos-peligrosos]SET [id_peligro] = @id_peligro,[Longitud] =@longitud,[Latitud] = @latitud,[Zona] = @zona  ,[id_usuario] = @id_usuario  ,[Estatus] = @estatus ,[fecha] = @fecha   ,[imagen] = @imagen   ,[imagen_nom] = @imagennom ,[comentario] = @comentario WHERE id=@id");

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = usuario.id;
            cmd.Parameters.Add("@id_peligro", SqlDbType.Int).Value = usuario.id_peligro_tipo;
            cmd.Parameters.Add("@longitud", SqlDbType.VarChar).Value = usuario.longitud;
            cmd.Parameters.Add("@latitud", SqlDbType.VarChar).Value = usuario.latitud;
            cmd.Parameters.Add("@zona", SqlDbType.VarChar).Value = usuario.zona;
            cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = usuario.id_usuario;
            cmd.Parameters.Add("@estatus", SqlDbType.Bit).Value = usuario.status;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = usuario.fecha.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@imagen", SqlDbType.Image).Value = usuario.imagen;
            cmd.Parameters.Add("@imagennom", SqlDbType.VarChar).Value = usuario.nom_imagen;
            cmd.Parameters.Add("@comentario", SqlDbType.VarChar).Value = usuario.comentario;
            cmd.CommandType = CommandType.Text;
            return conectar.EjecutarComando(cmd);

        }
        public DataSet mostrar()
        {
          
            SqlCommand comando = new SqlCommand("select * from  [Puntos-peligrosos] ");
           
            comando.CommandType = CommandType.Text;
            return conectar.EjecutarSentencia(comando);

        }
      


        public IEnumerable<SelectListItem> listartipo()
        {
            var peligro = new List<SelectListItem>();
            String strBuscar = string.Format("SELECT [ID],[Peligro] FROM [Niveles-peligro]");
            peligro = marisa.EjecutarSetencialistEst1(strBuscar);
            IEnumerable<SelectListItem> peligros = peligro;

            return peligros;
        }



        //public List<Punto> mandaedatos()
        //{
        //    DataTable tabla = mostrar().Tables[0];
        //    List<Punto> Lista = new List<Punto>();
        //    foreach (DataRow dr in tabla.Rows)
        //    {
        //        Punto P = new Punto();
        //        P.punton = "'Kinchil, 97360 Kinchil, Yuc., México'";
        //        P.x= 20.9169054;
        //        P.y = -89.94771109999999;
        //        Lista.Add(P);
        //    }
        //    return Lista;
        //}

        public string mandaedatos()
        {
            DataTable tabla = mostrar().Tables[0];
            string datos = "[";
            foreach (DataRow dr in tabla.Rows)
            {
                datos = datos + "[";
                datos = datos + "'" + dr[4] + "'" + "," + dr[3] + "," + dr[2];
                datos = datos + "]";
            }
            datos = datos + "]";
            return datos;
        }


    }
}