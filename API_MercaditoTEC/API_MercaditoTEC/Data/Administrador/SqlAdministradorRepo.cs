using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlAdministradorRepo : IAdministradorRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlAdministradorRepo(MercaditoTECContext context)
        {
            _context = context;
        }


        /*
         * Retorna todas los Administradores de la base de datos.
         */
        public IEnumerable<Administrador> GetAll()
        {
            return _context.Administrador.ToList();
        }

        /*
         * Retorna un solo Administrador por su id.
         */
        public Administrador GetById(int id)
        {
            return _context.Administrador.FirstOrDefault(a => a.idAdministrador == id);
        }

        /*
         * Retorna un solo Administrador por su usuario.
         */
        public Administrador GetByUsuario(string usuario)
        {
            return _context.Administrador.FirstOrDefault(a => a.usuario == usuario);
        }

        /*
         * Retorna el idAdministrador de un Administrador especifico.
         */
        public int GetId(string usuario)
        {
            //Se obtiene el Administrador
            Administrador administradorItem = _context.Administrador.FirstOrDefault(a => a.usuario == usuario);

            //Se verifica que exista
            if (administradorItem != null)
            {
                //Si se encuentra, se retorna el idAdministrador deseado
                return administradorItem.idAdministrador;
            }

            //Si no se encuentra el Administrador se retorna un -1
            return -1;
        }

        /*
         * Ingresa a la base de datos un nuevo Administrador.
         */
        public void Create(Administrador administrador)
        {
            //Se verifica si el Administrador existe
            if (administrador == null)
            {
                throw new ArgumentNullException(nameof(administrador));
            }

            //Se crea el Administrador en la base de datos por medio del context
            _context.Administrador.Add(administrador);
        }

        /*
         * Actualiza los datos de un Administrador en la base de datos.
         */
        public void Update(Administrador administrador)
        {
            //De esto se encarga el DbContext
        }

        public void Delete(Administrador administrador)
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
