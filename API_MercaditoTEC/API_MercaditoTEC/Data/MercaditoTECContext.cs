using API_MercaditoTEC.Models;
using Microsoft.EntityFrameworkCore;

namespace API_MercaditoTEC.Data
{
    public class MercaditoTECContext : DbContext
    {
        public MercaditoTECContext(DbContextOptions<MercaditoTECContext> options) : base(options)
        {

        }

        /* Morado */
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Datic> Datic { get; set; }
        public DbSet<Carrera> Carrera { get; set; }
        public DbSet<MetodoPago> MetodoPago { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<TasaCambio> TasaCambio { get; set; }

        /* Rosado */
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Canton> Canton { get; set; }

        /* Rojo */
        public DbSet<Tutor> Tutor { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Ubicacion> Ubicacion { get; set; }

        /* Anaranjado */
        public DbSet<CursoTutor> CursoTutor { get; set; }
        public DbSet<Producto> Producto { get; set; }

        /* Amarillo */
        public DbSet<PracticaTutor> PracticaTutor { get; set; }
        public DbSet<MetodoPagoProducto> MetodoPagoProducto { get; set; }
        public DbSet<UbicacionProducto> UbicacionProducto { get; set; }
        public DbSet<ImagenProducto> ImagenProducto { get; set; }

        /* Verde */
        public DbSet<TemaPracticaTutor> TemaPracticaTutor { get; set; }
        public DbSet<MetodoPagoPracticaTutor> MetodoPagoPracticaTutor { get; set; }

    }
}
