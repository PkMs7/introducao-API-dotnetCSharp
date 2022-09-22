using Microsoft.AspNetCore.Mvc;

namespace exemploAPI1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("ObterDataHoraAtual")]
        public IActionResult ObterDataHora(){

            var obj = new {

                Data = DateTime.Now.ToLongDateString(),
                Hora = DateTime.Now.ToShortTimeString()

            };

            return Ok(obj);

        }

        [HttpGet("Arepsentar/{nome}")]
        public IActionResult Apresentar(string nome){

            var mensagem = $"Olá {nome}! Seja bem vindo!";

            return Ok(new { mensagem });
        }
    }
}