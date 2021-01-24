using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlTutorRepo : ITutorRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlTutorRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todos los Tutores de la base de datos.
         */
        public IEnumerable<Tutor> GetAll()
        {
            //Se retorna una lista de todas los Tutores.
            return _context.Tutor.ToList();
        }

        /*
         * Retorna un solo Tutor por su id.
         */
        public Tutor GetById(int id)
        {
            return _context.Tutor.FirstOrDefault(t => t.idTutor == id);
        }

        /*
         * Retorna un solo Tutor por su idEstudiante.
         */
        public Tutor GetByEstudiante(int idEstudiante)
        {
            return _context.Tutor.FirstOrDefault(t => t.idEstudiante == idEstudiante);
        }

        /*
         * Retorna el idTutor de un Tutor especifico.
         */
        public int GetId(int idEstudiante)
        {
            return _context.Tutor.FirstOrDefault(t => t.idEstudiante == idEstudiante).idTutor;
        }

        public void Create(Tutor tutor)
        {
            throw new NotImplementedException();
        }

        public void Update(Tutor tutor)
        {
            throw new NotImplementedException();
        }

        public void Delete(Tutor tutor)
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
