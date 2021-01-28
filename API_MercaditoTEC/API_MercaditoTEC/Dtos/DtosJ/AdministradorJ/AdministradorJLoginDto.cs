using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.DtosJ
{
    public class AdministradorJLoginDto
    {
        [Required]
        [MaxLength(75)]
        public string usuario { get; set; }
        [Required]
        [MaxLength(75)]
        public string contrasena { get; set; }
    }
}
