using API_MercaditoTEC.Models;
using System;
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

        public IEnumerable<MetodoPago> GetAll()
        {
            throw new NotImplementedException();
        }

        /*
         * Retorna un solo MetodoPago por su id.
         */
        public MetodoPago GetById(int id)
        {
            
            return _context.MetodoPago.FirstOrDefault(mP => mP.idMetodoPago == id);
        }

        /*
         * Retorna el Vendedor con el nombre indicado.
         */
        public MetodoPago GetByNombre(string nombre)
        {
            //Se retorna el Vendedor especifico
            return _context.MetodoPago.FirstOrDefault(mP => mP.nombre == nombre);
        }

        public int GetId(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
