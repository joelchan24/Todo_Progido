using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Mvc;
using Proyecto.BO;
using System.IO;
using System.Drawing;

namespace Proyecto.DAO
{
    public class punto_DAO
    {
        Conexion_DAOcomant conectar = new Conexion_DAOcomant();
        ConexionDAO marisa = new ConexionDAO();
        public int Guardar(object agregar,int id_usuario)
        {
          punto_peligrosoBO usuario = (punto_peligrosoBO)agregar;
            usuario.status = 1;
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Puntos-peligrosos]([id_peligro],[Longitud] ,[Latitud],[Zona],[id_usuario],[Estatus],[fecha] ,[imagen],[comentario],[comentadmin]) VALUES(@id_peligro,@longitud,@latitud,@zona,@id_usuario,@estatus,@fecha,@imagen,@comentario,@comentadmin )");
            cmd.Parameters.Add("@id_peligro", SqlDbType.Int).Value = usuario.id_peligro;
            cmd.Parameters.Add("@longitud", SqlDbType.VarChar).Value = usuario.longitud;
            cmd.Parameters.Add("@latitud", SqlDbType.VarChar).Value = usuario.latitud;
            cmd.Parameters.Add("@zona", SqlDbType.VarChar).Value = usuario.zona;
            cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id_usuario;
            cmd.Parameters.Add("@estatus", SqlDbType.Bit).Value = usuario.status;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = DateTime.Today;
            cmd.Parameters.Add("@imagen", SqlDbType.VarBinary).Value = usuario.imagen;
           
            cmd.Parameters.Add("@comentario", SqlDbType.VarChar).Value = usuario.comentario;
            cmd.Parameters.Add("@comentadmin", SqlDbType.VarChar).Value = "Enviado para verificación";
            cmd.CommandType = CommandType.Text;
            return conectar.EjecutarComando(cmd);
        }
        public int eliminar (int id)
        {
           
            SqlCommand comando = new SqlCommand("delete from [Puntos-peligrosos] where id=@id");
            comando.Parameters.Add("@id", SqlDbType.Int).Value = id;
            comando.CommandType = CommandType.Text;
            return conectar.EjecutarComando(comando);

        }
        public int editar(object edi)
        {
            punto_peligrosoBO usuario = (punto_peligrosoBO)edi;
            SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Puntos-peligrosos]SET [id_peligro] = @id_peligro,[Longitud] =@longitud,[Latitud] = @latitud,[Zona] = @zona  ,[id_usuario] = @id_usuario  ,[Estatus] = @estatus ,[fecha] = @fecha       ,[comentario] = @comentario WHERE id=@id");

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = usuario.id;
            cmd.Parameters.Add("@id_peligro", SqlDbType.Int).Value = usuario.id_peligro;
            cmd.Parameters.Add("@longitud", SqlDbType.VarChar).Value = usuario.longitud;
            cmd.Parameters.Add("@latitud", SqlDbType.VarChar).Value = usuario.latitud;
            cmd.Parameters.Add("@zona", SqlDbType.VarChar).Value = usuario.zona;
            cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = usuario.id_usuario;
            cmd.Parameters.Add("@estatus", SqlDbType.Bit).Value = usuario.status;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = usuario.fecha.ToString("yyyy-MM-dd");
            //  cmd.Parameters.Add("@imagen", SqlDbType.Image).Value = usuario.imagen;[imagen] = @imagen
            //cmd.Parameters.Add("@imagennom", SqlDbType.VarChar).Value = usuario.nom_imagen;[imagen_nom] = @imagennom
            cmd.Parameters.Add("@comentario", SqlDbType.VarChar).Value = usuario.comentario;
            cmd.CommandType = CommandType.Text;
            return conectar.EjecutarComando(cmd);

        }
        public DataSet mostrar()
        {
          
            SqlCommand comando = new SqlCommand("select * from  [Puntos-peligrosos] p inner join [Niveles-peligro] n on p.id_peligro=n.id where p.Estatus=0 ");
           
            comando.CommandType = CommandType.Text;
            return conectar.EjecutarSentencia(comando);

        }
        public DataSet mostrar_persolanes(int id)
        {

            SqlCommand comando = new SqlCommand("select * from  [Puntos-peligrosos] p inner join [Niveles-peligro] n on p.id_peligro=n.id where p.id_usuario=@id ");
            comando.Parameters.Add("@id", SqlDbType.Int).Value = id;

            comando.CommandType = CommandType.Text;
            return conectar.EjecutarSentencia(comando);

        }
        public DataSet foto_del_usuaurio(int id)
        {

            SqlCommand comando = new SqlCommand("select foto from usuario where id =@id ");
            comando.Parameters.Add("@id", SqlDbType.Int).Value = id;

            comando.CommandType = CommandType.Text;
            return conectar.EjecutarSentencia(comando);

        }
        public DataSet mostrar_char_ba()
        {

            SqlCommand comando = new SqlCommand(" select (select COUNT(*) from [Puntos-peligrosos] where Estatus = 0)as rechazados,(select COUNT(*) from [Puntos-peligrosos] where Estatus = 1)as aprobados ");

            comando.CommandType = CommandType.Text;
            return conectar.EjecutarSentencia(comando);

        }
        public DataSet mostrar_pie_char()
        {

            SqlCommand comando = new SqlCommand("   select n.Peligro , count( n.Peligro) as total from [Puntos-peligrosos] p inner join [niveles-peligro] n on n.ID=p.id_peligro   GROUP BY n.Peligro   ");

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
        public IEnumerable<SelectListItem> listartipo_usuarios()
        {
            var peligro = new List<SelectListItem>();
            String strBuscar = string.Format("  select id ,nombre, apellido from [Usuario]");
            peligro = marisa.EjecutarSetencialistEst_usuaios(strBuscar);
            IEnumerable<SelectListItem> peligros = peligro;

            return peligros;
        }
        public List<Punto> mandaedatos()
        {
            DataTable tabla = mostrar().Tables[0];
            List<Punto> Lista = new List<Punto>();
            byte[] imagen;
          

            foreach (DataRow dr in tabla.Rows)
            {
                
               
                imagen = (byte[])dr[8];
                
               

               
                Punto P = new Punto();
                P.punton = "<h5>" + dr[13] + "</h5>" + "<p>" + dr[10] + "</p>" + "<p>" + " en  " + dr[4] + "</p>" + "<img src ='data:image/jpg;base64,"+ Convert.ToBase64String(imagen)+"' "+"style = width=200px height=200px />";
                ;
              
                P.id = dr[1].ToString();
                P.x = double.Parse(dr[3].ToString());
                P.y = double.Parse(dr[2].ToString());
                Lista.Add(P);
            }
            return Lista;
        }
       
        public List<Punto> mandaedatos_al_admin()
        {
            DataTable tabla = mostrar().Tables[0];
            List<Punto> Lista = new List<Punto>();
            byte[] imagen;
            foreach (DataRow dr in tabla.Rows)
            {
                imagen = (byte[])dr[8];

                Punto P = new Punto();
                P.punton = dr[12] + " en  " + dr[4]
                    ;
                P.id = dr[1].ToString();
                P.x = double.Parse(dr[3].ToString());
                P.y = double.Parse(dr[2].ToString());
                Lista.Add(P);
            }
            return Lista;
        }
        public List<Punto> mandaedatos__personales(int id)
        {
            DataTable tabla = mostrar_persolanes(id).Tables[0];
            List<Punto> Lista = new List<Punto>();
            byte[] imagen;
            
            foreach (DataRow dr in tabla.Rows)
            {
                imagen = (byte[])dr[8];
                Punto P = new Punto();
                P.punton = "<h5 style='center'>" + dr[12] + "</h5>" + "<p>" + dr[10] + "</p>" + "<p>" + " en  " + dr[4] + "</p>" + "<img src ='data:image/jpg;base64," + Convert.ToBase64String(imagen) + "' " + "style =" + " width=100% height=300px />";
                P.id = dr[1].ToString();
                P.x = double.Parse(dr[3].ToString());
                P.y = double.Parse(dr[2].ToString());
                Lista.Add(P);
            }
            return Lista;
        }
        public List<puntos_barras> mandaedatos_char_barras()
        {
            DataTable tabla = mostrar_char_ba().Tables[0];
            List<puntos_barras> Lista = new List<puntos_barras>();
            string [] array = { "no aprovados", "aprovados" };
            //byte[] imagen;
            //Convert.ToBase64String(imagen)
            foreach (DataRow dr in tabla.Rows)
            {
               int i = 0;
                puntos_barras P = new puntos_barras();
        

                P.aprovados = int.Parse(dr[1].ToString());
                P.no_aprovados = int.Parse(dr[0].ToString());
                Lista.Add(P);
            }
            return Lista;
        }
        public List<char_> mandar_pie_char()
        {
            DataTable tabla = mostrar_pie_char().Tables[0];
            List<char_> lista_char = new List<char_>();
            foreach (DataRow dr in tabla.Rows)
            {
                char_ P = new char_();
                P.nombre = dr[0].ToString();
                P.total = int.Parse(dr[1].ToString());
                
                lista_char.Add(P);
            }
            return lista_char;
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

        //public string mandaedatos()
        //{
        //    DataTable tabla = mostrar().Tables[0];
        //    string datos = "[";
        //    foreach (DataRow dr in tabla.Rows)
        //    {
        //        datos = datos + "[";
        //        datos = datos + "'" + dr[4] + "'" + "," + dr[3] + "," + dr[2];
        //        datos = datos + "]";
        //    }
        //    datos = datos + "]";
        //    return datos;
        //}

        public List<punto_peligrosoBO> listar_eventos_con_peligro()
        {
            var alumnos = new List<punto_peligrosoBO>();
            String strBuscar = string.Format("  select p.ID as clave ,zona ,comentario , fecha,n.Peligro as peli from [Puntos-peligrosos] p INNER JOIN [Niveles-peligro] n on n.id=p.id_peligro ");
            return alumnos = marisa.EjecutarSetencialist_puntos(strBuscar);
        }
        public DataTable buscarAlumno()
        {
            String strBuscar = string.Format("  select * from [Niveles-peligro] ");
            return marisa.ejercutarsentrenciasdatable(strBuscar);
        }
        public List<punto_peligrosoBO> listar_eventos_con_peligro_noaprovados()
        {
            var alumnos = new List<punto_peligrosoBO>();
            String strBuscar = string.Format("     select  p.ID as clave ,u.Nombre  as usuario,zona ,comentario ,p.fecha as fecha1,n.Peligro as peli from [Puntos-peligrosos] p INNER JOIN [Niveles-peligro] n on n.id=p.id_peligro inner join Usuario u on u.ID=p.id_usuario where p.Estatus=0");
            return alumnos = marisa.EjecutarSetencialist_puntos_noaprovados(strBuscar);
        }
        public List<punto_peligrosoBO> aprovados()
        {
            var alumnos = new List<punto_peligrosoBO>();
            String strBuscar = string.Format("    select  p.ID as clave ,u.Nombre  as usuario,zona ,comentario ,p.fecha as fecha1,n.Peligro as peli from [Puntos-peligrosos] p INNER JOIN [Niveles-peligro] n on n.id=p.id_peligro inner join Usuario u on u.ID=p.id_usuario where p.Estatus=1");
            return alumnos = marisa.EjecutarSetencialist_puntos_aprovados(strBuscar);
        }
        public int actaulzar_apro(int id)
        {

            SqlCommand comando = new SqlCommand("update [Puntos-peligrosos] set estatus=0 , comentadmin=@comente where id=@id");
            comando.Parameters.Add("@id", SqlDbType.Int).Value = id;
            comando.Parameters.Add("@comente", SqlDbType.Text).Value = "Tu punto se ha aprobado! gracias por alertar a la comunidad  ";
          comando.CommandType = CommandType.Text;
            return conectar.EjecutarComando(comando);

        }
        public int actaulzar_noapro(int id,string comentario)
        {

            SqlCommand comando = new SqlCommand("update [Puntos-peligrosos] set estatus=2, comentadmin=@comente where id=@id");
            comando.Parameters.Add("@id", SqlDbType.Int).Value = id;
            comando.Parameters.Add("@comente", SqlDbType.Text).Value = comentario;
            comando.CommandType = CommandType.Text;
            return conectar.EjecutarComando(comando);

        }


        public DataTable CargarTablaPuntos()
        {
            String strBuscar = string.Format("select [Puntos-peligrosos].ID,[Niveles-peligro].Peligro, [Puntos-peligrosos].Zona, Usuario.Nombre,[Puntos-peligrosos].fecha, [Puntos-peligrosos].comentario from [Puntos-peligrosos],[Niveles-peligro], Usuario where [Puntos-peligrosos].id_peligro = [Niveles-peligro].ID and [Puntos-peligrosos].id_usuario =Usuario.ID and [Puntos-peligrosos].Estatus=1");
            return marisa.ejercutarsentrenciasdatable(strBuscar);
        }

        public DataTable CargarTablaPuntosaprovados()
        {
            String strBuscar = string.Format("select [Puntos-peligrosos].ID,[Niveles-peligro].Peligro, [Puntos-peligrosos].Zona, Usuario.Nombre,[Puntos-peligrosos].fecha, [Puntos-peligrosos].comentario from [Puntos-peligrosos],[Niveles-peligro], Usuario where [Puntos-peligrosos].id_peligro = [Niveles-peligro].ID and [Puntos-peligrosos].id_usuario =Usuario.ID and [Puntos-peligrosos].Estatus=0");
            return marisa.ejercutarsentrenciasdatable(strBuscar);
        }

        public DataTable CargarTablaPuntosDesaprovados()
        {
            String strBuscar = string.Format("select [Puntos-peligrosos].ID,[Niveles-peligro].Peligro, [Puntos-peligrosos].Zona, Usuario.Nombre,[Puntos-peligrosos].fecha, [Puntos-peligrosos].comentario from [Puntos-peligrosos],[Niveles-peligro], Usuario where [Puntos-peligrosos].id_peligro = [Niveles-peligro].ID and [Puntos-peligrosos].id_usuario =Usuario.ID and [Puntos-peligrosos].Estatus=2");
            return marisa.ejercutarsentrenciasdatable(strBuscar);
        }

        public DataTable CargarTiposIncidentes()
        {
            String strBuscar = string.Format("select ID, Peligro from [Niveles-peligro]");
            return marisa.ejercutarsentrenciasdatable(strBuscar);
        }

        public punto_peligrosoBO ObtenerImagen(int id)
        {
            ConexionDAO conex = new ConexionDAO();
            var imagenp = new punto_peligrosoBO();
            String strBuscar = string.Format("SELECT * FROM  [Puntos-peligrosos] where ID='"+id+"'");
            DataTable datos = conex.ejercutarsentrenciasdatable(strBuscar);
            DataRow row = datos.Rows[0];
            imagenp.imagen = (byte[])row["imagen"];

            return imagenp;
        }
        public usuarioBO Obtener_cli()
        {
            ConexionDAO conex = new ConexionDAO();
            var imagenp = new usuarioBO();
            String strBuscar = string.Format("select foto from usuario where id =1006");
            DataTable datos = conex.ejercutarsentrenciasdatable(strBuscar);
            DataRow row = datos.Rows[0];
            imagenp.foto = (byte[])row["foto"];

            return imagenp;
        }
        public usuarioBO Obtener_usuario_normal(int id)
        {
            ConexionDAO conex = new ConexionDAO();
            var imagenp = new usuarioBO();
            String strBuscar = string.Format("select foto from usuario where id ='" + id + "'");
            DataTable datos = conex.ejercutarsentrenciasdatable(strBuscar);
            DataRow row = datos.Rows[0];
            imagenp.foto = (byte[])row["foto"];

            return imagenp;
        }

        public DataTable CargarTablausuario(int id)
        {
            String strBuscar = string.Format("select [Niveles-peligro].Peligro,[Puntos-peligrosos].ID, [Puntos-peligrosos].Zona,[Puntos-peligrosos].fecha, [Puntos-peligrosos].comentario,[Puntos-peligrosos].Estatus, [Puntos-peligrosos].comentadmin from [Puntos-peligrosos],[Niveles-peligro], Usuario where [Puntos-peligrosos].id_peligro = [Niveles-peligro].ID and [Puntos-peligrosos].id_usuario =Usuario.ID and Usuario.Id = '" + id + "'");
            return marisa.ejercutarsentrenciasdatable(strBuscar);
        }


        public byte[] optenerimagenpel()
        {
            ConexionDAO conex = new ConexionDAO();
         
            String strBuscar = string.Format("  select imagen from evidencia where id=2");
            DataTable datos = conex.ejercutarsentrenciasdatable(strBuscar);
            DataRow row = datos.Rows[0];
            byte[] img = (byte[])row["imagen"];
            return img;
        }
    }
}