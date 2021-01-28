using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class Comprador
    {
        [Key]
        public int idComprador { get; set; }
        [Required]
        public int idEstudiante { get; set; }
    }
}
