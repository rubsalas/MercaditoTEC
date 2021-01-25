using System.ComponentModel.DataAnnotations;


namespace API_MercaditoTEC.Models
{
    public class TemaPracticaTutor
    {
        [Key]
        public int idTemaPracticaTutor { get; set; }
        [Required]
        public int idPracticaTutor { get; set; }
        [Required]
        [MaxLength(150)]
        public string tema { get; set; }
    }
}
