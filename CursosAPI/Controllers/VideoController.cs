using CursosAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideosController : ControllerBase
    {
        private static List<Video> videos = new List<Video>();
        private static int id = 1;

        //conforme padrão arquitetural REST, deve retornar uma action e onde o conteúdo foi criado
        [HttpPost]
        public IActionResult AdicionaVideo([FromBody] Video video)
        {
            video.Id = id++;
            videos.Add(video);
            return CreatedAtAction(nameof(RecuperaVideoPorId), new { Id = video.Id }, video);
        }

        [HttpGet]
        public IActionResult RecuperaVideos()
        {
            return Ok(videos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaVideoPorId(int id)
        {
            Video video = videos.FirstOrDefault(video => video.Id == id);

            if(video != null)
            {
                return Ok(video);
            }
            return NotFound();
        }
    }
}
