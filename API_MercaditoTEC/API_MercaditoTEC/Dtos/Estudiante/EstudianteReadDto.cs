using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_MercaditoTEC.Dtos.Estudiante
{
    public class EstudianteReadDto
    {
        [Key]
        public int idEstudiante { get; set; }
        [Required]
        public int idPersona { get; set; }
        [Required]
        [MaxLength(150)]
        public string correoInstitucional { get; set; }
        [Required]
        [MaxLength(75)]
        public int puntosCanje { get; set; }
    }
}
