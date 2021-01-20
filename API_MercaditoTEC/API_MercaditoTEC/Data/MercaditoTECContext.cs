using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
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
        public DbSet<MetodoPago> MetodoPago { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Provincia> Provincia { get; set; }

        /* Rosado */
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Canton> Canton { get; set; }

        /* Rojo */
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Ubicacion> Ubicacion { get; set; }

        /* Anaranjado */
        public DbSet<Producto> Producto { get; set; }

        /* Amarillo */
        public DbSet<MetodoPagoProducto> MetodoPagoProducto { get; set; }
        public DbSet<UbicacionProducto> UbicacionProducto { get; set; }
        public DbSet<ImagenProducto> ImagenProducto { get; set; }

    }
}
