using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class Provincia
    {
        [Key]
        public int idProvincia { get; set; }
        [Required]
        [MaxLength(75)]
        public string nombre { get; set; }
    }
}
