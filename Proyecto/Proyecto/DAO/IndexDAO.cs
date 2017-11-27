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
    public class IndexDAO
    {
        public usuarioBO Obtenerindex()
        {
            ConexionDAO conex = new ConexionDAO();
            var indext = new usuarioBO();
            String strBuscar = string.Format("SELECT * FROM indext where id=1");
            DataTable datos = conex.ejercutarsentrenciasdatable(strBuscar);
            DataRow row = datos.Rows[0];
            indext.titulopresentacion = row["titulopresentacion"].ToString();
            indext.textopresentacion = row["textopresentacion"].ToString();
            indext.imagenbanner = (byte[])row["imagenbanner"];
            indext.imagenizquierda = (byte[])row["imagenizquierda"];
            indext.imagenderecha = (byte[])row["imagenderecha"];
            indext.foto1 = (byte[])row["f1"];
            indext.foto2 = (byte[])row["f2"];
            indext.foto3 = (byte[])row["f3"];
            indext.textoizquierda = row["textoizquierda"].ToString();
            indext.tituloizquierda = row["tituloizquierda"].ToString();
            indext.tituloderecha = row["tituloderecha"].ToString();
            indext.textoderecha = row["textoderecha"].ToString();
            indext.rol1= row["r1"].ToString();
            indext.rol2 = row["r2"].ToString();
            indext.rol3 = row["r3"].ToString();
            indext.nom1 = row["n1"].ToString();
            indext.nom2 = row["n2"].ToString();
            indext.nom3 = row["n3"].ToString();

            indext.r1 = row["re1"].ToString();
            indext.re1 = row["red1"].ToString();
            indext.red1 = row["redd1"].ToString();

            indext.r2 = row["re2"].ToString();
            indext.re2 = row["red2"].ToString();
            indext.red2 = row["redd2"].ToString();

            indext.r3 = row["re3"].ToString();
            indext.re3 = row["red3"].ToString();
            indext.red3 = row["redd3"].ToString();


            return indext;
        }


        public int GuardarImagen(object agregar)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("UPDATE indext set imagenbanner=@foto where id=1");
            cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = usuario.imagenbanner;
            cmd.CommandType = CommandType.Text;
            return conectar.EjecutarComando(cmd);
        }

        public int Guardarpre(object agregar)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("UPDATE indext set titulopresentacion=@titulo,textopresentacion=@texto  where id=1");
            cmd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = usuario.titulopresentacion;
            cmd.Parameters.Add("@texto", SqlDbType.Text).Value = usuario.textopresentacion;
            cmd.CommandType = CommandType.Text;
            return conectar.EjecutarComando(cmd);
        }

        public int Guardarizquierda(object agregar)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("UPDATE indext set  tituloizquierda=@titulo,textoizquierda=@texto  where id=1");
            cmd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = usuario.tituloizquierda;
            cmd.Parameters.Add("@texto", SqlDbType.Text).Value = usuario.textoizquierda;
            cmd.CommandType = CommandType.Text;
            return conectar.EjecutarComando(cmd);
        }
        public int Guardarderecha(object agregar)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("UPDATE indext set tituloderecha=@titulo, textoderecha=@texto  where id=1");
            cmd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = usuario.tituloderecha;
            cmd.Parameters.Add("@texto", SqlDbType.Text).Value = usuario.textoderecha;
            cmd.CommandType = CommandType.Text;
            return conectar.EjecutarComando(cmd);
        }

        public int integrante1(object agregar)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("UPDATE indext set n1=@n1, r1=@r1,re1=@re, red1=@red, redd1=@redd,f1=@fotoi  where id=1");
            cmd.Parameters.Add("@n1", SqlDbType.Text).Value = usuario.nom1;
            cmd.Parameters.Add("@r1", SqlDbType.Text).Value = usuario.rol1;
            cmd.Parameters.Add("@re", SqlDbType.Text).Value = usuario.r1;
            cmd.Parameters.Add("@red", SqlDbType.Text).Value = usuario.re1;
            cmd.Parameters.Add("@redd", SqlDbType.Text).Value = usuario.red1;
            cmd.Parameters.Add("@fotoi", SqlDbType.VarBinary).Value = usuario.foto1;
            cmd.CommandType = CommandType.Text;
            return conectar.EjecutarComando(cmd);
        }
        public int integrante3(object agregar)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("UPDATE indext set n3=@n1, r3=@r1,re3=@re, red3=@red, redd3=@redd,f3=@fotoi  where id=1");
            cmd.Parameters.Add("@n1", SqlDbType.Text).Value = usuario.nom3;
            cmd.Parameters.Add("@r1", SqlDbType.Text).Value = usuario.rol3;
            cmd.Parameters.Add("@re", SqlDbType.Text).Value = usuario.r3;
            cmd.Parameters.Add("@red", SqlDbType.Text).Value = usuario.re3;
            cmd.Parameters.Add("@redd", SqlDbType.Text).Value = usuario.red3;
            cmd.Parameters.Add("@fotoi", SqlDbType.VarBinary).Value = usuario.foto3;
            cmd.CommandType = CommandType.Text;
            return conectar.EjecutarComando(cmd);
        }
        public int integrante2(object agregar)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("UPDATE indext set n2=@n2, r2=@r1,re2=@re, red2=@red, redd2=@redd, f2=@fotoi where id=1");
            cmd.Parameters.Add("@n2", SqlDbType.Text).Value = usuario.nom2;
            cmd.Parameters.Add("@r1", SqlDbType.Text).Value = usuario.rol2;
            cmd.Parameters.Add("@re", SqlDbType.Text).Value = usuario.r2;
            cmd.Parameters.Add("@red", SqlDbType.Text).Value = usuario.re2;
            cmd.Parameters.Add("@redd", SqlDbType.Text).Value = usuario.red2;
            cmd.Parameters.Add("@fotoi", SqlDbType.VarBinary).Value = usuario.foto2;
            cmd.CommandType = CommandType.Text;
            return conectar.EjecutarComando(cmd);
        }


        public int Guardarizque(object agregar)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("UPDATE indext set imagenizquierda=@foto where id=1");
            cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = usuario.imagenizquierda;
            cmd.CommandType = CommandType.Text;
            return conectar.EjecutarComando(cmd);
        }

        public int Guardardere(object agregar)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("UPDATE indext set imagenderecha=@foto where id=1");
            cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = usuario.imagenderecha;
            cmd.CommandType = CommandType.Text;
            return conectar.EjecutarComando(cmd);
        }
    }
}