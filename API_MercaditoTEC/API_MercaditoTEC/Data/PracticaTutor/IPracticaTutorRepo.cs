using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface IPracticaTutorRepo
    {
        IEnumerable<PracticaTutor> GetAll();
        PracticaTutor GetById(int id);
        PracticaTutor GetByNombre(string nombre);
        IEnumerable<PracticaTutor> GetByCursoTutor(int idCursoTutor);
        void Create(PracticaTutor practicaTutor);
        void Update(PracticaTutor practicaTutor);
        void Delete(PracticaTutor practicaTutor);

        bool SaveChanges();
    }
}
