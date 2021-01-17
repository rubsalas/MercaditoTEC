using System;
using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.DtosJ.ProductoJ
{
    public class ProductoJReadDto
    {
        [Key]
        public int idProducto { get; set; }
        [Required]
        public int idVendedor { get; set; }
        public string nombreVendedor { get; set; } //Persona //Estudiante //Vendedor
        public int calificacionPromedioVendedor { get; set; } //Vendedor
        [Required]
        [MaxLength(150)]
        public string nombre { get; set; }
        [Required]
        [MaxLength(500)]
        public string descripcion { get; set; }
        [Required]
        public int idCategoria { get; set; }
        //Puntos de canje
        [Required]
        public int precio { get; set; }
        [Required]
        public DateTime fechaPublicacion { get; set; }
        //Lugares de Entrega
        //Metodos de Pago
        //Fotos
    }
}
