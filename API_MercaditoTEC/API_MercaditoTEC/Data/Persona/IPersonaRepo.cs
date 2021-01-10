using API_MercaditoTEC.Models;
using System.Collections.Generic; 

namespace API_MercaditoTEC.Data
{
    public interface IPersonaRepo
    {
        bool SaveChanges();
        
        IEnumerable<Persona> GetAll();
        Persona GetById(int id);
        void Create(Persona persona);
        void Update(Persona persona);
    }
}
