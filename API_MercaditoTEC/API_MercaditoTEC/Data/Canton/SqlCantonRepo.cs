using API_MercaditoTEC.Models;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlCantonRepo : ICantonRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlCantonRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todos los Cantones de la base de datos.
         */
        public IEnumerable<Canton> GetAll()
        {
            //Se retorna una lista de todos los Cantones.
            return _context.Canton.ToList();
        }

        /*
         * Retorna un solo Canton por su id.
         */
        public Canton GetById(int id)
        {
            return _context.Canton.FirstOrDefault(c => c.idCanton == id);
        }

        /*
         * Retorna el Canton con el nombre indicado.
         */
        public Canton GetByNombre(string nombre)
        {
            return _context.Canton.FirstOrDefault(c => c.nombre == nombre);
        }

        /*
         * Retorna una lista de Cantones de una Provincia especifica
         */
        public IEnumerable<Canton> GetByProvincia(int idProvincia)
        {
            //Se obtienen todos los Cantones
            IEnumerable<Canton> cantones = GetAll();

            //Se crea una nueva lista donde se dejaran los Cantones especificos
            List<Canton> cantonesEspecificos = new List<Canton>();

            //Se itera en la lista de todos los Cantones
            for (int i = 0; i < cantones.Count(); i++)
            {
                //Se obtiene de la lista de Cantones los que correspondan al idProvincia indicado
                if (cantones.ElementAt(i).idProvincia == idProvincia)
                {
                    cantonesEspecificos.Add(cantones.ElementAt(i));
                }
            }

            return cantonesEspecificos;
        }

        /*
         * Retorna el idCanton de un Canton especifico.
         */
        public int GetId(string nombre)
        {
            return _context.Canton.FirstOrDefault(c => c.nombre == nombre).idCanton;
        }
    }
}
