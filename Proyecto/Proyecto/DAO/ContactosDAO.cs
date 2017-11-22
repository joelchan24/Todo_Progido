using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Proyecto.BO;

namespace Proyecto.DAO
{
    public class ContactosDAO
    {
        ConexionDAO Conex = new ConexionDAO();
        Conexion_DAOcomant conec = new Conexion_DAOcomant();
        public usuarioBO ObtenerContactos()
        {
            var cont = new usuarioBO();
            String strBuscar = string.Format("SELECT ID,Nombre,Mensaje,Telefono,Correo,Nombre2,Mensaje2,Telefono2,Correo2,Nombre3,Mensaje3,Telefono3,Correo3,Nombre4,Mensaje4,Telefono4,Correo4,Nombre5,Mensaje5,Telefono5,Correo5,Nombre6,Mensaje6,Telefono6,Correo6,id_usuario FROM Contactos");
            DataTable datos = Conex.ejercutarsentrenciasdatable(strBuscar);
            DataRow row = datos.Rows[0];

            //cont.idcontacto = row["ID"].ToString();
            cont.idcontacto = Convert.ToInt32(row["ID"]);
            cont.nombrecontacto1 = row["Nombre"].ToString();
            cont.mensajecontacto1 = row["Mensaje"].ToString();
            cont.telefonocontacto1 = row["Telefono"].ToString();
            cont.correocontacto1 = row["Correo"].ToString();
            cont.nombrecontacto2 = row["Nombre2"].ToString();
            cont.mensajecontacto2 = row["Mensaje2"].ToString();
            cont.telefonocontacto2 = row["Telefono2"].ToString();
            cont.correocontacto2 = row["Correo2"].ToString();
            cont.nombrecontacto3 = row["Nombre3"].ToString();
            cont.mensajecontacto3 = row["Mensaje3"].ToString();
            cont.telefonocontacto3 = row["Telefono3"].ToString();
            cont.correocontacto3 = row["Correo3"].ToString();
            cont.nombrecontacto4 = row["Nombre4"].ToString();
            cont.mensajecontacto4 = row["Mensaje4"].ToString();
            cont.telefonocontacto4 = row["Telefono4"].ToString();
            cont.correocontacto4 = row["Correo4"].ToString();
            cont.nombrecontacto5 = row["Nombre5"].ToString();
            cont.mensajecontacto5 = row["Mensaje5"].ToString();
            cont.telefonocontacto5 = row["Telefono5"].ToString();
            cont.correocontacto5 = row["Correo5"].ToString();
            cont.nombrecontacto6 = row["Nombre6"].ToString();
            cont.mensajecontacto6 = row["Mensaje6"].ToString();
            cont.telefonocontacto6 = row["Telefono6"].ToString();
            cont.correocontacto6 = row["Correo6"].ToString();
            cont.idusuariocontacto = row["id_usuario"].ToString();
            return cont;
        }
        public usuarioBO Obtener(int id)
        {
            var cont = new usuarioBO();
            String strBuscar = string.Format("SELECT ID,Nombre,Mensaje,Telefono,Correo,Nombre2,Mensaje2,Telefono2,Correo2,Nombre3,Mensaje3,Telefono3,Correo3,Nombre4,Mensaje4,Telefono4,Correo4,Nombre5,Mensaje5,Telefono5,Correo5,Nombre6,Mensaje6,Telefono6,Correo6,id_usuario FROM Contactos where ID="+id);
            DataTable datos = Conex.ejercutarsentrenciasdatable(strBuscar);
            DataRow row = datos.Rows[0];

            //cont.idcontacto = row["ID"].ToString();
            cont.idcontacto = Convert.ToInt32(row["ID"]);
            cont.nombrecontacto1 = row["Nombre"].ToString();
            cont.mensajecontacto1 = row["Mensaje"].ToString();
            cont.telefonocontacto1 = row["Telefono"].ToString();
            cont.correocontacto1 = row["Correo"].ToString();
            cont.nombrecontacto2 = row["Nombre2"].ToString();
            cont.mensajecontacto2 = row["Mensaje2"].ToString();
            cont.telefonocontacto2 = row["Telefono2"].ToString();
            cont.correocontacto2 = row["Correo2"].ToString();
            cont.nombrecontacto3 = row["Nombre3"].ToString();
            cont.mensajecontacto3 = row["Mensaje3"].ToString();
            cont.telefonocontacto3 = row["Telefono3"].ToString();
            cont.correocontacto3 = row["Correo3"].ToString();
            cont.nombrecontacto4 = row["Nombre4"].ToString();
            cont.mensajecontacto4 = row["Mensaje4"].ToString();
            cont.telefonocontacto4 = row["Telefono4"].ToString();
            cont.correocontacto4 = row["Correo4"].ToString();
            cont.nombrecontacto5 = row["Nombre5"].ToString();
            cont.mensajecontacto5 = row["Mensaje5"].ToString();
            cont.telefonocontacto5 = row["Telefono5"].ToString();
            cont.correocontacto5 = row["Correo5"].ToString();
            cont.nombrecontacto6 = row["Nombre6"].ToString();
            cont.mensajecontacto6 = row["Mensaje6"].ToString();
            cont.telefonocontacto6 = row["Telefono6"].ToString();
            cont.correocontacto6 = row["Correo6"].ToString();
            cont.idusuariocontacto = row["id_mensaje"].ToString();
            return cont;
        }
        public int ModificarContactos(usuarioBO ocontacto)
        {
            string sqlExec = string.Format("Update Contactos Set Nombre='" + ocontacto.nombrecontacto1 + "', Mensaje='" + ocontacto.mensajecontacto1 + "', Correo='" + ocontacto.correocontacto1 + "', Telefono='" + ocontacto.telefonocontacto1 + "',Nombre2='" + ocontacto.nombrecontacto2 + "', Mensaje2='" + ocontacto.mensajecontacto2 + "', Correo2='" + ocontacto.correocontacto2 + "', Telefono2='" + ocontacto.telefonocontacto2 + "',Nombre3='" + ocontacto.nombrecontacto3 + "', Mensaje3='" + ocontacto.mensajecontacto3 + "', Correo3='" + ocontacto.correocontacto3 + "', Telefono3='" + ocontacto.telefonocontacto3 + "',Nombre4='" + ocontacto.nombrecontacto4 + "', Mensaje4='" + ocontacto.mensajecontacto4 + "', Correo4='" + ocontacto.correocontacto4 + "', Telefono4='" + ocontacto.telefonocontacto4 + "',Nombre5='" + ocontacto.nombrecontacto5 + "', Mensaje5='" + ocontacto.mensajecontacto5 + "', Correo5='" + ocontacto.correocontacto5 + "', Telefono5='" + ocontacto.telefonocontacto5 + "',Nombre6='" + ocontacto.nombrecontacto6 + "', Mensaje6='" + ocontacto.mensajecontacto6 + "', Correo6='" + ocontacto.correocontacto6 + "', Telefono6='" + ocontacto.telefonocontacto6 + "' Where ID = '" + ocontacto.idcontacto + "'");
            return Conex.ejecutarSentencia1(sqlExec);
        }

    }
}