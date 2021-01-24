using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlCursoRepo : ICursoRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlCursoRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todos los Cursos de la base de datos.
         */
        public IEnumerable<Curso> GetAll()
        {
            //Se retorna una lista de todas los Cursos.
            return _context.Curso.ToList();
        }

        /*
         * Retorna un solo Curso por su id.
         */
        public Curso GetById(int id)
        {
            return _context.Curso.FirstOrDefault(c => c.idCurso == id);
        }

        /*
         * Retorna una lista de Cursos de una unica Carrera indicada.
         */
        public IEnumerable<Curso> GetByCarrera(int idCarrera)
        {
            //Se obtienen todas los Cursos
            IEnumerable<Curso> cursoItems = GetAll();

            //Se crea una nueva lista donde se dejaran los Cursos especificos
            List<Curso> cursosByCarrera = new List<Curso>();

            for (int i = 0; i < cursoItems.Count(); i++)
            {
                //Se obtiene de la lista de Cursos los que correspondan al idCarrera indicado
                if (cursoItems.ElementAt(i).idCarrera == idCarrera)
                {
                    cursosByCarrera.Add(cursoItems.ElementAt(i));
                }
            }

            return cursosByCarrera;
        }

        /*
         * Retorna el idCurso de un Curso especifico.
         */
        public int GetId(string nombre)
        {
            return _context.Curso.FirstOrDefault(c => c.nombre == nombre).idCurso;
        }

        public void Create(Curso curso)
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
