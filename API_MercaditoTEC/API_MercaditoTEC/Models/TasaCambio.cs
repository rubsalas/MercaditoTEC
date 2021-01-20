using System;
using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class TasaCambio
    {
        [Key]
        public int idTasaCambio { get; set; }
        [Required]
        public int monto { get; set; } //Cambiar int por Single cuando se cambie en la base de datos
        [Required]
        public DateTime fechaPublicacion { get; set; }
    }
}
