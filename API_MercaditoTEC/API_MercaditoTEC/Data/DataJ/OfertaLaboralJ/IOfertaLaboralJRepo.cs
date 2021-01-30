using API_MercaditoTEC.Models.ModelsJ;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data.DataJ
{
    public interface IOfertaLaboralJRepo
    {
        IEnumerable<OfertaLaboralJ> GetAll();
        OfertaLaboralJ GetById(int id);
        IEnumerable<OfertaLaboralJ> GetByCarrera(int idCarrera);
        IEnumerable<OfertaLaboralJ> GetByEmpleador(int idEmpleador);
        int GetId(int idEmpleador, string nombrePuesto);
        void Create(OfertaLaboralJ ofertaLaboralJ);
        void Update(OfertaLaboralJ ofertaLaboralJ);
        void Delete(OfertaLaboralJ ofertaLaboralJ);

        bool SaveChanges();
    }
}
