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
        private readonly IVendedorRepo _vendedorJRepo;

        public SqlOfertaLaboralJRepo(MercaditoTECContext context, IVendedorRepo vendedorJRepo)
        {
            _context = context;
            _vendedorJRepo = vendedorJRepo;
        }

        public IEnumerable<OfertaLaboralJ> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OfertaLaboralJ> GetByCarrera(int idCategoria)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OfertaLaboralJ> GetByEmpleador(int idCategoria)
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
