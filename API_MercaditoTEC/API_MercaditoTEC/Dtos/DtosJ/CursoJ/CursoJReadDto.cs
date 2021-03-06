﻿using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.DtosJ
{
    public class CursoJReadDto
    {
        [Key]
        public int idCurso { get; set; }
        [Required]
        [MaxLength(150)]
        public string nombre { get; set; }
        [Required]
        [MaxLength(30)]
        public string codigo { get; set; }
        [Required]
        public int idCarrera { get; set; }
        public string carrera { get; set; }
    }
}
