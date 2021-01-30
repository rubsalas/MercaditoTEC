using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.Categoria
{
    public class CategoriaReadDto
    {
        [Key]
        public int idCategoria { get; set; }
        [Required]
        [MaxLength(75)]
        public string nombre { get; set; }
        [Required]
        public int puntaje { get; set; }
    }
}
