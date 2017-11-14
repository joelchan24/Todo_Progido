using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Proyecto.DAO;
using Proyecto.BO;

namespace Proyecto.DAO
{
    public class BackEndDAO
    {
        ConexionDAO Conex = new ConexionDAO();


        public usuarioBO ObtenerDatosIndex()
        {
            var index = new usuarioBO();
            String strBuscar = string.Format("SELECT t1,t2,t3,te1,te2,te3 FROM indext");
            DataTable datos = Conex.ejercutarsentrenciasdatable(strBuscar);
            DataRow row = datos.Rows[0];
            
            index.t1 = row["t1"].ToString();
            index.t2 = row["t2"].ToString();
            index.t3 = row["t3"].ToString();
            index.te1 = row["te1"].ToString();
            index.te2 = row["te2"].ToString();
            index.te3 = row["te3"].ToString();


            return index;
        }
    }
}