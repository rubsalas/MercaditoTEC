using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.Datic
{
    public class DaticVerifyDto
    {
        [Key]
        [MaxLength(150)]
        public string correoInstitucional { get; set; }
        [Required]
        [MaxLength(150)]
        public string contrasena { get; set; }
    }
}
