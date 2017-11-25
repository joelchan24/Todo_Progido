using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Proyecto.BO;

namespace Proyecto.DAO
{
    public class tipo_peligroDAO
    {
        Conexion_DAOcomant conectar = new Conexion_DAOcomant();
        ConexionDAO marisa = new ConexionDAO();
        public int Guardar(object agregar)
        {
            PeligroBO peligro = (PeligroBO)agregar;
           

            SqlCommand cmd = new SqlCommand("insert into [niveles-peligro](Peligro)values (@peligro)");

            cmd.Parameters.Add("@peligro", SqlDbType.VarChar).Value = peligro.tipo;
            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarComando(cmd);



        }
        public int eliminar(int id)
        {

            SqlCommand comando = new SqlCommand("delete from [niveles-peligro] where id=@id");
            comando.Parameters.Add("@id", SqlDbType.Int).Value = id;
            comando.CommandType = CommandType.Text;
            return conectar.EjecutarComando(comando);

        }
        public int editar(object actualizar)
        {

            PeligroBO peligro = (PeligroBO)actualizar;
            SqlCommand comando = new SqlCommand("update [niveles-peligro] set peligro=@peligro where id=@id");
            comando.Parameters.Add("@id", SqlDbType.Int).Value = peligro.id;
            comando.Parameters.Add("@peligro", SqlDbType.VarChar).Value = peligro.tipo;
            comando.CommandType = CommandType.Text;
            return conectar.EjecutarComando(comando);

        }
        public DataSet mostrar()
        {

            SqlCommand comando = new SqlCommand("select * from  [niveles-peligro] ");

            comando.CommandType = CommandType.Text;
            return conectar.EjecutarSentencia(comando);
        }


        public List<PeligroBO>peligros()
        {
            var alumnos = new List<PeligroBO>();
            String strBuscar = string.Format("select * from  [niveles-peligro]");
            return alumnos = marisa.EjecutarSetencialist_peligrososos(strBuscar);
        }
    }
}