using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.BO
{
    public class usuarioBO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string contraseña { get; set; }
        public DateTime  fecha  { get; set; }
        public int id_tipo { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string facebook { get; set; }
        public string facebook2 { get; set; }
    }
}
