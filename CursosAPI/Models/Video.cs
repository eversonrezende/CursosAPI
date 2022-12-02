using System.ComponentModel.DataAnnotations;

namespace CursosAPI.Models;

public class Video
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "Por gentileza, informe um Título para o vídeo")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "Por gentileza, informe uma Descrição para o vídeo")]
    public string Descricao { get; set; }
    [Required(ErrorMessage = "Por gentileza, informe uma URL para o vídeo")]
    public string URL { get; set; }

}
