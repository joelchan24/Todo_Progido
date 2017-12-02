using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace Proyecto.DAO
{
    public class Conexion_DAOcomant
    {
        SqlCommand comandosql;
        SqlDataAdapter adaptador;
        DataSet datasetadaptador;
        SqlConnection coneccion;

        //DESKTOP-TT12AGM
        public Conexion_DAOcomant()
        {
            adaptador = new SqlDataAdapter();
            comandosql = new SqlCommand();
            coneccion = new SqlConnection();



        }

        public SqlConnection establecerConexion()
        {
            //string cs = "Data Source=KAREN\\SQLEXPRESS; Initial catalog=ProyectoSOS;  integrated security=true";
            //string cs = "Data Source=DESKTOP-TT12AGM; Initial catalog=ProyectoSOS;  integrated security=true";
            //string cs = "Data Source=KAREN\\SQLEXPRESS; Initial catalog=ProyectoSOS;  integrated security=true";
            string cs = "Data Source=adan--pc; Initial catalog=ProyectoSOS;  integrated security=true";

            coneccion = new SqlConnection(cs);
            return coneccion;
        }


        public void abrirConexion()
        {
            coneccion.Open();
        }
        public void cerrarConexion()
        {
            coneccion.Close();
        }
        public DataSet EjecutarSentencia(SqlCommand SqlComando)
        {

            // SELECT (Devolver registros)
            adaptador = new SqlDataAdapter();
            comandosql = new SqlCommand();
            datasetadaptador = new DataSet();

            comandosql = SqlComando;
            comandosql.Connection = this.establecerConexion();
            this.abrirConexion();
            adaptador.SelectCommand = comandosql;
            adaptador.Fill(datasetadaptador);
            this.cerrarConexion();
            return datasetadaptador;

        }
        public int EjecutarComando(SqlCommand SqlComando)
        {
            // INSERT, DELETE, UPDATE
            comandosql = new SqlCommand();
            comandosql = SqlComando;
            comandosql.Connection = this.establecerConexion();
            this.abrirConexion();
            int id = 0; id = Convert.ToInt32(comandosql.ExecuteScalar());
            this.cerrarConexion();
            return id;

        }

    }
}