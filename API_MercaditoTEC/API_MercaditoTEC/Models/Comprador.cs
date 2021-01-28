using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class Comprador
    {
        [Key]
        public int idVendedor { get; set; }
        [Required]
        public int idEstudiante { get; set; }
    }
}
