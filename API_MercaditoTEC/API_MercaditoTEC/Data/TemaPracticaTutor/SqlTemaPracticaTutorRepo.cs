using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlTemaPracticaTutorRepo : ITemaPracticaTutorRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlTemaPracticaTutorRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todos los TemaPracticaTutor de la base de datos.
         */
        public IEnumerable<TemaPracticaTutor> GetAll()
        {
            return _context.TemaPracticaTutor.ToList();
        }

        /*
         * Retorna un solo TemaPracticaTutor por su id.
         */
        public TemaPracticaTutor GetById(int id)
        {
            return _context.TemaPracticaTutor.FirstOrDefault(tpt => tpt.idTemaPracticaTutor == id);
        }

        /*
         * Retorna una lista de TemaPracticaTutor de una unica PracticaTutor indicada.
         */
        public IEnumerable<TemaPracticaTutor> GetByPracticaTutor(int idPracticaTutor)
        {
            //Se obtienen todos los TemaPracticaTutor
            IEnumerable<TemaPracticaTutor> temaPracticaTutorItems = GetAll();

            //Se crea una nueva lista donde se dejaran los TemaPracticaTutor especificos
            List<TemaPracticaTutor> temaPracticaTutorEspecificos = new List<TemaPracticaTutor>();

            for (int i = 0; i < temaPracticaTutorItems.Count(); i++)
            {
                //Se obtiene de la lista de TemaPracticaTutor los que correspondan al idPracticaTutor indicado
                if (temaPracticaTutorItems.ElementAt(i).idPracticaTutor == idPracticaTutor)
                {
                    temaPracticaTutorEspecificos.Add(temaPracticaTutorItems.ElementAt(i));
                }
            }

            return temaPracticaTutorEspecificos;
        }

        /*
         * Ingresa a la base de datos un nuevo TemaPracticaTutor.
         */
        public void Create(TemaPracticaTutor temaPracticaTutor)
        {
            //Se verifica si existe
            if (temaPracticaTutor == null)
            {
                throw new ArgumentNullException(nameof(temaPracticaTutor));
            }

            //Se crea en la base de datos por medio del context
            _context.TemaPracticaTutor.Add(temaPracticaTutor);
        }

        public void Update(TemaPracticaTutor temaPracticaTutor)
        {
            throw new NotImplementedException();
        }

        public void Delete(TemaPracticaTutor temaPracticaTutor)
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
