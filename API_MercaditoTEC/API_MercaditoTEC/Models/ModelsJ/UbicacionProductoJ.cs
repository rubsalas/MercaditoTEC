using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models.ModelsJ
{
    public class UbicacionProductoJ
    {
        [Key]
        public int idUbicacionProducto { get; set; }
        [Required]
        public int idProducto { get; set; }
        [Required]
        public int idUbicacion { get; set; }
        //public UbicacionJ ubicacion { get; set; }
        [MaxLength(75)]
        public string descripcion { get; set; }
    }
}
