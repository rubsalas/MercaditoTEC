using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class CursoTutor
    {
        [Key]
        public int idCursoTutor { get; set; }
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
