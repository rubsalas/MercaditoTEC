using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models.ModelsJ
{
    public class MetodoPagoPracticaTutorJ
    {
        [Key]
        public int idMetodoPagoPracticaTutor { get; set; }
        [Required]
        public int idPracticaTutor { get; set; }
        [Required]
        public int idMetodoPago { get; set; }
        public string nombre { get; set; }
        [MaxLength(75)]
        public string numeroCuenta { get; set; }
    }
}
