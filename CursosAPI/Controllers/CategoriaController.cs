using CursosAPI.Data;
using CursosAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        public CategoriaContext _context;

        public CategoriasController(CategoriaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaCategoria([FromBody] Categoria categoria)
        {
            _context.Add(categoria);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCategoria), new { Id = categoria.Id }, categoria);
        }

        [HttpGet]
        public IEnumerable<Categoria> RecuperaCategoria()
        {
            return _context.Categorias;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCategoriaPorId(int id)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);

            if (categoria != null)
            {
                return Ok(categoria);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCategoria(int id, Categoria categoriaNovo)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);

            if(categoria == null)
            {
                return NotFound();
            }

            categoria.Titulo = categoriaNovo.Titulo;
            categoria.Cor = categoriaNovo.Cor;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCategoria(int id)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);

            if(categoria == null)
            {
                return NotFound();
            }

            _context.Remove(categoria);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
