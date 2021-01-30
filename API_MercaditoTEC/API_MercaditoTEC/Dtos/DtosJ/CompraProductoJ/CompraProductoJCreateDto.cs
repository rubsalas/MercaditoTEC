using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.DtosJ
{
    public class CompraProductoJCreateDto
    {
        [Required]
        public int idProducto { get; set; }
        [Required]
        public int idComprador { get; set; }
    }
}
