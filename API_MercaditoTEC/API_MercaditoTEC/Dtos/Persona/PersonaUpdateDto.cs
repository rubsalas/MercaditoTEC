using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_MercaditoTEC.Dtos.Persona
{
    public class PersonaUpdateDto
    {
        [Required]
        [MaxLength(75)]
        public string nombre { get; set; }

        [Required]
        [MaxLength(150)]
        public string apellidos { get; set; }

        [Required]
        [MaxLength(30)]
        public string telefono { get; set; }
    }
}
