using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.BO
{
    public class punto_peligrosoBO
    { 
        public int id { get; set; }
        public int id_peligro { get; set; }
        public string longitud { get; set; }
        public string latitud { get; set; }


        public string zona { get; set; }
        public int id_usuario { get; set; }


        public byte status { get; set; }
        public DateTime fecha { get; set; }
        public string imagen { get; set; }


        public string url { get; set; }
        public string comentario { get; set; }
        public string tipo_peligro { get; set; }



        public string nombre_usuario { get; set; }

        public string ruta { get; set; }





    }
}