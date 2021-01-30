using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class PracticaTutor
    {
        [Key]
        public int idPracticaTutor { get; set; }
        [Required]
        public int idCursoTutor { get; set; }
        [Required]
        [MaxLength(150)]
        public string nombre { get; set; }
        [Required]
        [MaxLength(500)]
        public string descripcion { get; set; }
        [Required]
        public int cantidadEjercicios { get; set; }
        [Required]
        [MaxLength(75)]
        public string dificultad { get; set; }
        [Required]
        public int precio { get; set; }
        [Required]
        [MaxLength(75)]
        public string pdfPractica { get; set; }
        [Required]
        [MaxLength(75)]
        public string pdfSolucion { get; set; }
    }
}
