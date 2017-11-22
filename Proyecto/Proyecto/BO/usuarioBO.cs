using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.BO
{
    public class usuarioBO
    {
        public int id { get; set; }
    
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string sexo { get; set; }
        public string contraseña { get; set; }
     
        public DateTime  fecha  { get; set; }
        public int id_tipo { get; set; }
        
        public string telefono { get; set; }
      
        public string correo { get; set; }
  
        public byte[] foto { get; set; }

    }
}