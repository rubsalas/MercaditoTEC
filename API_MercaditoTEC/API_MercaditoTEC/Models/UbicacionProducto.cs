using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class UbicacionProducto
    {
        [Key]
        public int idUbicacionProducto { get; set; }
        [Required]
        public int idProducto { get; set; }
        [Required]
        public int idUbicacion { get; set; }
        [MaxLength(75)]
        public string descripcion { get; set; }
    }
}
