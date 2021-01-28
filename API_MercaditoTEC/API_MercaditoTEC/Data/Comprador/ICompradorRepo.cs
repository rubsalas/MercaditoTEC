using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface ICompradorRepo
    {
        IEnumerable<Comprador> GetAll();
        Comprador GetById(int id);
        Comprador GetByEstudiante(int idEstudiante);
        int GetId(int idEstudiante);
        void Create(Comprador comprador);
        void Update(Comprador comprador);
        void Delete(Comprador comprador);

        bool SaveChanges();
    }
}
