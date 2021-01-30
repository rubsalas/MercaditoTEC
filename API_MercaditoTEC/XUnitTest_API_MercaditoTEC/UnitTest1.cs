using API_MercaditoTEC.Data;
using API_MercaditoTEC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace XUnitTest_API_MercaditoTEC
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var options = new DbContextOptionsBuilder<MercaditoTECContext>()
                .UseInMemoryDatabase(databaseName: "Test1")
                .Options;

            var context = new MercaditoTECContext(options);

            Seed(context);

            var _personaRepo = new SqlPersonaRepo(context);

            var result = _personaRepo.GetAll();

            //Esto es del ejemplo
            Assert.Equal(5, result.Count());
        }

        /*
         * Ingresa datos a la base de datos InMemory
         */
        private void Seed(MercaditoTECContext context)
        {
            var personas = new[]
            {
                new Persona {nombre = "Ruben"},
                new Persona {nombre = "Tatiana"},
                new Persona {nombre = "Cristhofer"},
                new Persona {nombre = "Ricardo"},
                new Persona {nombre = "Jorge"}
            };

            context.Persona.AddRange(personas);
            context.SaveChanges();
        }
    }
}
