using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface IOfertaLaboralRepo
    {
        IEnumerable<OfertaLaboral> GetAll();
        OfertaLaboral GetById(int id);
        IEnumerable<OfertaLaboral> GetByCarrera(int idCategoria);
        IEnumerable<OfertaLaboral> GetByEmpleador(int idCategoria);
        int GetId(int idEmpleador, string nombrePuesto);
        void Create(OfertaLaboral ofertaLaboral);
        void Update(OfertaLaboral ofertaLaboral);
        void Delete(OfertaLaboral ofertaLaboral);

        bool SaveChanges();
    }
}
