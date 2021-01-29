using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface ITutoradoRepo
    {
        IEnumerable<Tutorado> GetAll();
        Tutorado GetById(int id);
        Tutorado GetByEstudiante(int idEstudiante);
        int GetId(int idEstudiante);
        void Create(Tutorado tutorado);
        void Update(Tutorado tutorado);
        void Delete(Tutorado tutorado);

        bool SaveChanges();
    }
}
