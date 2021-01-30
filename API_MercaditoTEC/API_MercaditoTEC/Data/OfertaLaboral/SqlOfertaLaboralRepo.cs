using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlOfertaLaboralRepo : IOfertaLaboralRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlOfertaLaboralRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todos los Productos de la base de datos.
         */
        public IEnumerable<OfertaLaboral> GetAll()
        {
            return _context.OfertaLaboral.ToList();
        }

        /*
         * Retorna un solo OfertaLaboral por su id.
         */
        public OfertaLaboral GetById(int id)
        {
            return _context.OfertaLaboral.FirstOrDefault(p => p.idOfertaLaboral == id);
        }

        /*
         * Retorna una lista de OfertaLaboral de la Carrera especificada.
         */
        public IEnumerable<OfertaLaboral> GetByCarrera(int idCarrera)
        {
            //Se obtienen todos las OfertaLaboral
            IEnumerable<OfertaLaboral> ofertaLaboralItems = GetAll();

            //Se crea una nueva lista donde se dejaran las OfertaLaboral especificas
            List<OfertaLaboral> ofertaLaboralByCarrera = new List<OfertaLaboral>();

            //Se iterara sobre todas las OfertaLaboral y quedaran solo los de una Carrera especifica
            for (int i = 0; i < ofertaLaboralItems.Count(); i++)
            {
                //Revisa que se cumpla el idCarrera
                if (ofertaLaboralItems.ElementAt(i).idCarrera == idCarrera)
                {
                    ofertaLaboralByCarrera.Add(ofertaLaboralItems.ElementAt(i));
                }
            }

            return ofertaLaboralByCarrera;
        }

        public IEnumerable<OfertaLaboral> GetByEmpleador(int idCategoria)
        {
            throw new NotImplementedException();
        }

        /*
         * Retorna el idProducto de un OfertaLaboral especifico.
         */
        public int GetId(int idEmpleador, string nombrePuesto)
        {
            //Se obtiene el idOfertaLaboral de una OfertaLaboral especifico
            int idOfertaLaboral = _context.OfertaLaboral.FirstOrDefault(ol => ol.idEmpleador == idEmpleador && ol.nombrePuesto == nombrePuesto).idOfertaLaboral;

            //Se verifica que el OfertaLaboral exista
            if (idOfertaLaboral > 0)
            {
                //Si existe, se retorna el idOfertaLaboral
                return idOfertaLaboral;
            }

            //Si no existe, se retorna un -1
            return -1;
        }

        public void Create(OfertaLaboral ofertaLaboral)
        {
            throw new NotImplementedException();
        }

        public void Update(OfertaLaboral ofertaLaboral)
        {
            throw new NotImplementedException();
        }

        public void Delete(OfertaLaboral ofertaLaboral)
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
