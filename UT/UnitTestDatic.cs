using API_MercaditoTEC.Data;
using API_MercaditoTEC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest_MercaditoTEC
{
    public class UnitTestDatic : IDisposable
    {

        protected readonly MercaditoTECContext _context;

        public UnitTestDatic()
        {
            var options = new DbContextOptionsBuilder<MercaditoTECContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new MercaditoTECContext(options);

            _context.Database.EnsureCreated();

            var personas = new[]
            {
                new Persona {nombre = "Ruben"},
                new Persona {nombre = "Tatiana"},
                new Persona {nombre = "Cristhofer"},
                new Persona {nombre = "Ricardo"},
                new Persona {nombre = "Jorge"}
            };

            _context.Persona.AddRange(personas);

            var datic = new[]
            {
                new Datic
                {
                    correoInstitucional = "cris@estudiantec.cr",
                    contrasena = "123456"
                }
            };

            _context.Datic.AddRange(datic);

            _context.SaveChanges();
        }


        [Fact]
        public async Task ConfirmacionDatic()
        {
            //Arrange
            var cls = new SqlDaticRepo(_context);

            //Act
            string correoInstitucional = "cris@estudiantec.cr";
            var result = cls.GetByCorreo(correoInstitucional);

            //Assert
            string contrasena = "123456";
            Assert.Equal(result.contrasena, contrasena);

        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

    }
}
