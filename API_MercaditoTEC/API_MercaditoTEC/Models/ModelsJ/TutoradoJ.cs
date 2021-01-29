﻿using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models.ModelsJ
{
    public class TutoradoJ
    {
        [Key]
        public int idTutorado { get; set; }
        [Required]
        public int idEstudiante { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public string correoInstitucional { get; set; }
    }
}
