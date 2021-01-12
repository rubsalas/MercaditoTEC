using API_MercaditoTEC.Models.ModelsJ;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data.DataJ
{
    public interface IEstudianteJRepo
    {
        IEnumerable<EstudianteJ> GetAll();
        EstudianteJ GetById(int id);
        int GetId(string correoInstitucional);
        void Create(EstudianteJ estudianteJ);
        void Update(EstudianteJ estudianteJ);
        void Delete(EstudianteJ estudianteJ);

        bool SaveChanges();
    }
}
