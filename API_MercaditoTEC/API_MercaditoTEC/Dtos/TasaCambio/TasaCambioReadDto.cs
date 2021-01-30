using System;
using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.TasaCambio
{
    public class TasaCambioReadDto
    {
        [Key]
        public int idTasaCambio { get; set; }
        [Required]
        public Single monto { get; set; }
    }
}
