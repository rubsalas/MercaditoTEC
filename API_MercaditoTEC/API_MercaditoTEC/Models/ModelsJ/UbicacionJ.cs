using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models.ModelsJ
{
    public class UbicacionJ
    {
        [Key]
        public int idUbicacion { get; set; }
        [Required]
        public int idCanton { get; set; }
        public int idProvincia { get; set; }
        [Required]
        [MaxLength(75)]
        public string distrito { get; set; }
        public string canton { get; set; }
        public string provincia { get; set; }
    }
}
