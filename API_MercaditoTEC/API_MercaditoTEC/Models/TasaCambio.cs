using System;
using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models
{
    public class TasaCambio
    {
        [Key]
        public int idTasaCambio { get; set; }
        [Required]
        public Single monto { get; set; }
        [Required]
        public DateTime fechaPublicacion { get; set; }
    }
}
