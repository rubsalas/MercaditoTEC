using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class Vendedor
    {
        [Key]
        public int idVendedor { get; set; }
        [Required]
        public int idEstudiante { get; set; }
        [Required]
        public int calificacionPromedioProductos { get; set; }
        [Required]
        public int calificacionPromedioServicios { get; set; }
    }
}
