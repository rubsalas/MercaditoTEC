using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface IUbicacionRepo
    {
        IEnumerable<Ubicacion> GetAll();
        Ubicacion GetById(int id);
        Ubicacion GetByDistrito(string distrito);
        IEnumerable<Ubicacion> GetByCanton(int idCanton);
        int GetId(string distrito);
    }
}
