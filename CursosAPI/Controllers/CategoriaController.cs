using AutoMapper;
using CursosAPI.Data;
using CursosAPI.Data.Dtos;
using CursosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CursosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        private CategoriaContext _context;
        private IMapper _mapper;

        public CategoriasController(CategoriaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //conforme padrão arquitetural REST, deve retornar uma action e onde o conteúdo foi criado
        [HttpPost]
        public IActionResult AdicionaCategoria([FromBody] CreateCategoriaDto categoriaDto)
        {
            Categoria categoria = _mapper.Map<Categoria>(categoriaDto);

            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCategoriaPorId), new { Id = categoria.Id }, categoria);
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
                ReadCategoriaDto categoriaDto = _mapper.Map<ReadCategoriaDto>(categoria);

                return Ok(categoriaDto);
            }

            return NotFound();
        }

        //conforme padrão arquitetural REST, deve retornar uma action que não existe conteúdo
        [HttpPut("{id}")]
        public IActionResult AtualizaCategoria(int id, [FromBody] UpdateCategoriaDto categoriaDto)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            _mapper.Map(categoriaDto, categoria);
            _context.SaveChanges();
            return NoContent();
        }

        //conforme padrão arquitetural REST, deve retornar uma action que não existe conteúdo
        [HttpDelete("{id}")]
        public IActionResult DeletaCategoria(int id)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            _context.Remove(categoria);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
