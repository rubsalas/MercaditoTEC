using System;
using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.TasaCambio
{
    public class TasaCambioReadDto
    {
        [Key]
        public int idTasaCambio { get; set; }
        [Required]
        public int monto { get; set; } //Cambiar int por Single cuando se cambie en la base de datos
    }
}
