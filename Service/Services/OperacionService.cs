using infraestructure.Repository;
using infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OperacionService
    {
        private OperacionService operacionService;

        private CuentaRepository cuentaRepository;

        public OperacionService(CuentaRepository cuentaRepository)
        {
            this.cuentaRepository = cuentaRepository;
        }

        public string Transfer(int sourceAccountId, int targetAccountId, double amount)
        {
            var sourceAccount = cuentaRepository.consultarCuenta(sourceAccountId);
            var targetAccount = cuentaRepository.consultarCuenta(targetAccountId);

            if (sourceAccount.Id == targetAccount.Id)
            {
                throw new ArgumentException("No se puede transferir en la misma cuenta");
            }

            if (sourceAccount.Estado == "I" || targetAccount.Estado == null)
            {
                throw new ArgumentException("Cuenta invalida o inhabilitada");
            }

            if (sourceAccount.LimiteTransferencia < amount || targetAccount.LimiteSaldo < (targetAccount.Saldo + amount))
            {
                throw new ArgumentException("Desbordamiento de limite de transferencia o limite de saldo");
            }

            if (sourceAccount.Saldo < amount)
            {
                throw new InvalidOperationException("Saldo insuficiente");
            }

            sourceAccount.Saldo -= amount;
            targetAccount.Saldo += amount;

            cuentaRepository.modificarCuenta(sourceAccount, sourceAccountId);
            cuentaRepository.modificarCuenta(targetAccount, targetAccountId);
            return "Transferencia exitosa!";
        }

        public string Deposit(double amount, int accountId)
        {
            var account = cuentaRepository.consultarCuenta(accountId);
            if (account.Estado == null)
            {
                throw new ArgumentException("Cuenta invalida o inhabilitada");
            }
            if (account.LimiteSaldo < (account.Saldo + amount))
            {
                throw new ArgumentException("Limite de saldo superado");
            }
            account.Saldo += amount;

            cuentaRepository.modificarCuenta(account, accountId);

            return "Deposito exitoso!";
        }

        public string Devolution(double amount, int accountId)
        {
            var account = cuentaRepository.consultarCuenta(accountId);
            if (account.Estado == "I")
            {
                throw new ArgumentException("Cuenta invalida o inhabilitada");
            }
            if (account.Saldo < amount)
            {
                throw new InvalidOperationException("Saldo insuficiente");
            }
            account.Saldo -= amount;
            cuentaRepository.modificarCuenta(account, accountId);
            return "Devolucion exitosa!";
        }

        public string Extract(double amount, int accountId)
        {
            var account = cuentaRepository.consultarCuenta(accountId);
            if (account.Estado == "I")
            {
                throw new ArgumentException("Cuenta invalida o inhabilitada");
            }
            if (account.Saldo < amount)
            {
                throw new InvalidOperationException("Saldo insuficiente");
            }
            account.Saldo -= amount;
            cuentaRepository.modificarCuenta(account, accountId);

            var updatedAccount = cuentaRepository.consultarCuenta(accountId);

            return "Extraccion exitosa! Su saldo restante es: " + updatedAccount.Saldo;

        }

        public string Block(int accountId)
        {
            var account = cuentaRepository.consultarCuenta(accountId);
            if (account == null)
            {
                throw new ArgumentException("Invalid account ID");
            }

            account.Estado = "I";

            cuentaRepository.modificarCuenta(account, accountId);

            var updatedAccount = cuentaRepository.consultarCuenta(accountId);

            return "Cuenta bloqueada exitosamente";

        }
    }
}
