using API_MercaditoTEC.Models.ModelsJ;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data.DataJ
{
    public interface IAdministradorJRepo
    {
        IEnumerable<AdministradorJ> GetAll();
        AdministradorJ GetById(int id);
        AdministradorJ GetByUsuario(string usuario);
        int GetId(string usuario);
        void Create(AdministradorJ administradorJ);
        void Update(AdministradorJ administradorJ);
        void Delete(AdministradorJ administradorJ);

        bool SaveChanges();
    }
}
