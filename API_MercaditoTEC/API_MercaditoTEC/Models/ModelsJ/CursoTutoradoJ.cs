using System;
using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models.ModelsJ
{
    public class CursoTutoradoJ
    {
        [Key]
        public int idCursoTutorado { get; set; }
        [Required]
        public int idTutorado { get; set; } //TutoradoJ
        public string nombreTutorado { get; set; } //Mappear manual

        [Required]
        public int idCursoTutor { get; set; } //CursoTutorJ
        public int idTutor { get; set; }
        public string nombreTutor { get; set; } //Mappear manual
        public Single calificacionPromedioTutor { get; set; }
        public int idCurso { get; set; }
        public string nombreCurso { get; set; }
        public string codigo { get; set; }
        public int notaObtenida { get; set; }
        public string temas { get; set; }

    }
}
