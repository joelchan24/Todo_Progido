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
        [Required(ErrorMessage = "Falta Nombre")]
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string sexo { get; set; }
        public string contraseña { get; set; }
        [Required(ErrorMessage = "Falta Fecha de nacimiento")]
        public DateTime  fecha  { get; set; }
        public int id_tipo { get; set; }
        [Required(ErrorMessage = "Falta Numero Telefonico")]
        public string telefono { get; set; }
        [Required(ErrorMessage = "Falta Correo Electronico")]
        public string correo { get; set; }
        public string facebook { get; set; }
        [Required(ErrorMessage = "Falta Foto")]
        public byte[] foto { get; set; }

    }
}