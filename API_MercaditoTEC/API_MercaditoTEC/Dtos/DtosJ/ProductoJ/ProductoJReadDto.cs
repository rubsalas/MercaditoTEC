﻿using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using System;
using System.Collections.Generic;
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
        public Single calificacionPromedioVendedor { get; set; } //Vendedor //Cambiar por calificacionVendedorProductos
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

        public IEnumerable<MetodoPagoProductoJ> metodosPago { get; set; }
        public IEnumerable<ImagenProducto> imagenes { get; set; }
    }
}
