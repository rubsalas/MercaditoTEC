using API_MercaditoTEC.Models.ModelsJ;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data.DataJ
{
    public interface ICompradorJRepo
    {
        IEnumerable<CompradorJ> GetAll();
        CompradorJ GetById(int id);
        CompradorJ GetByEstudiante(int idEstudiante);
        int GetId(int idEstudiante);
        void Create(CompradorJ compradorJ);
        void Update(CompradorJ compradorJ);
        void Delete(CompradorJ compradorJ);

        bool SaveChanges();
    }
}
