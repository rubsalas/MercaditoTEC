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

        public IEnumerable<Ubicacion> GetByCanton(int idCanton)
        {
            throw new System.NotImplementedException();
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
         * Retorna el idUbicacion de una Ubicacion especifica.
         */
        public int GetId(string distrito)
        {
            return _context.Ubicacion.FirstOrDefault(u => u.distrito == distrito).idUbicacion;
        }
   
    }
}
