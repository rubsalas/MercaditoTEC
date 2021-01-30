using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class MetodoPago
    {
        [Key]
        public int idMetodoPago { get; set; }
        [Required]
        [MaxLength(75)]
        public string nombre { get; set; }
    }
}
