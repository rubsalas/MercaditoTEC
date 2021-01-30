using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class Estudiante
    {
        [Key]
        public int idEstudiante { get; set; }
        [Required]
        public int idPersona { get; set; }
        [Required]
        public string correoInstitucional { get; set; }
        [Required]
        public int puntosCanje { get; set; }
        [Required]
        public bool haIngresadoWeb { get; set; }
        [Required]
        public bool haIngresadoApp { get; set; }
    }
}
