using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlPersonaRepo : IPersonaRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlPersonaRepo(MercaditoTECContext context)
        {
            _context = context;
        }


        /*
         * Retorna todas las Personas de la base de datos.
         */
        public IEnumerable<Persona> GetAll()
        {
            //Se retorna una lista de todas las Personas
            return _context.Persona.ToList();
        }

        /*
         * Retorna una sola persona por su id.
         */
        public Persona GetById(int id)
        {
            return _context.Persona.FirstOrDefault(p => p.idPersona == id);
        }

        /*
         * Ingresa a la base de datos una nueva Persona.
         */
        public void Create(Persona persona)
        {
            //Se verifica si la Persona existe
            if (persona == null)
            {
                throw new ArgumentNullException(nameof(persona));
            }

            //Se crea la Persona en la base de datos por medio del context
            _context.Persona.Add(persona);
        }

        /*
         * Actualiza los datos de una Persona en la base de datos.
         */
        public void Update(Persona persona)
        {
            //De esto se encarga el DbContext
        }

        /*
         * Elimina los datos de una Persona en la base de datos.
         */
        public void Delete(Persona persona)
        {
            //Se verifica si la Persona existe
            if (persona == null)
            {
                throw new ArgumentNullException(nameof(persona));
            }

            //Se elimina la Persona de la base de datos por medio del context
            _context.Persona.Remove(persona);
        }

        /*
         * Guarda los cambios en la Base de Datos de SQLServer.
         */
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
