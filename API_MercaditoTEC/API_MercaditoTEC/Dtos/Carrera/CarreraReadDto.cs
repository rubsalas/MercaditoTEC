using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.Carrera
{
    public class CarreraReadDto
    {
        [Key]
        public int idCarrera { get; set; }
        [Required]
        [MaxLength(150)]
        public string nombre { get; set; }
    }
}
