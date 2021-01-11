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

        //Tables
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }

        //Joints
        public DbSet<EstudianteJ> EstudianteJ { get; set; }
    }
}
