using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infraestructure.Models
{
    public class PersonaModel
    {
        //public int Id { get; set; }

        //[Required]
        //[MinLength(3)]
        //public string Nombre { get; set; }
        //public string Apellido { get; set; }
        //public string TipoDocumento { get; set; }
        //public string Documento { get; set; }
        //public string Direccion { get; set; }
        //public string Email { get; set; }
        //public string Telefono { get; set; }
        //public string Estado { get; set; }
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string TipoDocumento { get; set; }

        public string Documento { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Mail { get; set; }

        [ForeignKey("Cuenta")]
        public int Estado { get; set; }

        //public CuentaModel Cuenta { get; set; }

    }
}
