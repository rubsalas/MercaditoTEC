using Microsoft.VisualStudio.TestTools.UnitTesting;
using API_MercaditoTEC.Data;
using System.Linq;
using API_MercaditoTEC.Models;
using Microsoft.EntityFrameworkCore;

namespace UnitTest_API_MercaditoTEC
{
    [TestClass]
    public class UnitTestEstudiantesJ
    {
        [TestMethod]
        public void TestGetAll()
        {
            var options = new DbContextOptionsBuilder<MercaditoTECContext>()
                .UseInMemoryDatabase(databaseName: "TestGetAll")
                .Options;

            var context = new MercaditoTECContext(options);

            Seed(context);
            
            var _personaRepo = new SqlPersonaRepo(context);

            var result = _personaRepo.GetAll();

            //Esto es del ejemplo
            Assert.AreEqual(5, result.Count());
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
