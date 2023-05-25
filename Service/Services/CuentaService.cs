using infraestructure.Models;
using infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using infraestructure.Repository;

namespace Service.Services
{
    public class CuentaService
    {
        private CuentaRepository repositoryCuenta;

        public CuentaService(string connectionString)
        {
            this.repositoryCuenta = new CuentaRepository(connectionString);
        }

        public string insertarCuenta(CuentaModel Cuenta)
        {
            return validarDatosCuenta(Cuenta) ? repositoryCuenta.insertarCuenta(Cuenta) : throw new Exception("Error en la validacion");
        }

        public string modificarCuenta(CuentaModel Cuenta, int id)
        {
            if (repositoryCuenta.consultarCuenta(id) != null)
                return validarDatosCuenta(Cuenta) ?
                    repositoryCuenta.modificarCuenta(Cuenta, id) :
                    throw new Exception("Error en la validacion");
            else
                return "No se encontraron los datos de esta Cuenta";
        }

        public string eliminarCuenta(int id)
        {
            return repositoryCuenta.eliminarCuenta(id);
        }

        public CuentaModel consultarCuenta(int id)
        {
            return repositoryCuenta.consultarCuenta(id);
        }

        public IEnumerable<CuentaModel> listarCuenta()
        {
            return repositoryCuenta.listarCuenta();
        }

        private bool validarDatosCuenta(CuentaModel Cuenta)
        {
            //if (Cuenta.Nombre.Trim().Length < 2)
            //{
            //    return false;
            //}//
            return true;
        }
    }
}
