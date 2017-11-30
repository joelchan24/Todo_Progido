using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto.DAO;
using Proyecto.BO;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.DAO
{
    public class mensajeDAO
    {
        Conexion_DAOcomant conectar = new Conexion_DAOcomant();
        public int Guardar(object agregar, int id_deso)
        {
            mensajeBO usuario = (mensajeBO)agregar;
          
            SqlCommand cmd = new SqlCommand("insert into [mansaje_pagina] ([mensaje],[id_remitente],[id_destinatario],[estatus])values(@mensaje,@id_remi,@id_destina,@id_estatus)");
            usuario.mensaje = "ddd";
            cmd.Parameters.Add("@mensaje", SqlDbType.VarChar).Value = usuario.mensaje;
            cmd.Parameters.Add("@id_remi", SqlDbType.Int).Value = id_deso;
            cmd.Parameters.Add("@id_destina", SqlDbType.Int).Value = usuario.id_destinatario;
            cmd.Parameters.Add("@id_estatus", SqlDbType.Int).Value =0;
        
       
            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarComando(cmd);



        }
        public int eliminar(int id)
        {

            SqlCommand comando = new SqlCommand("delete from mansaje_pagina where id=@id");
            comando.Parameters.Add("@id", SqlDbType.Int).Value = id;
            comando.CommandType = CommandType.Text;
            return conectar.EjecutarComando(comando);

        }
        public int editar(object edi)
        {
            mensajeBO usuario = (mensajeBO)edi;
            SqlCommand cmd = new SqlCommand("update  mansaje_pagina set mensaje=@mensaje where id=@id");

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
               cmd.Parameters.Add("@mensaje", SqlDbType.Text).Value = usuario.mensaje;
           
            cmd.CommandType = CommandType.Text;
            return conectar.EjecutarComando(cmd);

        }
        public DataSet mostrar()
        {

            SqlCommand comando = new SqlCommand("  select * from mansaje_pagina");

            comando.CommandType = CommandType.Text;
            return conectar.EjecutarSentencia(comando);

        }









    }
}