using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface IMetodoPagoRepo
    {
        IEnumerable<MetodoPago> GetAll();
        MetodoPago GetById(int id);
        MetodoPago GetByNombre(string nombre);
        int GetId(string nombre);
    }
}
