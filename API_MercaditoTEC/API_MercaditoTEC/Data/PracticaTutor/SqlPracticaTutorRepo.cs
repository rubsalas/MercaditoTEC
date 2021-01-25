using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlPracticaTutorRepo : IPracticaTutorRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlPracticaTutorRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todas las PracticaTutor de la base de datos.
         */
        public IEnumerable<PracticaTutor> GetAll()
        {
            return _context.PracticaTutor.ToList();
        }

        /*
         * Retorna una sola PracticaTutor por su id.
         */
        public PracticaTutor GetById(int id)
        {
            return _context.PracticaTutor.FirstOrDefault(pt => pt.idPracticaTutor == id);
        }

        /*
         * Retorna una sola PracticaTutor por su nombre.
         */
        public PracticaTutor GetByNombre(string nombre)
        {
            return _context.PracticaTutor.FirstOrDefault(pt => pt.nombre == nombre);
        }

        /*
         * Retorna una lista de PracticaTutor de un unico CursoTutor indicado.
         */
        public IEnumerable<PracticaTutor> GetByCursoTutor(int idCursoTutor)
        {
            //Se obtienen todas las PracticaTutor
            IEnumerable<PracticaTutor> practicaTutorItems = GetAll();

            //Se crea una nueva lista donde se dejaran las PracticaTUtor especificas
            List<PracticaTutor> practicaTutorEspecificas = new List<PracticaTutor>();

            //Se itera en la lista de todas las PracticaTutor
            for (int i = 0; i < practicaTutorItems.Count(); i++)
            {
                //Se obtiene de la lista de PracticaTutor los que correspondan al idCursoTutor indicado
                if (practicaTutorItems.ElementAt(i).idCursoTutor == idCursoTutor)
                {
                    practicaTutorEspecificas.Add(practicaTutorItems.ElementAt(i));
                }
            }

            return practicaTutorEspecificas;
        }

        public void Create(PracticaTutor practicaTutor)
        {
            throw new NotImplementedException();
        }

        public void Update(PracticaTutor practicaTutor)
        {
            throw new NotImplementedException();
        }

        public void Delete(PracticaTutor practicaTutor)
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
