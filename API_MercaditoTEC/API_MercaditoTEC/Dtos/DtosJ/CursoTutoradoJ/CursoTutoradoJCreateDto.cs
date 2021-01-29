using System;
using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.DtosJ
{
    public class CursoTutoradoJCreateDto
    {
        [Required]
        public int idTutorado { get; set; }
        [Required]
        public int idCursoTutor { get; set; }
    }
}
