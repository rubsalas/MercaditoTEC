using API_MercaditoTEC.Models.ModelsJ;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data.DataJ
{
    public interface IPracticaTutorJRepo
    {
        IEnumerable<PracticaTutorJ> GetAll();
        PracticaTutorJ GetById(int id);
        PracticaTutorJ GetByNombre(string nombre);
        IEnumerable<PracticaTutorJ> GetByCursoTutor(int idCursoTutor);
        int GetId(int idCursoTutor, string nombre, string descripcion);
        void Create(PracticaTutorJ practicaTutorJ);
        void Update(PracticaTutorJ practicaTutorJ);
        void Delete(PracticaTutorJ practicaTutorJ);

        bool SaveChanges();
    }
}
