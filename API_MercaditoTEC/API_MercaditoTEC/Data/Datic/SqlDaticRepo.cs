using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlDaticRepo : IDaticRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlDaticRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todas las cuentas de estudiantes registrados en Datic de la base de datos.
         */
        public IEnumerable<Datic> GetAll()
        {
            //Se retorna una lista de todas las cuentas de estudiantes registrados en Datic
            return _context.Datic.ToList();
        }

        /*
         * Retorna una sola cuenta de estudiante registrado en Datic.
         */
        public Datic GetByCorreo(string correo)
        {
            //Se retorna un cuenta de estudiante especifica
            return _context.Datic.FirstOrDefault(d => d.correoInstitucional == correo);
        }

        public void Create(Datic datic)
        {
            throw new NotImplementedException();
        }

        public void Update(Datic datic)
        {
            throw new NotImplementedException();
        }

        public void Delete(Datic datic)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
