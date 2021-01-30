using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlCompradorRepo : ICompradorRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlCompradorRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todos los Compradores de la base de datos.
         */
        public IEnumerable<Comprador> GetAll()
        {
            return _context.Comprador.ToList();
        }

        /*
         * Retorna un solo Comprador por su id.
         */
        public Comprador GetById(int id)
        {
            return _context.Comprador.FirstOrDefault(c => c.idComprador == id);
        }

        /*
         * Retorna el Comprador con el Estudiante indicado.
         */
        public Comprador GetByEstudiante(int idEstudiante)
        {
            return _context.Comprador.FirstOrDefault(c => c.idEstudiante == idEstudiante);
        }

        /*
         * Retorna el idComprador de un Comprador especifico.
         */
        public int GetId(int idEstudiante)
        {
            //SE DEBE VERIFICAR PRIMERO QUE EL ESTUDIANTE EXISTA

            //Se obtiene el Comprador
            Comprador compradorItem = _context.Comprador.FirstOrDefault(c => c.idEstudiante== idEstudiante);

            //Se verifica que el Comprador exista
            if (compradorItem != null)
            {
                //Si existe, se retorna el idComprador deseado
                return compradorItem.idComprador;
            }

            //Si no existe, se retorna un -1
            return -1;
        }

        public void Create(Comprador comprador)
        {
            throw new NotImplementedException();
        }

        public void Update(Comprador comprador)
        {
            throw new NotImplementedException();
        }

        public void Delete(Comprador comprador)
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
