using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos
{
    public class CantonReadDto
    {
        [Key]
        public int idCanton { get; set; }
        [Required]
        [MaxLength(75)]
        public string nombre { get; set; }
    }
}
