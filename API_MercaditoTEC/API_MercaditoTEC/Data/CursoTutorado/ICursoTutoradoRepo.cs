using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface ICursoTutoradoRepo
    {
        IEnumerable<CursoTutorado> GetAll();
        CursoTutorado GetById(int id);
        IEnumerable<CursoTutorado> GetByTutorado(int idTutorado);
        IEnumerable<CursoTutorado> GetByCursoTutor(int idCursoTutor);
        int GetId(int idTutorado, int idCursoTutor);
        void Create(CursoTutorado cursoTutorado);
        void Update(CursoTutorado cursoTutorado);
        void Delete(CursoTutorado cursoTutorado);

        bool SaveChanges();
    }
}
