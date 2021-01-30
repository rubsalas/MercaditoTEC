using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos
{
    public class ProvinciaReadDto
    {
        [Key]
        public int idProvincia { get; set; }
        [Required]
        [MaxLength(75)]
        public string nombre { get; set; }
    }
}
