using CursosAPI.Data;
using CursosAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideosController : ControllerBase
    {
        private VideoContext _context;

        public VideosController(VideoContext context)
        {
            _context = context;
        }


        //conforme padrão arquitetural REST, deve retornar uma action e onde o conteúdo foi criado
        [HttpPost]
        public IActionResult AdicionaVideo([FromBody] Video video)
        {
            _context.Videos.Add(video);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaVideoPorId), new { Id = video.Id }, video);
        }

        [HttpGet]
        public IEnumerable<Video> RecuperaVideos()
        {
            return _context.Videos;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaVideoPorId(int id)
        {
            Video video = _context.Videos.FirstOrDefault(video => video.Id == id);

            if (video != null)
            {
                return Ok(video);
            }
            return NotFound();
        }

        //conforme padrão arquitetural REST, deve retornar uma action que não existe conteúdo
        [HttpPut("{id}")]
        public IActionResult AtualizaVideo(int id, Video videoNovo)
        {
            Video video = _context.Videos.FirstOrDefault(video => video.Id == id);

            if(video == null)
            {
                return NotFound();
            }

            video.Titulo = videoNovo.Titulo;
            video.Descricao = videoNovo.Descricao;
            video.URL = videoNovo.URL;
            _context.SaveChanges();
            return NoContent();
        }

        //conforme padrão arquitetural REST, deve retornar uma action que não existe conteúdo
        [HttpDelete("{id}")]
        public IActionResult DeletaVideo(int id)
        {
            Video video = _context.Videos.FirstOrDefault(video => video.Id == id);

            if (video == null)
            {
                return NotFound();
            }

            _context.Remove(video);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
