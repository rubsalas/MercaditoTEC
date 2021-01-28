﻿using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models.ModelsJ
{
    public class AdministradorJ
    {
        [Key]
        public int idAdministrador { get; set; }
        [Required]
        public int idPersona { get; set; }
        [Required]
        [MaxLength(75)]
        public string nombre { get; set; } //Persona
        [Required]
        [MaxLength(150)]
        public string apellidos { get; set; } //Persona
        [Required]
        [MaxLength(30)]
        public string telefono { get; set; } //Persona
        [Required]
        [MaxLength(75)]
        public string usuario { get; set; }
        [Required]
        [MaxLength(75)]
        public string contrasena { get; set; }
    }
}
