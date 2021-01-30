﻿using System;
using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.DtosJ.VendedorJ
{
    public class VendedorJReadDto
    {
        [Key]
        public int idVendedor { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public string correoInstitucional { get; set; }
        [Required]
        public Single calificacionPromedioProductos { get; set; }
        [Required]
        public Single calificacionPromedioServicios { get; set; }
    }
}