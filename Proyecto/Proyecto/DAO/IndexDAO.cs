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

            indext.p1 = contar();

            indext.p7 = contar7();

            indext.p2 = contar2();
            indext.p3= contar3();
            indext.p4 = contar4();
            indext.p5 = contar5();
            indext.p6 = contar6();
            indext.p7 = contar7();
            indext.p8 = contar8();
            indext.usua = usua();
            indext.puntoss = cuentaspunt();
            
            return indext;
        }


        public int GuardarImagen(object agregar)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("UPDATE indext set imagenbanner=@foto where id=1");
            //SqlCommand cmd = new SqlCommand("insert into evidencia (imagen) values (@foto)");
            cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = usuario.imagenbanner;
            cmd.CommandType = CommandType.Text;
            return conectar.EjecutarComando(cmd);
        }

        public int GuardarImagen2(object agregar)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("UPDATE indext set imagenizquierda=@foto where id=1");
            cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = usuario.imagenbanner;
            cmd.CommandType = CommandType.Text;
            return conectar.EjecutarComando(cmd);
        }

        public int GuardarImagen3(object agregar)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("UPDATE indext set imagenderecha=@foto where id=1");
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
            SqlCommand cmd = new SqlCommand("UPDATE indext set  tituloizquierda=@titulo,textoizquierda=@texto,tituloderecha=@p2   where id=1");
            cmd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = usuario.tituloizquierda;
            cmd.Parameters.Add("@texto", SqlDbType.Text).Value = usuario.textoizquierda;
            cmd.Parameters.Add("@p2", SqlDbType.Text).Value = usuario.tituloderecha;
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
            SqlCommand cmd = new SqlCommand("UPDATE indext set n1=@n1, r1=@r1,f1=@fotoi  where id=1");
            cmd.Parameters.Add("@n1", SqlDbType.Text).Value = usuario.nom1;
            cmd.Parameters.Add("@r1", SqlDbType.Text).Value = usuario.rol1;
            cmd.Parameters.Add("@fotoi", SqlDbType.VarBinary).Value = usuario.foto1;
            cmd.CommandType = CommandType.Text;
            return conectar.EjecutarComando(cmd);
        }
        public int integrante3(object agregar)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("UPDATE indext set n3=@n1, r3=@r1,f3=@fotoi  where id=1");
            cmd.Parameters.Add("@n1", SqlDbType.Text).Value = usuario.nom3;
            cmd.Parameters.Add("@r1", SqlDbType.Text).Value = usuario.rol3;
            cmd.Parameters.Add("@fotoi", SqlDbType.VarBinary).Value = usuario.foto3;
            cmd.CommandType = CommandType.Text;
            return conectar.EjecutarComando(cmd);
        }
        public int integrante2(object agregar)
        {
            usuarioBO usuario = (usuarioBO)agregar;
            Conexion_DAOcomant conectar = new Conexion_DAOcomant();
            SqlCommand cmd = new SqlCommand("UPDATE indext set n2=@n2, r2=@r1,f2=@fotoi where id=1");
            cmd.Parameters.Add("@n2", SqlDbType.Text).Value = usuario.nom2;
            cmd.Parameters.Add("@r1", SqlDbType.Text).Value = usuario.rol2;
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


        public int contar()
        {
            ConexionDAO conex = new ConexionDAO();
            usuarioBO indext = new usuarioBO();
            String strBuscar = string.Format("select COUNT(*) as 'c' from [Puntos-peligrosos] where id_peligro=11 and Estatus=0 ");
            DataTable datos = conex.ejercutarsentrenciasdatable(strBuscar);
            DataRow row = datos.Rows[0];
            indext.p1 = int.Parse(row["c"].ToString());
            return indext.p1;
        }

        public int contar2()
        {
            ConexionDAO conex = new ConexionDAO();
            usuarioBO indext = new usuarioBO();
            String strBuscar = string.Format("select COUNT(*) as 'c' from [Puntos-peligrosos] where id_peligro=4 and Estatus=0");
            DataTable datos = conex.ejercutarsentrenciasdatable(strBuscar);
            DataRow row = datos.Rows[0];
            indext.p2 = int.Parse(row["c"].ToString());
            return indext.p2;
        }

        public int contar3()
        {
            ConexionDAO conex = new ConexionDAO();
            usuarioBO indext = new usuarioBO();
            String strBuscar = string.Format("select COUNT(*) as 'c' from [Puntos-peligrosos] where id_peligro=5 and Estatus=0");
            DataTable datos = conex.ejercutarsentrenciasdatable(strBuscar);
            DataRow row = datos.Rows[0];
            indext.p3 = int.Parse(row["c"].ToString());
            return indext.p3;
        }

        public int contar4()
        {
            ConexionDAO conex = new ConexionDAO();
            usuarioBO indext = new usuarioBO();
            String strBuscar = string.Format("select COUNT(*) as 'c' from [Puntos-peligrosos] where id_peligro=6 and Estatus=0");
            DataTable datos = conex.ejercutarsentrenciasdatable(strBuscar);
            DataRow row = datos.Rows[0];
            indext.p4 = int.Parse(row["c"].ToString());
            return indext.p4;
        }

        public int contar5()
        {
            ConexionDAO conex = new ConexionDAO();
            usuarioBO indext = new usuarioBO();
            String strBuscar = string.Format("select COUNT(*) as 'c' from [Puntos-peligrosos] where id_peligro=7 and Estatus=0");
            DataTable datos = conex.ejercutarsentrenciasdatable(strBuscar);
            DataRow row = datos.Rows[0];
            indext.p5 = int.Parse(row["c"].ToString());
            return indext.p5;
        }

        public int contar6()
        {
            ConexionDAO conex = new ConexionDAO();
            usuarioBO indext = new usuarioBO();
            String strBuscar = string.Format("select COUNT(*) as 'c' from [Puntos-peligrosos] where id_peligro=8 and Estatus=0");
            DataTable datos = conex.ejercutarsentrenciasdatable(strBuscar);
            DataRow row = datos.Rows[0];
            indext.p6 = int.Parse(row["c"].ToString());
            return indext.p6;
        }

        public int  contar7()
        {
            ConexionDAO conex = new ConexionDAO();
            usuarioBO indext = new usuarioBO();
            String strBuscar = string.Format("select COUNT(*) as 'c' from [Puntos-peligrosos] where id_peligro=9 and Estatus=0");
            DataTable datos = conex.ejercutarsentrenciasdatable(strBuscar);
            DataRow row = datos.Rows[0];
            indext.p7 = int.Parse(row["c"].ToString());
            return indext.p7;
        }

        public int contar8()
        {
            ConexionDAO conex = new ConexionDAO();
            usuarioBO indext = new usuarioBO();
            String strBuscar = string.Format("select COUNT(*) as 'c' from [Puntos-peligrosos] where id_peligro=10 and Estatus=0");
            DataTable datos = conex.ejercutarsentrenciasdatable(strBuscar);
            DataRow row = datos.Rows[0];
            indext.p8 = int.Parse(row["c"].ToString());
            return indext.p8;
        }

        public int usua()
        {
            ConexionDAO conex = new ConexionDAO();
            usuarioBO indext = new usuarioBO();
            String strBuscar = string.Format(" select COUNT(*)  as 'c' from Usuario where id_tipo=1 ");
            DataTable datos = conex.ejercutarsentrenciasdatable(strBuscar);
            DataRow row = datos.Rows[0];
            indext.usua = int.Parse(row["c"].ToString());
            return indext.usua;
        }

        public int cuentaspunt()
        {
            ConexionDAO conex = new ConexionDAO();
            usuarioBO indext = new usuarioBO();
            String strBuscar = string.Format(" select COUNT(*)  as 'c' from [Puntos-peligrosos] where Estatus=0");
            DataTable datos = conex.ejercutarsentrenciasdatable(strBuscar);
            DataRow row = datos.Rows[0];
            indext.puntoss = int.Parse(row["c"].ToString());
            return indext.puntoss;
        }
    }
}