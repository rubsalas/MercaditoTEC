using System;
using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }
        [Required]
        public int idVendedor { get; set; }
        [Required]
        [MaxLength(150)]
        public string nombre { get; set; }
        [Required]
        [MaxLength(500)]
        public string descripcion { get; set; }
        [Required]
        public int idCategoria { get; set; }
        [Required]
        public int precio { get; set; }
        [Required]
        public DateTime fechaPublicacion { get; set; }
    }
}
