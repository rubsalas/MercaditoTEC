using API_MercaditoTEC.Data;
using API_MercaditoTEC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace XUnitTest_MercaditoTEC
{
    public class UnitTestPersona : IDisposable
    {
        protected readonly MercaditoTECContext _context;

        public UnitTestPersona()
        {
            var options = new DbContextOptionsBuilder<MercaditoTECContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new MercaditoTECContext(options);

            _context.Database.EnsureCreated();

            var personas = new[]
            {
                new Persona 
                {
                    idPersona = 1,
                    nombre = "Ruben",
                    apellidos = "Salas Ramirez",
                    telefono = "86069199"
                },
                new Persona 
                {
                    idPersona = 2,
                    nombre = "Tatiana",
                    apellidos = "Chacon Mora",
                    telefono = "87925483"
                }
            };

            _context.Persona.AddRange(personas);

            _context.SaveChanges();
        }

        [Fact]
        public void PersonaGetId()
        {
            //Arrange
            var cls = new SqlPersonaRepo(_context);

            //Act
            string nombre = "Ruben";
            string apellidos = "Salas Ramirez";
            string telefono = "86069199";
            var result = cls.GetId(nombre, apellidos, telefono);

            //Assert
            int idPersona = 1;
            Assert.Equal(result, idPersona);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
