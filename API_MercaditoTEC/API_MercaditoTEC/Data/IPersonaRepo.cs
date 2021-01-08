using API_MercaditoTEC.Models;
using System.Collections.Generic; 

namespace API_MercaditoTEC.Data
{
    public interface IPersonaRepo
    {
        /*
         * Retorna todas las personas de la base de datos.
         */
        IEnumerable<Persona> GetAll();

        /*
         * Retorna una sola persona por su id.
         */
        Persona GetById(int id);
    }
}
