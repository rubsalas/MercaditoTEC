using System;
using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Dtos.DtosJ.EstudianteJ
{
    public class EstudianteJProfileDto
    {
        [Key]
        public int idEstudiante { get; set; }
        [Required]
        [MaxLength(75)]
        public string nombre { get; set; }
        [Required]
        [MaxLength(150)]
        public string apellidos { get; set; }
        [Required]
        [MaxLength(30)]
        public string telefono { get; set; }
        [Required]
        [MaxLength(150)]
        public string correoInstitucional { get; set; }
        [Required]
        public int puntosCanje { get; set; }
        public Single calificacionPromedioTutor { get; set; }
        public int cantidadAplicaciones { get; set; }
        public Single calificacionPromedioProductos { get; set; }
        public Single calificacionPromedioServicios { get; set; }
    }
}
