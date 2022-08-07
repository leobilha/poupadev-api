using Microsoft.AspNetCore.Mvc;
using PoupaDev.API.Controllers;
using PoupaDev.API.Entities;
using PoupaDev.API.Models;
using PoupaDev.API.Persistence;

namespace poupadev_api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ObjetivosFinanceirosController : ControllerBase
    {
        // Injeção de Dependencia 
        private readonly PoupaDevDbContext _context;

        public ObjetivosFinanceirosController(PoupaDevDbContext context)
        {
            _context = context;
        }

        //Comentarios sao exemplos de requisição
        // GET ObjetivosFinanceiros
        [HttpGet]
        public IActionResult GetTodos()
        {
            var objetivos = _context.Objetivos;
            return Ok();
        }

        // GET ObjetivosFinanceiros/1
        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            var objetivo = _context.Objetivos.SingleOrDefault(o => o.Id == id);

            if (objetivo == null)
                return NotFound();

            return Ok(objetivo);
        }

        // POST ObjetivosFinanceiros
        [HttpPost]
        public IActionResult Post(ObjetivosFinanceirosInputModel model)
        {
            var objetivo = new ObjetivoFinanceiro(model.Titulo, model.Descricao, model.ValorObjetivo);

            _context.Objetivos.Add(objetivo);

            var id = objetivo.Id;

            // Monta a url onde pode ser consultado o objetivo criado no Location
            return CreatedAtAction("GetPorId", new { id = id }, model);
        }

        // POST ObjetivosFinanceiros/1/operacoes
        [HttpPost("{id}/operacoes")]
        public IActionResult PostOperacao(int id, OperacaoInputModel model)
        {
            var operacao = new Operacao(model.Valor, model.TipoOperacao, id);

            var objetivo = _context.Objetivos.SingleOrDefault(o => o.Id == id);

            if (objetivo == null)
                return NotFound();

            objetivo.RealizarOperacaoFinanceira(operacao);

            return NoContent();
        }
    }
}