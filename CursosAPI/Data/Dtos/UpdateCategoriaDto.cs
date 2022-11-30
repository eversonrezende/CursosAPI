using System.ComponentModel.DataAnnotations;

namespace CursosAPI.Data.Dtos
{
    public class UpdateCategoriaDto
    {
        [Required(ErrorMessage = "Por gentileza, informe um título para a Categoria")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Por gentileza, informe uma cor para a Categoria")]
        public string Cor { get; set; }
    }
}
