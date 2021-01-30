using System;
using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.DtosJ
{
    public class CursoTutorJReadDto
    {
        [Key]
        public int idCursoTutor { get; set; }

        //TutorJ
        [Required]
        public int idTutor { get; set; }
        public int idEstudiante { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        //public string telefono { get; set; } //
        //public string correoInstitucional { get; set; } //
        public Single calificacionPromedioTutor { get; set; }

        //CursoJ
        [Required]
        public int idCurso { get; set; }
        public string nombreCurso { get; set; } //Mappear manual
        public string codigo { get; set; }
        //public int idCarrera { get; set; } //
        public string carrera { get; set; } //

        [Required]
        public int notaObtenida { get; set; }
        [Required]
        [MaxLength(500)]
        public string temas { get; set; }
    }
}
