using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlCursoTutoradoRepo : ICursoTutoradoRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlCursoTutoradoRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todas los CursoTutorado de la base de datos.
         */
        public IEnumerable<CursoTutorado> GetAll()
        {
            return _context.CursoTutorado.ToList();
        }

        /*
         * Retorna un solo CursoTutorado por su id.
         */
        public CursoTutorado GetById(int id)
        {
            return _context.CursoTutorado.FirstOrDefault(ct => ct.idCursoTutorado == id);
        }

        /*
         * Retorna una lista de CursoTutorado del Tutorado especificado.
         */
        public IEnumerable<CursoTutorado> GetByTutorado(int idTutorado)
        {
            //Se obtienen todos los CursoTutorado
            IEnumerable<CursoTutorado> cursoTutoradoItems = GetAll();

            //Se crea una nueva lista donde se dejaran los CursoTutorado especificos
            List<CursoTutorado> cursoTutoradoByTutorado = new List<CursoTutorado>();

            //Se iterara sobre todas los CursoTutorado y quedaran solo los de un Tutorado especifico
            for (int i = 0; i < cursoTutoradoItems.Count(); i++)
            {
                //Revisa que se cumpla el idTutorado
                if (cursoTutoradoItems.ElementAt(i).idTutorado == idTutorado)
                {
                    cursoTutoradoByTutorado.Add(cursoTutoradoItems.ElementAt(i));
                }
            }

            return cursoTutoradoByTutorado;
        }

        /*
         * Retorna una lista de CursoTutorado del CursoTutor especificado.
         */
        public IEnumerable<CursoTutorado> GetByCursoTutor(int idCursoTutor)
        {
            //Se obtienen todos los CursoTutorado
            IEnumerable<CursoTutorado> cursoTutoradoItems = GetAll();

            //Se crea una nueva lista donde se dejaran los CursoTutorado especificos
            List<CursoTutorado> cursoTutoradoByCursoTutor = new List<CursoTutorado>();

            //Se iterara sobre todas los CursoTutorado y quedaran solo los de un CursoTutor especifico
            for (int i = 0; i < cursoTutoradoItems.Count(); i++)
            {
                //Revisa que se cumpla el idCursoTutor
                if (cursoTutoradoItems.ElementAt(i).idCursoTutor == idCursoTutor)
                {
                    cursoTutoradoByCursoTutor.Add(cursoTutoradoItems.ElementAt(i));
                }
            }

            return cursoTutoradoByCursoTutor;
        }

        /*
         * Retorna el idCursoTutorado de un CursoTutorado especifico.
         */
        public int GetId(int idTutorado, int idCursoTutor)
        {
            //Se obtiene el CursoTutorado
            CursoTutorado cursoTutoradoitem = _context.CursoTutorado.FirstOrDefault(ct => ct.idTutorado == idTutorado && ct.idCursoTutor == idCursoTutor);

            //Se verifica que el CursoTutorado exista
            if (cursoTutoradoitem != null)
            {
                //Si existe, se retorna el idCursoTutorado deseado
                return cursoTutoradoitem.idCursoTutorado;
            }

            //Si no existe, se retorna un -1
            return -1;
        }

        /*
         * Ingresa a la base de datos un nuevo CursoTutorado.
         */
        public void Create(CursoTutorado cursoTutorado)
        {
            //Se verifica si el CursoTutorado existe
            if (cursoTutorado == null)
            {
                throw new ArgumentNullException(nameof(cursoTutorado));
            }

            //Se crea el CursoTutorado en la base de datos por medio del context
            _context.CursoTutorado.Add(cursoTutorado);
        }

        /*
         * Actualiza los datos de una CursoTutorado en la base de datos.
         */
        public void Update(CursoTutorado cursoTutorado)
        {
            //De esto se encarga el DbContext
        }

        public void Delete(CursoTutorado cursoTutorado)
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
