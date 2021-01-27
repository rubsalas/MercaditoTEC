using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos
{
    public class ImagenProductoCreateDto
    {
        [Required]
        public int idProducto { get; set; }
        [Required]
        [MaxLength(300)]
        public string imagen { get; set; }
    }
}
