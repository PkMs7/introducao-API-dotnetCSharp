using exemploAPI1.Context;
using exemploAPI1.Models;
using Microsoft.AspNetCore.Mvc;

namespace exemploAPI1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context){

            _context = context;

        }

        [HttpPost()]
        public IActionResult Create(Contato contato){

            _context.Add(contato);
            _context.SaveChanges();
            return Ok(contato);

        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id){

            var contato = _context.Contatos.Find(id);

            if(contato == null){
                return NotFound();
            }
            return Ok(contato);

        }

        [HttpGet("ObterPorNome/{nome}")]
        public IActionResult ObterPorNome(string nome){

            var contato = _context.Contatos.Where(x => x.Nome.Contains(nome));

            return Ok(contato);

        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato){

            var contatoBanco = _context.Contatos.Find(id);
            
            if(contato == null){
                return NotFound();
            }

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Status = contato.Status;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);

        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id){

            var contatoBanco = _context.Contatos.Find(id);
            
            if(contatoBanco == null){
                return NotFound();
            }

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            return NoContent();

        }
    }
}