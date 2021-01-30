using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface ITemaPracticaTutorRepo
    {
        IEnumerable<TemaPracticaTutor> GetAll();
        TemaPracticaTutor GetById(int id);
        IEnumerable<TemaPracticaTutor> GetByPracticaTutor(int idPracticaTutor);
        void Create(TemaPracticaTutor temaPracticaTutor);
        void Update(TemaPracticaTutor temaPracticaTutor);
        void Delete(TemaPracticaTutor temaPracticaTutor);

        bool SaveChanges();
    }
}
