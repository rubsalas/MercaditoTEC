using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlTutoradoRepo : ITutoradoRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlTutoradoRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todos los Tutorados de la base de datos.
         */
        public IEnumerable<Tutorado> GetAll()
        {
            return _context.Tutorado.ToList();
        }

        /*
         * Retorna un solo Tutorado por su id.
         */
        public Tutorado GetById(int id)
        {
            return _context.Tutorado.FirstOrDefault(t => t.idTutorado == id);
        }

        /*
         * Retorna el Tutorado con el Estudiante indicado.
         */
        public Tutorado GetByEstudiante(int idEstudiante)
        {
            return _context.Tutorado.FirstOrDefault(t => t.idEstudiante == idEstudiante);
        }

        /*
         * Retorna el idTutorado de un Tutorado especifico.
         */
        public int GetId(int idEstudiante)
        {
            //SE DEBE VERIFICAR PRIMERO QUE EL ESTUDIANTE EXISTA

            //Se obtiene el Tutorado
            Tutorado tutoradoItem = _context.Tutorado.FirstOrDefault(t => t.idEstudiante == idEstudiante);

            //Se verifica que el Tutorado exista
            if (tutoradoItem != null)
            {
                //Si existe, se retorna el idTutorado deseado
                return tutoradoItem.idTutorado;
            }

            //Si no existe, se retorna un -1
            return -1;
        }

        public void Create(Tutorado tutorado)
        {
            throw new NotImplementedException();
        }

        public void Update(Tutorado tutorado)
        {
            throw new NotImplementedException();
        }

        public void Delete(Tutorado tutorado)
        {
            throw new NotImplementedException();
        }

        /*
         * Guarda los cambios en la Base de Datos de SQLServer.
         */
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
