using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface IProvinciaRepo
    {
        IEnumerable<Provincia> GetAll();
        Provincia GetById(int id);
        Provincia GetByNombre(string nombre);
        int GetId(string nombre);
    }
}
