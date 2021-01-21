using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlCarreraRepo : ICarreraRepo
    {
        private MercaditoTECContext _context;

        public SqlCarreraRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todas las Carreras de la base de datos.
         */
        public IEnumerable<Carrera> GetAll()
        {
            //Se retorna una lista de todas las Carreras.
            return _context.Carrera.ToList();
        }

        /*
         * Retorna una sola Carrera por su id.
         */
        public Carrera GetById(int id)
        {
            return _context.Carrera.FirstOrDefault(c => c.idCarrera == id);
        }

        /*
         * Retorna el idCarrera de una Carrera especifica por su nombre
         */
        public int GetId(string nombre)
        {
            return _context.Carrera.FirstOrDefault(c => c.nombre == nombre).idCarrera;
        }

        public void Create(Carrera carrera)
        {
            throw new NotImplementedException();
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
