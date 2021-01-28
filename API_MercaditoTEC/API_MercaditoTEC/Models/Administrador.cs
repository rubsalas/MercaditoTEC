using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class Administrador
    {
        [Key]
        public int idAdministrador { get; set; }
        [Required]
        public int idPersona { get; set; }
        [Required]
        [MaxLength(75)]
        public string usuario { get; set; }
        [Required]
        [MaxLength(75)]
        public string contrasena { get; set; }
    }
}
