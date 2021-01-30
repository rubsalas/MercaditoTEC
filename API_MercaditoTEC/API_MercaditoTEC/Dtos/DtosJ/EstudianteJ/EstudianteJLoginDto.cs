using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.DtosJ.EstudianteJ
{
    public class EstudianteJLoginDto
    {
        [Required]
        [MaxLength(150)]
        public string correoInstitucional { get; set; }
        [Required]
        [MaxLength(150)]
        public string contrasena { get; set; }
    }
}
