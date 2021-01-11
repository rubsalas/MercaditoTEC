using System.Collections.Generic;
using API_MercaditoTEC.Models;

namespace API_MercaditoTEC.Data
{
    public interface IEstudianteRepo
    {
        IEnumerable<Estudiante> GetAll();
        Estudiante GetById(int id);
        void Create(Estudiante estudiante);
        void Update(Estudiante estudiante);
        void Delete(Estudiante estudiante);

        bool SaveChanges();
    }
}
