using API_MercaditoTEC.Models;
using System.Collections.Generic;
using System.Linq;
namespace API_MercaditoTEC.Data
{
    public class SqlUbicacionRepo : IUbicacionRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlUbicacionRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todas las Ubicaciones de la base de datos.
         */
        public IEnumerable<Ubicacion> GetAll()
        {
            //Se retorna una lista de todas las Ubicaciones
            return _context.Ubicacion.ToList();
        }

        /*
         * Retorna una sola Ubicacion por su id.
         */
        public Ubicacion GetById(int id)
        {
            return _context.Ubicacion.FirstOrDefault(u => u.idUbicacion == id);
        }

        /*
         * Retorna la Ubicacion con el distrito indicado.
         */
        public Ubicacion GetByDistrito(string distrito)
        {
            //Se retorna la Ubicacion especifica
            return _context.Ubicacion.FirstOrDefault(u => u.distrito == distrito);
        }

        /*
         * Retorna una lista de Ubicaciones de un Canton especifico
         */
        public IEnumerable<Ubicacion> GetByCanton(int idCanton)
        {
            //Se obtienen todos las Ubicaciones
            IEnumerable<Ubicacion> ubicaciones = GetAll();

            //Se crea una nueva lista donde se dejaran las Ubicaciones especificas
            List<Ubicacion> ubicacionesEspecificas = new List<Ubicacion>();

            //Se itera en la lista de todos las Ubicaciones
            for (int i = 0; i < ubicaciones.Count(); i++)
            {
                //Se obtiene de la lista de Ubicaciones los que correspondan al idCanton indicado
                if (ubicaciones.ElementAt(i).idCanton == idCanton)
                {
                    ubicacionesEspecificas.Add(ubicaciones.ElementAt(i));
                }
            }

            return ubicacionesEspecificas;
        }

        /*
         * Retorna el idUbicacion de una Ubicacion especifica.
         */
        public int GetId(string distrito)
        {
            return _context.Ubicacion.FirstOrDefault(u => u.distrito == distrito).idUbicacion;
        }
   
    }
}
