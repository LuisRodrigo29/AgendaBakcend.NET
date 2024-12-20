using AgendaAPI.ModelEntry;
using DTO;
using Interfaz;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConsultar _IConsultar;
        private readonly ISecurity _ISecurity;


        public LoginController(IConsultar IConsultar, ISecurity iSecurity)
        {
            _IConsultar = IConsultar;
            _ISecurity = iSecurity;
        }


        /// <summary>
        /// Metodo para hacer login en el sistema
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login([FromBody] LoginEntry log)
        {
            try
            {
                DataTable tblResult = _IConsultar.Login(log.usuario, log.contrasena);
                
                Entities.Resultado<DTOResultadoLogin> resultado = new Entities.Resultado<DTOResultadoLogin>();

                string token = _ISecurity.GetToken(tblResult, log.usuario, log.contrasena);

                DTOResultadoLogin dto = new DTOResultadoLogin(token, 200);

                resultado.resultado = dto;

                return Ok(resultado);

            }catch (Exception ex)
            {
                Entities.Resultado<DTOErrores> errores = new Entities.Resultado<DTOErrores>();

                DTOErrores dtoErrors = new DTOErrores(ex.Message, ex.StackTrace, Convert.ToString(ex.InnerException));

                errores.resultado = dtoErrors;

                return BadRequest(errores);
            }
        }
    }
}
