using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.DtosJ.EstudianteJ
{
    public class EstudianteJUpdateDto
    {
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public bool haIngresadoWeb { get; set; }
        public bool haIngresadoApp { get; set; }
    }
}

