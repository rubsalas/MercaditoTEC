using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    /*
     * Mock
     */
    public class MockPersonaRepo : IPersonaRepo
    {
        public IEnumerable<Persona> GetAll()
        {
            var personas = new List<Persona>
            {
                new Persona { idPersona = 1, nombre = "Ruben", apellidos = "Salas Ramirez", telefono = "86069199" },
                new Persona { idPersona = 2, nombre = "Ricardo", apellidos = "Salas Ramirez", telefono = "60127645" },
                new Persona { idPersona = 3, nombre = "Katherina", apellidos = "Ramirez Arias", telefono = "86034215" }
            };

            return personas;
        }

        public Persona GetById(int id)
        {
            return new Persona { idPersona = 1, nombre="Ruben", apellidos="Salas Ramirez", telefono="86069199" };
        }
    }
}
