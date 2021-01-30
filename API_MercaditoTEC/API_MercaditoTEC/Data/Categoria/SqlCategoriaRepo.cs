using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlCategoriaRepo : ICategoriaRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlCategoriaRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todas las Categorias de la base de datos.
         */
        public IEnumerable<Categoria> GetAll()
        {
            //Se retorna una lista de todas las Categorias.
            return _context.Categoria.ToList();
        }

        /*
         * Retorna una sola Categoria por su id.
         */
        public Categoria GetById(int id)
        {
            return _context.Categoria.FirstOrDefault(c => c.idCategoria == id);
        }

        /*
         * Retorna la Categoria con el nombre indicado.
         */
        public Categoria GetByNombre(string nombre)
        {
            //Se retorna la Categoria especifica
            return _context.Categoria.FirstOrDefault(c => c.nombre == nombre);
        }

        /*
         * Retorna el idCategoria de una Categoria especifica.
         */
        public int GetId(string nombre)
        {
            //Se obtienen todas las Categorias
            IEnumerable<Categoria> categoriaItems = GetAll();

            //Se itera atraves de todos las Categorias
            for (int i = 0; i < categoriaItems.Count(); i++)
            {
                //Se obtiene una Categoria
                Categoria categoriaI = categoriaItems.ElementAt(i);

                //Se verifica que sea la Categoria que se busca
                if (categoriaI.nombre == nombre)
                {
                    //Si se encuentra, se retorna el idCategoria deseado
                    return categoriaI.idCategoria;
                }
            }

            //Si no se encuentra la Categoria se retorna un -1
            return -1;

        }

        /*
         * Ingresa a la base de datos una nueva Categoria.
         */
        public void Create(Categoria categoria)
        {
            //Se verifica si la Categoria existe
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }

            //Se crea la categoria en la base de datos por medio del context
            _context.Categoria.Add(categoria);
        }

        /*
         * Actualiza los datos de una Categoria en la base de datos.
         */
        public void Update(Categoria categoria)
        {
            //De esto se encarga el DbContext
        }

        /*
         * Elimina los datos de una Categoria en la base de datos.
         */
        public void Delete(Categoria categoria)
        {
            //Se verifica si la Categoria existe
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }

            //Se elimina la Categoria de la base de datos por medio del context
            _context.Categoria.Remove(categoria);
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
