using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.BO
{
    public class mensajeBO
    {
        public int ID { get; set; }
        public string mensaje { get; set; }
        public int id_remitente { get; set; }
        public int id_destinatario { get; set; }
        public int status { get; set; }
    }
}