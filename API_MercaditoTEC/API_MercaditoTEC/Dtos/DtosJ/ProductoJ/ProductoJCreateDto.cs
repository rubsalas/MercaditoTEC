using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_MercaditoTEC.Dtos.DtosJ.ProductoJ
{
    public class ProductoJCreateDto
    {
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
        public DateTime fechaPublicacion { get; set; } //Agregar en Controller
        public IEnumerable<UbicacionProductoJ> ubicaciones { get; set; }
        public IEnumerable<MetodoPagoProductoJ> metodosPago { get; set; }
        [ForeignKey("idProducto")]
        public IEnumerable<ImagenProducto> imagenes { get; set; }
    }
}
