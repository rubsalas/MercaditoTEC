using API_MercaditoTEC.Models.ModelsJ;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data.DataJ
{
    public interface ICursoTutoradoJRepo
    {
        IEnumerable<CursoTutoradoJ> GetAll();
        CursoTutoradoJ GetById(int id);
        IEnumerable<CursoTutoradoJ> GetByTutorado(int idTutorado);
        IEnumerable<CursoTutoradoJ> GetByCursoTutor(int idCursoTutor);
        int GetId(int idTutorado, int idCursoTutor);
        void Create(CursoTutoradoJ cursoTutoradoJ);
        void Update(CursoTutoradoJ cursoTutoradoJ);
        void Delete(CursoTutoradoJ cursoTutoradoJ);

        bool SaveChanges();
    }
}
