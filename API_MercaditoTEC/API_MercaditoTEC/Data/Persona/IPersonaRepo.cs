using API_MercaditoTEC.Models;
using System.Collections.Generic; 

namespace API_MercaditoTEC.Data
{
    public interface IPersonaRepo
    {
        IEnumerable<Persona> GetAll();
        Persona GetById(int id);
        void Create(Persona persona);
        void Update(Persona persona);
        void Delete(Persona persona);

        bool SaveChanges();
    }
}
