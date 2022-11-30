using CursosAPI.Data;
using CursosAPI.Data.Dtos;
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
        public IActionResult AdicionaVideo([FromBody] CreateVideoDto videoDto)
        {
            Video video = new Video
            {
                Descricao = videoDto.Descricao,
                Titulo = videoDto.Titulo,
                URL = videoDto.URL
            }; 

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
                ReadVideoDto videoDto = new ReadVideoDto
                {
                    Descricao = video.Descricao,
                    Titulo = video.Titulo,
                    URL = video.URL,
                    Id = video.Id,
                    HoraConsulta = DateTime.Now
                };

                return Ok(videoDto);
            }
            return NotFound();
        }

        //conforme padrão arquitetural REST, deve retornar uma action que não existe conteúdo
        [HttpPut("{id}")]
        public IActionResult AtualizaVideo(int id, [FromBody] UpdateVideoDto videoDto)
        {
            Video video = _context.Videos.FirstOrDefault(video => video.Id == id);

            if (video == null)
            {
                return NotFound();
            }

            video.Titulo = videoDto.Titulo;
            video.Descricao = videoDto.Descricao;
            video.URL = videoDto.URL;
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
