using API_MercaditoTEC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlPersonaRepo : IPersonaRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlPersonaRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        public IEnumerable<Persona> GetAll()
        {
            return _context.Persona.ToList();
        }

        public Persona GetById(int id)
        {
            return _context.Persona.FirstOrDefault(p => p.idPersona == id);
        }
    }
}
