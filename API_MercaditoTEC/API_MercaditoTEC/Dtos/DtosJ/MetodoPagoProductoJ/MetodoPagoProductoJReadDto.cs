using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.DtosJ
{
    public class MetodoPagoProductoJReadDto
    {
        public int idMetodoPago { get; set; }
        [MaxLength(75)]
        public string nombre { get; set; }
        [MaxLength(75)]
        public string numeroCuenta { get; set; }
    }
}
