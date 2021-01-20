using API_MercaditoTEC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_MercaditoTEC.Models.ModelsJ
{
    public class ProductoJ
    {
        [Key]
        public int idProducto { get; set; }
        [Required]
        public int idVendedor { get; set; }
        public string nombreVendedor { get; set; } //Persona //Estudiante //Vendedor
        public Single calificacionPromedioVendedor { get; set; } //Vendedor
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
        public IEnumerable<UbicacionProductoJ> ubicaciones { get; set; }
        public IEnumerable<MetodoPagoProductoJ> metodosPago { get; set; }
        [ForeignKey("idProducto")]
        public IEnumerable<ImagenProducto> imagenes { get; set; }
    }
}
