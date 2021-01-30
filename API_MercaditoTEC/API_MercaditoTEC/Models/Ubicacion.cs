using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class Ubicacion
    {
        [Key]
        public int idUbicacion { get; set; }
        [Required]
        public int idCanton { get; set; }
        [Required]
        [MaxLength(75)]
        public string distrito { get; set; }
    }
}
