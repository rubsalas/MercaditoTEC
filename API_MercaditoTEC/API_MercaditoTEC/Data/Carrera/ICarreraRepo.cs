using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface ICarreraRepo
    {
        IEnumerable<Carrera> GetAll();
        Carrera GetById(int id);
        int GetId(string nombre);
        void Create(Carrera carrera);

        bool SaveChanges();
    }
}
