using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class MetodoPagoProducto
    {
        [Key]
        public int idMetodoPagoProducto { get; set; }
        [Required]
        public int idProducto { get; set; }
        [Required]
        public int idMetodoPago { get; set; }
        [MaxLength(75)]
        public string numeroCuenta { get; set; }
    }
}
