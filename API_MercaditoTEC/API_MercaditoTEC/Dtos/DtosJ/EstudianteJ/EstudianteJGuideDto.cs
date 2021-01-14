using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.DtosJ.EstudianteJ
{
    public class EstudianteJGuideDto
    {
        [Required]
        public int idEstudiante { get; set; }
        [Required]
        public string cliente { get; set; }
    } 
}
