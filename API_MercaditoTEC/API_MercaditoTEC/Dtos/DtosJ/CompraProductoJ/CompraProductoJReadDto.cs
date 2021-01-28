using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.DtosJ
{
    public class CompraProductoJReadDto
    {
        [Key]
        public int idCompraProducto { get; set; }

        [Required]
        public int idProducto { get; set; } //ProductoJ
        public string nombre { get; set; }
        public int puntosCanje { get; set; }
        public int idVendedor { get; set; }
        public string nombreVendedor { get; set; }
        public IEnumerable<MetodoPagoProductoJ> metodosPago { get; set; }
        public IEnumerable<ImagenProducto> imagenes { get; set; }

        [Required]
        public int idComprador { get; set; } //CompradorJ
        public string nombreComprador { get; set; } //manualmente

        [Required]
        public bool confirmacionVenta { get; set; }
        [Required]
        public bool confirmacionCompra { get; set; }
        [Required]
        public bool evaluacionCompletada { get; set; }
        [Required]
        public int puntosCanjeObtenidos { get; set; }
    }
}
