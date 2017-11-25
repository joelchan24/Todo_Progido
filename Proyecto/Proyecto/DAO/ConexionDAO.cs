using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using Proyecto.BO;
namespace Proyecto.DAO
{
    public class ConexionDAO
    {

        SqlCommand comandosql;
        SqlDataAdapter adaptador;
        DataSet datasetadaptador;
        SqlConnection coneccion;




        public SqlConnection establecerConexion()
        {
            string cs = "Data Source=DESKTOP-TT12AGM; Initial catalog=ProyectoSOS;  integrated security=true";
            //string cs = "Data Source=DESKTOP-TT12AGM; Initial catalog=ProyectoSOS;  integrated security=true";
            //string cs = "Data Source=ADAN--PC; Initial catalog=ProyectoSOS;  integrated security=true";

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
        public DataSet ejecutarsentenciastring(string sentencia)
        {
            //metodo para utilizar select's
            datasetadaptador = new DataSet();
            comandosql.CommandText = sentencia;

            comandosql.Connection = this.coneccion;
            this.abrirConexion();
            adaptador.SelectCommand = comandosql;
            adaptador.Fill(datasetadaptador);

            return datasetadaptador;
        }
        public DataTable EjercutarSentenciaBus(String strSql) //SELECT
        {
            establecerConexion();
            SqlDataAdapter adapter = new SqlDataAdapter(strSql, this.coneccion);
            DataTable tabla = new DataTable();
            abrirConexion();
            //rellenar un objeto DataSet con los resultados del elemento SelectCommand
            adapter.Fill(tabla);
            cerrarConexion();
            return tabla;
        }
        //dos maneras de hacer select 
        public DataTable ejercutarsentrenciasdatable(string sql)
        {
            //select
            SqlDataAdapter adapter = new SqlDataAdapter(sql, establecerConexion());
            DataTable tabla = new DataTable();
            //llenar los elemetos dataset 
            abrirConexion();
            adapter.Fill(tabla);
            cerrarConexion();
            return tabla;
        }
        public List<punto_peligrosoBO> EjecutarSetencialist_puntos(String strSql)

        {

            var peli = new List<punto_peligrosoBO>();
            establecerConexion();

            this.abrirConexion();

            var query = new SqlCommand(strSql, this.coneccion);

            using (var dr = query.ExecuteReader())

            {

                while (dr.Read())

                {

                    // Usuario

                    var val = new punto_peligrosoBO

                    {

                        id = Convert.ToInt32(dr["clave"]),

                    nom_imagen =Convert.ToDateTime(dr["fecha"]).ToString("yyyy-MM-dd"),

                        zona = dr["zona"].ToString(),

                        comentario = dr["comentario"].ToString(),
                        tipo_peligro = dr["peli"].ToString()


                    };



                    // Agregamos el usuario a la lista genreica

                    peli.Add(val);

                }

            }

            this.cerrarConexion();

            return peli;

        }
        public List<punto_peligrosoBO> EjecutarSetencialist_puntos_noaprovados(String strSql)

        {

            var peli = new List<punto_peligrosoBO>();
            establecerConexion();

            this.abrirConexion();

            var query = new SqlCommand(strSql, this.coneccion);

            using (var dr = query.ExecuteReader())

            {

                while (dr.Read())

                {

                    // Usuario

                    var val = new punto_peligrosoBO

                    {

                        id = Convert.ToInt32(dr["clave"]),

                        fecha = Convert.ToDateTime(dr["fecha1"]),

                        zona = dr["zona"].ToString(),
                        nombre_usuario = dr["usuario"].ToString(),

                        //  comentario = dr["comentario"].ToString(),
                        tipo_peligro = dr["peli"].ToString()


                    };



                    // Agregamos el usuario a la lista genreica

                    peli.Add(val);

                }

            }

            this.cerrarConexion();

            return peli;

        }
        public List<PeligroBO> EjecutarSetencialist_peligrososos(String strSql)

        {

            var peli = new List<PeligroBO>();
            establecerConexion();

            this.abrirConexion();

            var query = new SqlCommand(strSql, this.coneccion);

            using (var dr = query.ExecuteReader())

            {

                while (dr.Read())

                {

                    // Usuario

                    var val = new PeligroBO

                    {

                        id = Convert.ToInt32(dr["id"]),

                      
                        tipo = dr["peligro"].ToString()


                    };



                    // Agregamos el usuario a la lista genreica

                    peli.Add(val);

                }

            }

            this.cerrarConexion();

            return peli;

        }
        public List<punto_peligrosoBO> EjecutarSetencialist_puntos_aprovados(String strSql)

        {

            var peli = new List<punto_peligrosoBO>();
            establecerConexion();

            this.abrirConexion();

            var query = new SqlCommand(strSql, this.coneccion);

            using (var dr = query.ExecuteReader())

            {

                while (dr.Read())

                {

                    // Usuario

                    var val = new punto_peligrosoBO

                    {
                        id = Convert.ToInt32(dr["clave"]),

                        fecha = Convert.ToDateTime(dr["fecha1"]),

                        zona = dr["zona"].ToString(),
                        nombre_usuario = dr["usuario"].ToString(),

                        //  comentario = dr["comentario"].ToString(),
                        tipo_peligro = dr["peli"].ToString()



                    };



                    // Agregamos el usuario a la lista genreica

                    peli.Add(val);

                }

            }

            this.cerrarConexion();

            return peli;

        }
        public int ejecutarSentencia1(String strSql) //insert,update, delete
        {
            try
            {
                //donde se asigna el texto de la instrucción SQL a ser ejecutada en el servidor
                this.comandosql.CommandText = strSql;
                this.establecerConexion();
                //donde se asigna el objeto de conexión construido con SqlConnection
                this.comandosql.Connection = this.coneccion;
                this.abrirConexion();
                // indicar la ejecución de la instrucción SQL definida en CommandText, devuelve un valor entero que indica las filas afectadas
                this.comandosql.ExecuteNonQuery();
                this.cerrarConexion();
                return 1;

            }
            catch (SqlException)
            {
                return 0;
            }
            finally
            {
                this.cerrarConexion();
            }

        }
        public int ejecutarComandostring(string comando)
        {
            //string strcomandoSQL = comando;
            comandosql.Connection = this.establecerConexion();
            this.abrirConexion();
            comandosql.CommandText = comando;

            int id = 0; id = (Convert.ToInt32(comandosql.ExecuteScalar()) != 0) ? Convert.ToInt32(comandosql.ExecuteScalar()) : 0;


            this.cerrarConexion();

            return id;
        }
        public List<SelectListItem> EjecutarSetencialistEst1(String strSql)
        {
            var peligros = new List<SelectListItem>();
            establecerConexion();
            this.abrirConexion();
            var query = new SqlCommand(strSql, this.coneccion);
            using (var dr = query.ExecuteReader())
            {
                while (dr.Read())
                {

                    var estados = new SelectListItem
                    {
                        Text = dr["Peligro"].ToString(),
                        Value = dr["ID"].ToString()
                    };


                    peligros.Add(estados);
                }
            }
            this.cerrarConexion();
            return peligros;
        }


    }
  
}
