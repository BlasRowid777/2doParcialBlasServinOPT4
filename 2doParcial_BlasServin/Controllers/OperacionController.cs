using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace _2doParcial_BlasServin.Controllers
{

    [ApiController]
    [Route("api/[controller]")] // This is the route
    public class OperacionController : Controller
    {
        private OperacionService operacionService;
        public OperacionController(OperacionService operacionService)
        {
            this.operacionService = operacionService;
        }

        [HttpPut("{sourceAccountId}/Transferir/{targetAccountId}")]
        public ActionResult Transfer(int sourceAccountId, int targetAccountId, double amount)
        {
            try
            {
                var result = operacionService.Transfer(sourceAccountId, targetAccountId, amount);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred" + ex);
            }
        }

        [HttpPut("Depositar/{targetAccountId}")]
        public ActionResult Deposit(double amount, int targetAccountId)
        {
            try
            {
                var result = operacionService.Deposit(amount, targetAccountId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred");
            }
        }

        [HttpPut("Devolución/{targetAccountId}")]
        public ActionResult Devolution(double amount, int targetAccountId)
        {
            try
            {
                var result = operacionService.Devolution(amount, targetAccountId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred");
            }
        }

        [HttpPut("Extracción/{targetAccountId}")]
        public ActionResult Extract(double amount, int targetAccountId)
        {
            try
            {
                var result = operacionService.Extract(amount, targetAccountId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred");
            }
        }

        [HttpDelete("Bloquear/{targetAccountId}")]
        public ActionResult Block(int targetAccountId)
        {
            try
            {
                var result = operacionService.Block(targetAccountId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred");
            }
        }
    }
}
