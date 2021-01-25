using API_MercaditoTEC.Models;
using System.Collections.Generic;


namespace API_MercaditoTEC.Data
{
    public interface IMetodoPagoPracticaTutorRepo
    {
        IEnumerable<MetodoPagoPracticaTutor> GetAll();
        MetodoPagoPracticaTutor GetById(int id);
        IEnumerable<MetodoPagoPracticaTutor> GetByPracticaTutor(int idPracticaTutor);
        void Create(MetodoPagoPracticaTutor metodoPagoPracticaTutor);
        void Update(MetodoPagoPracticaTutor metodoPagoPracticaTutor);
        void Delete(MetodoPagoPracticaTutor metodoPagoPracticaTutor);

        bool SaveChanges();
    }
}
