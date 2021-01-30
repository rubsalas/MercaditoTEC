using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class ImagenProducto
    {
        [Key]
        public int idImagenProducto { get; set; }
        [Required]
        public int idProducto { get; set; }
        [Required]
        [MaxLength(300)]
        public string imagen { get; set; }
    }
}
