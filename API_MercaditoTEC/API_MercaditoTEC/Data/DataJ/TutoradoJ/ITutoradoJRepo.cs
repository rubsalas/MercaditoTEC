using API_MercaditoTEC.Models.ModelsJ;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data.DataJ
{
    public interface ITutoradoJRepo
    {
        IEnumerable<TutoradoJ> GetAll();
        TutoradoJ GetById(int id);
        TutoradoJ GetByEstudiante(int idEstudiante);
        int GetId(int idEstudiante);
        void Create(TutoradoJ tutoradoJ);
        void Update(TutoradoJ tutoradoJ);
        void Delete(TutoradoJ tutoradoJ);

        bool SaveChanges();
    }
}
