using System;
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
        public Single calificacionPromedioProductos { get; set; }
        [Required]
        public Single calificacionPromedioServicios { get; set; }
    }
}
