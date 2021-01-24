using System;
using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class Tutor
    {
        [Key]
        public int idTutor { get; set; }
        [Required]
        public int idEstudiante { get; set; }
        [Required]
        public Single calificacionPromedioTutor { get; set; }
    }
}
