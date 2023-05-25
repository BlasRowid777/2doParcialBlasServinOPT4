using infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace _2doParcial_BlasServin.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PersonaController : Controller
    {
        private PersonaService personaService;
        private IConfiguration configuration;
        public PersonaController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.personaService = new PersonaService(configuration.GetConnectionString("postgresDB"));
        }
        [HttpGet("ListarPersona")]
        public ActionResult<List<PersonaModel>> listarPersonas()
        {
            var resultado = personaService.listarPersona();
            return Ok(resultado);
        }

        [HttpGet("ConsultarPersona/{id}")]
        public ActionResult<PersonaModel> consultarPersona(int id)
        {
            var resultado = this.personaService.consultarPersona(id);
            return Ok(resultado);
        }

        [HttpPost("InsertarPersona")]
        public ActionResult<string> insertarPersona(PersonaModel modelo)
        {
            var resultado = this.personaService.insertarPersona(new infraestructure.Models.PersonaModel
            {
                Nombre = modelo.Nombre,
                Apellido = modelo.Apellido,
                TipoDocumento = modelo.TipoDocumento,
                Documento = modelo.Documento,
                Direccion = modelo.Direccion,
                Telefono = modelo.Telefono,
                Mail = modelo.Mail,
                Estado  = modelo.Estado

            });
            return Ok(resultado);
        }

        [HttpPut("ModificarPersona/{id}")]
        public ActionResult<string> modificarPersona(PersonaModel modelo, int id)
        {
            var resultado = this.personaService.modificarPersona(new infraestructure.Models.PersonaModel
            {
                Nombre = modelo.Nombre,
                Apellido = modelo.Apellido,
                TipoDocumento = modelo.TipoDocumento,
                Documento = modelo.Documento,
                Direccion = modelo.Direccion,
                Telefono = modelo.Telefono,
                Mail = modelo.Mail,
                Estado = modelo.Estado

            }, id);
            return Ok(resultado);
        }

        [HttpDelete("EliminarPersona/{id}")]
        public ActionResult<string> eliminarPersona(int id)
        {
            var resultado = this.personaService.eliminarPersona(id);
            return Ok(resultado);
        }
    }
}
