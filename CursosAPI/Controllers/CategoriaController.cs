using CursosAPI.Data;
using CursosAPI.Data.Dtos;
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
        public IActionResult AdicionaCategoria([FromBody] CreateCategoriaDto categoriaDto)
        {
            Categoria categoria = new Categoria
            {
                Cor = categoriaDto.Cor,
                Titulo = categoriaDto.Titulo
            };

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
                ReadCategoriaDto categoriaDto = new ReadCategoriaDto
                {
                    Cor = categoria.Cor,
                    Titulo = categoria.Titulo,
                    Id = id,
                    HoraConsulta = DateTime.Now
                };

                return Ok(categoriaDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCategoria(int id, [FromBody] UpdateCategoriaDto categoriaDto)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);

            if(categoria == null)
            {
                return NotFound();
            }

            categoria.Titulo = categoriaDto.Titulo;
            categoria.Cor = categoriaDto.Cor;
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
