using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models.ModelsJ
{
    public class MetodoPagoProductoJ
    {
        [Key]
        public int idMetodoPagoProducto { get; set; }
        [Required]
        public int idProducto { get; set; }
        [Required]
        public int idMetodoPago { get; set; }
        [MaxLength(75)]
        public string nombre { get; set; }
        [MaxLength(75)]
        public string numeroCuenta { get; set; }
    }
}
