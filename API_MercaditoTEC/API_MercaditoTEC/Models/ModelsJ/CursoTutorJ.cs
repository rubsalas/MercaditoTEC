

using System;
using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models.ModelsJ
{
    public class CursoTutorJ
    {
        [Key]
        public int idCursoTutor { get; set; }

        //Tutor -> Cambiar por un TutorJ
        [Required]
        public int idTutor { get; set; }
        public int idEstudiante { get; set; } 
        public Single calificacionPromedioTutor { get; set; }

        //CursoJ
        [Required]
        public int idCurso { get; set; }
        public string nombre { get; set; } 
        public string codigo { get; set; }
        public int idCarrera { get; set; }
        public string carrera { get; set; }

        //
        [Required]
        public int notaObtenida { get; set; }
        [Required]
        [MaxLength(30)]
        public string temas { get; set; }

    }
}
