﻿using System;
using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.DtosJ.TutorJ
{
    public class TutorJReadDto
    {
        [Key]
        public int idTutor { get; set; }
        [Required]
        public int idEstudiante { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public string correoInstitucional { get; set; }
        [Required]
        public Single calificacionPromedioTutor { get; set; }
    }
}
