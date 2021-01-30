using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class CursoTutorado
    {
        [Key]
        public int idCursoTutorado { get; set; }
        [Required]
        public int idTutorado { get; set; }
        [Required]
        public int idCursoTutor { get; set; }
    }
}
