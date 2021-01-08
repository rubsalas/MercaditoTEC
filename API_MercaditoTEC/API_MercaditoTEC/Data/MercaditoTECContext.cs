using API_MercaditoTEC.Models;
using Microsoft.EntityFrameworkCore;

namespace API_MercaditoTEC.Data
{
    public class MercaditoTECContext : DbContext
    {
        public MercaditoTECContext(DbContextOptions<MercaditoTECContext> options) : base(options)
        {
             
        }

        public DbSet<Persona> Persona { get; set; }
    }
}
