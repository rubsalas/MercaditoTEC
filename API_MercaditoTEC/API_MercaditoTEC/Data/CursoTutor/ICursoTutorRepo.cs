using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface ICursoTutorRepo
    {
        IEnumerable<CursoTutor> GetAll();
        CursoTutor GetById(int id);
        IEnumerable<CursoTutor> GetByCurso(int idCurso);
        IEnumerable<CursoTutor> GetByTutor(int idTutor);
        int GetId(int idTutor, int idCurso);
        void Create(CursoTutor cursoTutor);
        void Update(CursoTutor cursoTutor);
        void Delete(CursoTutor cursoTutor);

        bool SaveChanges();
    }
}
