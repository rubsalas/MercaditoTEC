using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlMetodoPagoPracticaTutorRepo : IMetodoPagoPracticaTutorRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlMetodoPagoPracticaTutorRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todos los MetodoPagoPracticaTutor de la base de datos.
         */
        public IEnumerable<MetodoPagoPracticaTutor> GetAll()
        {
            return _context.MetodoPagoPracticaTutor.ToList();
        }

        /*
         * Retorna un solo MetodoPagoPracticaTutor por su id.
         */
        public MetodoPagoPracticaTutor GetById(int id)
        {
            return _context.MetodoPagoPracticaTutor.FirstOrDefault(mppt => mppt.idMetodoPagoPracticaTutor == id);
        }

        /*
         * Retorna una lista de MetodoPagoPracticaTutor de una unica PracticaTutor indicada.
         */
        public IEnumerable<MetodoPagoPracticaTutor> GetByPracticaTutor(int idPracticaTutor)
        {
            //Se obtienen todos los MetodoPagoPracticaTutor
            IEnumerable<MetodoPagoPracticaTutor> metodoPagoPracticaTutorItems = GetAll();

            //Se crea una nueva lista donde se dejaran los MetodoPagoPracticaTutor especificos
            List<MetodoPagoPracticaTutor> metodoPagoPracticaTutorEspecificos = new List<MetodoPagoPracticaTutor>();

            for (int i = 0; i < metodoPagoPracticaTutorItems.Count(); i++)
            {
                //Se obtiene de la lista de MetodoPagoPracticaTutor los que correspondan al idPracticaTutor indicado
                if (metodoPagoPracticaTutorItems.ElementAt(i).idPracticaTutor == idPracticaTutor)
                {
                    metodoPagoPracticaTutorEspecificos.Add(metodoPagoPracticaTutorItems.ElementAt(i));
                }
            }

            return metodoPagoPracticaTutorEspecificos;
        }

        /*
         * Ingresa a la base de datos un nuevo MetodoPagoPracticaTutor.
         */
        public void Create(MetodoPagoPracticaTutor metodoPagoPracticaTutor)
        {
            //Se verifica si existe
            if (metodoPagoPracticaTutor == null)
            {
                throw new ArgumentNullException(nameof(metodoPagoPracticaTutor));
            }

            //Se crea en la base de datos por medio del context
            _context.MetodoPagoPracticaTutor.Add(metodoPagoPracticaTutor);
        }

        public void Update(MetodoPagoPracticaTutor metodoPagoPracticaTutor)
        {
            throw new NotImplementedException();
        }

        public void Delete(MetodoPagoPracticaTutor metodoPagoPracticaTutor)
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
