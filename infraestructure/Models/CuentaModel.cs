using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infraestructure.Models
{
    public class CuentaModel
    {

        public int Id { get; set; }

        public string IdCuenta { get; set; }

        public string NombreCuenta { get; set; }

        public string NumeroCuenta { get; set; }

        public double Saldo { get; set; }

        public double LimiteSaldo { get; set; }

        public double LimiteTransferencia { get; set; }

        public string Estado { get; set; }
    }
}
