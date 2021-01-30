using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface ICantonRepo
    {
        IEnumerable<Canton> GetAll();
        Canton GetById(int id);
        Canton GetByNombre(string nombre);
        IEnumerable<Canton> GetByProvincia(int idProvincia);
        int GetId(string nombre);
    }
}
