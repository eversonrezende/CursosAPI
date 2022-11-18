using System.ComponentModel.DataAnnotations;

namespace CursosAPI.Models
{
    public class Video
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string URL { get; set; }
        
    }
}
