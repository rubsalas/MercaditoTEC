using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos
{
    public class UbicacionReadDto
    {
        [Key]
        public int idUbicacion { get; set; }
        [Required]
        [MaxLength(75)]
        public string distrito { get; set; }
    }
}
