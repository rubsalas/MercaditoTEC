using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface ICantonRepo
    {
        IEnumerable<Canton> GetAll();
        Canton GetById(int id);
        Canton GetByNombre(string nombre);
        int GetId(string nombre);
    }
}
