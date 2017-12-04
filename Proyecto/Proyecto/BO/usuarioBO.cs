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
        [Required(ErrorMessage = "Campo Requerido")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string apellido { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string sexo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string contraseña { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime fecha { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int id_tipo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string telefono { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string correo { get; set; }

        public byte[] foto { get; set; }


        //Seccion de contactos
        public int idcontacto { get; set; }
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


        //Seccion de index

        public byte[]imagenbanner { get; set; }
        public string textopresentacion { get; set; }
        public string titulopresentacion { get; set; }
        public string tituloizquierda { get; set; }
        public byte[] imagenizquierda { get; set; }
        public string textoizquierda { get; set; }
        public byte[] imagenderecha { get; set; }
        public string textoderecha { get; set; }
        public string tituloderecha { get; set; }

        //seccion 
        public string nom1 { get; set; }
        public string nom2 { get; set; }
        public string nom3 { get; set; }

        public string rol1 { get; set; }
        public string rol2 { get; set; }
        public string rol3 { get; set; }
        public string r1 { get; set; }
        public string re1 { get; set; }
        public string red1 { get; set; }

        public string r2 { get; set; }
        public string re2 { get; set; }
        public string red2 { get; set; }

        public string r3 { get; set; }
        public string re3 { get; set; }
        public string red3 { get; set; }

        public byte[] foto1 { get; set; }
        public byte[] foto2 { get; set; }
        public byte[] foto3 { get; set; }

        public int p1 { get; set; }
        public int p2 { get; set; }
        public int p3 { get; set; }
        public int p4 { get; set; }
        public int p5 { get; set; }
        public int p6 { get; set; }
        public int p7 { get; set; }
        public int p8 { get; set; }


        public int usua { get; set; }

        public int puntoss { get; set; }


    }
}