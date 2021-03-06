﻿using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.DtosJ.EstudianteJ
{
    public class EstudianteJCreateDto
    {
        public string nombre { get; set; }
        [Required]
        [MaxLength(150)]
        public string apellidos { get; set; }
        [Required]
        [MaxLength(30)]
        public string telefono { get; set; }
        [Required]
        [MaxLength(150)]
        public string correoInstitucional { get; set; }
    }
}
