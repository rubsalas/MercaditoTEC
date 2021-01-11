﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_MercaditoTEC.Dtos.DtosJ.EstudianteJ
{
    public class EstudianteJReadDto
    {
        [Key]
        public int idEstudiante { get; set; }
        [Required]
        [MaxLength(75)]
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
        [Required]
        public int puntosCanje { get; set; }
        /*
        [Required]
        public bool haIngresadoWeb { get; set; }
        [Required]
        public bool haIngresadoApp { get; set; }
        */
    }
}
