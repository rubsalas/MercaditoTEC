using API_MercaditoTEC.Models.ModelsJ;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data.DataJ
{
    public interface ICursoTutorJRepo
    {
        IEnumerable<CursoTutorJ> GetAll();
        CursoTutorJ GetById(int id);
        IEnumerable<CursoTutorJ> GetByCurso(int idCurso);
        IEnumerable<CursoTutorJ> GetByEstudiante(int idEstudiante);
        IEnumerable<CursoTutorJ> GetByTutor(int idTutor);
        void Create(CursoTutorJ cursoTutorJ);
        void Update(CursoTutorJ cursoTutorJ);
        void Delete(CursoTutorJ cursoTutorJ);

        bool SaveChanges();
    }
}
