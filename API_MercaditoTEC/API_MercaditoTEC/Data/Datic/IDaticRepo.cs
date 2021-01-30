using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface IDaticRepo
    {
        IEnumerable<Datic> GetAll();
        Datic GetByCorreo(string correo);
        void Create(Datic datic);
        void Update(Datic datic);
        void Delete(Datic datic);

        bool SaveChanges();
    }
}
