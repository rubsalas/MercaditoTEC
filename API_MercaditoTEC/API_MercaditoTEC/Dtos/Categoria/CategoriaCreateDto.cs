using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.Categoria
{
    public class CategoriaCreateDto
    {
        [Required]
        [MaxLength(75)]
        public string nombre { get; set; }
        [Required]
        public int puntaje { get; set; }
    }
}
