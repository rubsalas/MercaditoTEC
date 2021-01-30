using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface ITasaCambioRepo
    {
        IEnumerable<TasaCambio> GetAll();
        TasaCambio GetById(int id);
        TasaCambio GetCurrent();
        void Create(TasaCambio tasaCambio);
        void Update(TasaCambio tasaCambio);

        bool SaveChanges();
    }
}
