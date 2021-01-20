using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class Canton
    {
        [Key]
        public int idCanton { get; set; }
        [Required]
        public int idProvincia { get; set; }
        [Required]
        [MaxLength(75)]
        public string nombre { get; set; }
    }
}
