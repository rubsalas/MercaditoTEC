using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface ICursoRepo
    {
        IEnumerable<Curso> GetAll();
        Curso GetById(int id);
        IEnumerable<Curso> GetByCarrera(int idCarrera);
        int GetId(string nombre);
        void Create(Curso curso);

        bool SaveChanges();
    }
}
