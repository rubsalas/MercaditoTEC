using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.Estudiante
{
    public class EstudianteCreateDto
    {
        [Required]
        public int idPersona { get; set; }
        [Required]
        [MaxLength(150)]
        public string correoInstitucional { get; set; }
        [Required]
        public int puntosCanje { get; set; }
        [Required]
        public int haIngresadoWeb { get; set; }
        [Required]
        public int haIngresadoApp { get; set; }
    }
}
