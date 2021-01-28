using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class CompraProducto
    {
        [Key]
        public int idCompraProducto { get; set; }
        [Required]
        public int idProducto { get; set; }
        [Required]
        public int idComprador { get; set; }
        [Required]
        public bool confirmacionVendedor { get; set; }
        [Required]
        public bool confirmacionComprador { get; set; }
        [Required]
        public bool evaluacionCompletada { get; set; }
        [Required]
        public int puntosCanjeObtenidos { get; set; }
    }
}
