using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.DtosJ
{
    public class CompraProductoJConfirmationDto
    {
        [Key]
        public int idCompraProducto { get; set; }
        //[Required]
        //public int idComprador { get; set; }
        [Required]
        public bool confirmacionVendedor { get; set; }
        [Required]
        public bool confirmacionComprador { get; set; }
    }
}
