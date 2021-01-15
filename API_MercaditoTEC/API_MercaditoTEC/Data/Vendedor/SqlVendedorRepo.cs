using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlVendedorRepo : IVendedorRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlVendedorRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todos los Vendedores de la base de datos.
         */
        public IEnumerable<Vendedor> GetAll()
        {
            //Se retorna una lista de todos los Vendedores.
            return _context.Vendedor.ToList();
        }

        /*
         * Retorna un solo Vendedor por su id.
         */
        public Vendedor GetById(int id)
        {
            return _context.Vendedor.FirstOrDefault(v => v.idVendedor == id);
        }

        /*
         * Retorna el Vendedor con el Estudiante indicado.
         */
        public Vendedor GetByEstudiante(int idEstudiante)
        {
            //Se retorna el Vendedor especifico
            return _context.Vendedor.FirstOrDefault(v => v.idEstudiante == idEstudiante);
        }

        /*
         * Retorna el idVendedor de un Vendedor especifico.
         */
        public int GetId(int idEstudiante)
        {
            //Se obtiene el idVendedor de un Vendedor especifico
            int idVendedor = _context.Vendedor.FirstOrDefault(v => v.idEstudiante == idEstudiante).idVendedor;

            //Se verifica que el Vendedor exista
            if (idVendedor > 0)
            {
                //Si existe, se retorna el idVendedor
                return idVendedor;
            }

            //Si no existe, se retorna un -1
            return -1;
        }

        public void Create(Vendedor vendedor)
        {
            throw new NotImplementedException();
        }

        /*
         * Actualiza los datos de una Categoria en la base de datos.
         */
        public void Update(Vendedor vendedor)
        {
            //De esto se encarga el DbContext
        }

        public void Delete(Vendedor vendedor)
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
