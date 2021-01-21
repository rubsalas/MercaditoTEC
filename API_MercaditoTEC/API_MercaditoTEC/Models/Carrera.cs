using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class Carrera
    {
        [Key]
        public int idCarrera { get; set; }
        [Required]
        [MaxLength(150)]
        public string nombre { get; set; }
    }
}
