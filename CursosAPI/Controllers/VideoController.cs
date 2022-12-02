using AutoMapper;
using CursosAPI.Data;
using CursosAPI.Data.Dtos;
using CursosAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursosAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class VideosController : ControllerBase
{
    private VideoContext _context;
    private IMapper _mapper;

    public VideosController(VideoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    //conforme padrão arquitetural REST, deve retornar uma action e onde o conteúdo foi criado
    [HttpPost]
    public IActionResult AdicionaVideo([FromBody] CreateVideoDto videoDto)
    {
        Video video = _mapper.Map<Video>(videoDto);

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
            ReadVideoDto videoDto = _mapper.Map<ReadVideoDto>(video);

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

        _mapper.Map(videoDto, video);
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
