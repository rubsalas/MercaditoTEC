using API_MercaditoTEC.Models.ModelsJ;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data.DataJ
{
    public interface ICursoJRepo
    {
        IEnumerable<CursoJ> GetAll();
        CursoJ GetById(int id);
        IEnumerable<CursoJ> GetByCarrera(int idCarrera);
        int GetId(string nombre);
        void Create(CursoJ curso);

        bool SaveChanges();
    }
}
