using System;
using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class OfertaLaboral
    {
        [Key]
        public int idOfertaLaboral { get; set; }
        [Required]
        public int idEmpleador { get; set; }
        [Required]
        [MaxLength(150)]
        public string nombrePuesto { get; set; }
        [Required]
        [MaxLength(500)]
        public string responsabilidades { get; set; }
        [Required]
        [MaxLength(500)]
        public string requerimientos { get; set; }
        [Required]
        public int idCarrera { get; set; }
        [Required]
        public int idUbicacion { get; set; }
        [Required]
        [MaxLength(75)]
        public string jornadaLaboral { get; set; }
        [Required]
        [MaxLength(300)]
        public string link { get; set; }
        [Required]
        public DateTime fechaPublicacion { get; set; }




    }
}
