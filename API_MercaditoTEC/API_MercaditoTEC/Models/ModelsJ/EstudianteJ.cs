using System;
using System.ComponentModel.DataAnnotations;

namespace API_MercaditoTEC.Models.ModelsJ
{
    public class EstudianteJ
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
        [MaxLength(150)]
        public string contrasena { get; set; }
        [Required]
        public int puntosCanje { get; set; }
        [Required]
        public bool haIngresadoWeb { get; set; }
        [Required]
        public bool haIngresadoApp { get; set; }
        public int idTutor { get; set; }
        public Single calificacionPromedioTutor { get; set; }
        public int idAplicante { get; set; }
        public int cantidadAplicaciones { get; set; }
        public int idVendedor { get; set; }
        public Single calificacionPromedioProductos { get; set; }
        public Single calificacionPromedioServicios { get; set; }
    }
}
