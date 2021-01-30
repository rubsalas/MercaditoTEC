using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class Categoria
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
