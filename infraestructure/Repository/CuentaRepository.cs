using Dapper;
using infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infraestructure.Repository
{
    public class CuentaRepository
    {
        private string _connectionString;
        private Npgsql.NpgsqlConnection connection;
        public CuentaRepository(string connectionString)
        {
            this._connectionString = connectionString;
            this.connection = new Npgsql.NpgsqlConnection(this._connectionString);
        }

        public string insertarCuenta(CuentaModel cuenta)
        {
            try
            {
                connection.Execute("insert into cuenta(idCuenta, nombreCuenta,numeroCuenta, saldo, limiteSaldo, " +
                    "limiteTransferencia, estado)" +
                    " values(@idCuenta, @nombreCuenta, @numeroCuenta,@saldo,@limiteSaldo,  " +
                    "@limiteTransferencia, @estado)", cuenta);
                return "Se inserto correctamente...";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public string modificarCuenta(CuentaModel cuenta, int id)
        {
            try
            {
                connection.Execute($"UPDATE cuenta SET " +
                    "idCuenta = @idCuenta," +
                    "nombreCuenta = @nombreCuenta, " +
                    "numeroCuenta = @numeroCuenta," +
                    "saldo = @saldo," +
                    "limiteSaldo = @limiteSaldo," +
                    "limiteTransferencia = @limiteTransferencia, " +
                    "estado = @estado "+ //cuidado con el espacio despues del ultimo campo, ese espacio se debe reservar para separar del where
                    $"WHERE id = {id}", cuenta);
                return "Se modificaron los datos correctamente...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string eliminarCuenta(int id)
        {
            try
            {
                connection.Execute($" DELETE FROM cuenta WHERE id = {id}");
                return "Se eliminó correctamente el registro...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CuentaModel consultarCuenta(int id)
        {
            try
            {
                return connection.QueryFirst<CuentaModel>($"SELECT * FROM cuenta WHERE id = {id}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<CuentaModel> listarCuenta()
        {
            try
            {
                return connection.Query<CuentaModel>($"SELECT * FROM cuenta order by id asc");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
