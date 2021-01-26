using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos
{
    public class MetodoPagoReadDto
    {
        [Key]
        public int idMetodoPago { get; set; }
        [Required]
        [MaxLength(75)]
        public string nombre { get; set; }
    }
}
