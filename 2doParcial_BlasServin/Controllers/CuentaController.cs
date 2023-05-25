using infraestructure.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace _2doParcial_BlasServin.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CuentaController : Controller
    {
        private CuentaService cuentaService;
        private IConfiguration configuration;
        public CuentaController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.cuentaService = new CuentaService(configuration.GetConnectionString("postgresDB"));
        }
        [HttpGet("ListarCuenta")]
        public ActionResult<List<CuentaModel>> listarCuentas()
        {
            var resultado = cuentaService.listarCuenta();
            return Ok(resultado);
        }

        [HttpGet("ConsultarCuenta/{id}")]
        public ActionResult<CuentaModel> consultarCuenta(int id)
        {
            var resultado = this.cuentaService.consultarCuenta(id);
            return Ok(resultado);
        }

        [HttpPost("InsertarCuenta")]
        public ActionResult<string> insertarCuenta(CuentaModel modelo)
        {
            var resultado = this.cuentaService.insertarCuenta(new infraestructure.Models.CuentaModel
            {
                IdCuenta=modelo.IdCuenta,
                NombreCuenta=modelo.NombreCuenta,
                NumeroCuenta=modelo.NumeroCuenta,   
                Saldo= modelo.Saldo,
                LimiteSaldo= modelo.LimiteSaldo,
                LimiteTransferencia=modelo.LimiteTransferencia,
                Estado = modelo.Estado

            });
            return Ok(resultado);
        }

        [HttpPut("ModificarCuenta/{id}")]
        public ActionResult<string> modificarCuenta(CuentaModel modelo, int id)
        {
            var resultado = this.cuentaService.modificarCuenta(new infraestructure.Models.CuentaModel
            {
                IdCuenta = modelo.IdCuenta,
                NombreCuenta = modelo.NombreCuenta,
                NumeroCuenta = modelo.NumeroCuenta,
                Saldo = modelo.Saldo,
                LimiteSaldo = modelo.LimiteSaldo,
                LimiteTransferencia = modelo.LimiteTransferencia,
                Estado = modelo.Estado

            }, id);
            return Ok(resultado);
        }

        [HttpDelete("EliminarCuenta/{id}")]
        public ActionResult<string> eliminarCuenta(int id)
        {
            var resultado = this.cuentaService.eliminarCuenta(id);
            return Ok(resultado);
        }
    }
}
