using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class Tutorado
    {
        [Key]
        public int idTutorado { get; set; }
        [Required]
        public int idEstudiante { get; set; }
    }
}
