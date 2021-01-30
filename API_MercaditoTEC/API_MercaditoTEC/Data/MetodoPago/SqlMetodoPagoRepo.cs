using API_MercaditoTEC.Models;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlMetodoPagoRepo : IMetodoPagoRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlMetodoPagoRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todos los MetodoPago de la base de datos.
         */
        public IEnumerable<MetodoPago> GetAll()
        {
            //Se retorna una lista de todos los MetodoPago.
            return _context.MetodoPago.ToList();
        }

        /*
         * Retorna un solo MetodoPago por su id.
         */
        public MetodoPago GetById(int id)
        {
            
            return _context.MetodoPago.FirstOrDefault(mP => mP.idMetodoPago == id);
        }

        /*
         * Retorna el MetodoPago con el nombre indicado.
         */
        public MetodoPago GetByNombre(string nombre)
        {
            //Se retorna el MetodoPago especifico
            return _context.MetodoPago.FirstOrDefault(mP => mP.nombre == nombre);
        }

        /*
         * Retorna el idMetodoPago de un MetodoPago especifico.
         */
        public int GetId(string nombre)
        {
            return _context.MetodoPago.FirstOrDefault(mp => mp.nombre == nombre).idMetodoPago;
        }
    }
}
