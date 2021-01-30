using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data.DataJ
{
    public class SqlOfertaLaboralJRepo : IOfertaLaboralJRepo
    {
        private readonly MercaditoTECContext _context;
        private readonly IOfertaLaboralRepo _ofertaLaboralJRepo;
        private readonly IMapper _mapper;

        public SqlOfertaLaboralJRepo(MercaditoTECContext context, IOfertaLaboralRepo ofertaLaboralJRepo, IMapper mapper)
        {
            _context = context;
            _ofertaLaboralJRepo = ofertaLaboralJRepo;
            _mapper = mapper;
        }

        public IEnumerable<OfertaLaboralJ> GetAll()
        {
            throw new NotImplementedException();
        }

        /*
         * Retorna todos los OfertaLaboralJ con la informacion de OfertaLaboral y ... .
         */
        public IEnumerable<OfertaLaboralJ> GetByCarrera(int idCarrera)
        {
            //Mappeo de OfertaLaboral

            //Se retorna una lista de todas las OfertaLaboral de una Carrera
            IEnumerable<OfertaLaboral> ofertaLaboralItems = _ofertaLaboralJRepo.GetByCarrera(idCarrera);

            //Se mappea la parte de OfertaLaboral al OfertaLaboralJ
            IEnumerable<OfertaLaboralJ> ofertaLaboralJItems = _mapper.Map<IEnumerable<OfertaLaboralJ>>(ofertaLaboralItems);

            //Se itera atraves de todas las OfertaLaboral para mapearlos con su respectiva informacion restante de OfertaLaboralJ
            for (int i = 0; i < ofertaLaboralJItems.Count(); i++)
            {
                //Mappeo
            }

            return ofertaLaboralJItems;
        }

        public IEnumerable<OfertaLaboralJ> GetByEmpleador(int idEmpleador)
        {
            throw new NotImplementedException();
        }

        public OfertaLaboralJ GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetId(int idEmpleador, string nombrePuesto)
        {
            throw new NotImplementedException();
        }

        public void Create(OfertaLaboralJ ofertaLaboralJ)
        {
            throw new NotImplementedException();
        }

        public void Update(OfertaLaboralJ ofertaLaboralJ)
        {
            throw new NotImplementedException();
        }

        public void Delete(OfertaLaboralJ ofertaLaboralJ)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

    }
}
