using System.Collections.Generic;
using API_MercaditoTEC.Models;

namespace API_MercaditoTEC.Data
{
    public interface IAdministradorRepo
    {
        IEnumerable<Administrador> GetAll();
        Administrador GetById(int id);
        Administrador GetByUsuario(string usuario);
        int GetId(string usuario);
        void Create(Administrador administrador);
        void Update(Administrador administrador);
        void Delete(Administrador administrador);

        bool SaveChanges();
    }
}
