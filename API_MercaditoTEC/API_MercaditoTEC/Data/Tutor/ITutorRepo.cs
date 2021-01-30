using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface ITutorRepo
    {
        IEnumerable<Tutor> GetAll();
        Tutor GetById(int id);
        Tutor GetByEstudiante(int idEstudiante);
        int GetId(int idEstudiante);
        void Create(Tutor tutor);
        void Update(Tutor tutor);
        void Delete(Tutor tutor);

        bool SaveChanges();
    }
}
