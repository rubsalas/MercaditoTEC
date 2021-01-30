using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlTasaCambioRepo : ITasaCambioRepo
    {
        private MercaditoTECContext _context;

        public SqlTasaCambioRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todas las TasaCambio de la base de datos.
         */
        public IEnumerable<TasaCambio> GetAll()
        {
            //Se retorna una lista de todas las TasaCambio.
            return _context.TasaCambio.ToList();
        }

        /*
         * Retorna una sola TasaCambio por su id.
         */
        public TasaCambio GetById(int id)
        {
            return _context.TasaCambio.FirstOrDefault(tc => tc.idTasaCambio == id);
        }

        /*
         * Retorna la ultima TasaCambio ingresada a la base de datos.
         */
        public TasaCambio GetCurrent()
        {
            //Se obtienen todas las TasaCambio
            IEnumerable<TasaCambio> tasaCambioItems = GetAll();

            return tasaCambioItems.LastOrDefault();
        }

        public void Create(TasaCambio tasaCambio)
        {
            throw new NotImplementedException();
        }

        public void Update(TasaCambio tasaCambio)
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
