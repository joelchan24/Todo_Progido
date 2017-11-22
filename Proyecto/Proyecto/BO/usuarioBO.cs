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


        //Seccion de contactos
        public string idcontacto { get; set; }
        public string nombrecontacto1 { get; set; }
        public string mensajecontacto1 { get; set; }
        public string telefonocontacto1 { get; set; }
        public string correocontacto1 { get; set; }
        public string nombrecontacto2 { get; set; }
        public string mensajecontacto2 { get; set; }
        public string telefonocontacto2 { get; set; }
        public string correocontacto2 { get; set; }
        public string nombrecontacto3 { get; set; }
        public string mensajecontacto3 { get; set; }
        public string telefonocontacto3 { get; set; }
        public string correocontacto3 { get; set; }
        public string nombrecontacto4 { get; set; }
        public string mensajecontacto4 { get; set; }
        public string telefonocontacto4 { get; set; }
        public string correocontacto4 { get; set; }
        public string nombrecontacto5 { get; set; }
        public string mensajecontacto5 { get; set; }
        public string telefonocontacto5 { get; set; }
        public string correocontacto5 { get; set; }
        public string nombrecontacto6 { get; set; }
        public string mensajecontacto6 { get; set; }
        public string telefonocontacto6 { get; set; }
        public string correocontacto6 { get; set; }
        public string idusuariocontacto { get; set; }



    }
}