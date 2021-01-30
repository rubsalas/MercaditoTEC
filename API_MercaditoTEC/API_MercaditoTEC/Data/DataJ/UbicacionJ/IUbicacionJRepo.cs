using API_MercaditoTEC.Models.ModelsJ;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data.DataJ
{
    public interface IUbicacionJRepo
    {
        IEnumerable<UbicacionJ> GetAll();
        UbicacionJ GetById(int id);
        UbicacionJ GetByDistrito(string distrito);
        void Create(UbicacionJ ubicacionJ);
        void Update(UbicacionJ ubicacionJ);
        void Delete(UbicacionJ ubicacionJ);

        bool SaveChanges();
    }
}
