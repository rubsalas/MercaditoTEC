using API_MercaditoTEC.Models.ModelsJ;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data.DataJ
{
    public interface IMetodoPagoPracticaTutorJRepo
    {
        IEnumerable<MetodoPagoPracticaTutorJ> GetAll();
        MetodoPagoPracticaTutorJ GetById(int id);
        IEnumerable<MetodoPagoPracticaTutorJ> GetByPracticaTutor(int idPracticaTutor);
        void Create(MetodoPagoPracticaTutorJ metodoPagoPracticaTutorJ);
        void Update(MetodoPagoPracticaTutorJ metodoPagoPracticaTutorJ);
        void Delete(MetodoPagoPracticaTutorJ metodoPagoPracticaTutorJ);

        bool SaveChanges();
    }
}
