using API_MercaditoTEC.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.DtosJ.ProductoJ
{
    public class ProductoJPreviewDto
    {
        [Key]
        public int idProducto { get; set; }
        [Required]
        [MaxLength(150)]
        public string nombre { get; set; }
        [Required]
        [MaxLength(500)]
        public string descripcion { get; set; }
        [Required]
        public int precio { get; set; }
        [Required]
        public DateTime fechaPublicacion { get; set; }
        public ImagenProducto imagen { get; set; }
    }
}
