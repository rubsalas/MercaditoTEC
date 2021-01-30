using API_MercaditoTEC.Models.ModelsJ;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data.DataJ
{
    public interface ITutorJRepo
    {
        IEnumerable<TutorJ> GetAll();
        TutorJ GetById(int id);
        TutorJ GetByEstudiante(int idEstudiante);
        int GetId(int idEstudiante);
        void Create(TutorJ tutorJ);
        void Update(TutorJ tutorJ);
        void Delete(TutorJ tutorJ);

        bool SaveChanges();
    }
}
