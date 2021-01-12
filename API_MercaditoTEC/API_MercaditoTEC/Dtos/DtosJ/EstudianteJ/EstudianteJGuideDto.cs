using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.DtosJ.EstudianteJ
{
    public class EstudianteJGuideDto
    {
        [Key]
        public int idEstudiante { get; set; }
        [Required]
        [MaxLength(150)]
        public string correoInstitucional { get; set; }
        [Required]
        public bool haIngresadoWeb { get; set; }
        [Required]
        public bool haIngresadoApp { get; set; }
    }
}
