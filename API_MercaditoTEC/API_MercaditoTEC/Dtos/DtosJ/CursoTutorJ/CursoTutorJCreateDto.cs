using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.DtosJ
{
    public class CursoTutorJCreateDto
    {
        [Required]
        public int idTutor { get; set; }
        [Required]
        public int idCurso { get; set; }
        [Required]
        public int notaObtenida { get; set; }
        [Required]
        [MaxLength(500)]
        public string temas { get; set; }
    }
}
