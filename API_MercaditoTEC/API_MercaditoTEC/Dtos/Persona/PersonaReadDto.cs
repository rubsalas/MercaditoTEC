﻿using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class PersonaReadDto
    {
        [Key]
        public int idPersona { get; set; }
        [Required]
        [MaxLength(75)]
        public string nombre { get; set; }
        [Required]
        [MaxLength(150)]
        public string apellidos { get; set; }
        [Required]
        [MaxLength(30)]
        public string telefono { get; set; }
    }
}
