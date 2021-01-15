using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace API_MercaditoTEC.Data
{
    public class SqlEstudianteRepo : IEstudianteRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlEstudianteRepo(MercaditoTECContext context)
        {
            _context = context;
        }


        /*
         * Retorna todas los Estudiantes de la base de datos.
         */
        public IEnumerable<Estudiante> GetAll()
        {
            //Se retorna una lista de todos los Estudiantes.
            return _context.Estudiante.ToList();
        }

        /*
         * Retorna un solo Estudiante por su id.
         */
        public Estudiante GetById(int id)
        {
            return _context.Estudiante.FirstOrDefault(e => e.idEstudiante == id);
        }

        /*
         * Retorna el idEstudiante de un Estudiante especifico.
         */
        public int GetId(string correoInstitucional)
        {
            //Se obtienen todos los Estudiantes
            IEnumerable<Estudiante> estudianteItems = GetAll();

            //Se itera atraves de todos los Estudiantes
            for (int i = 0; i < estudianteItems.Count(); i++)
            {
                //Se obtiene un Estudiante
                Estudiante estudianteI = estudianteItems.ElementAt(i);

                //Se verifica que sea el Estudiante que se busca
                if (estudianteI.correoInstitucional == correoInstitucional)
                {
                    //Si se encuentra, se retorna el idEstudiante deseado
                    return estudianteI.idEstudiante;
                }
            }

            //Si no se encuentra el Estudiante se retorna un -1
            return -1;
        }

        /*
         * Ingresa a la base de datos un nuevo Estudiante.
         */
        public void Create(Estudiante estudiante)
        {
            //Se verifica si el Estudiante existe
            if (estudiante == null)
            {
                throw new ArgumentNullException(nameof(estudiante));
            }

            //Se crea el Estudiante en la base de datos por medio del context
            _context.Estudiante.Add(estudiante);
        }

        /*
         * Actualiza los datos de un Estudiante en la base de datos.
         */
        public void Update(Estudiante estudiante)
        {
            //De esto se encarga el DbContext
        }

        /*
         * Elimina los datos de un Estudiante en la base de datos.
         */
        public void Delete(Estudiante estudiante)
        {
            //Se verifica si el Estudiante existe
            if (estudiante == null)
            {
                throw new ArgumentNullException(nameof(estudiante));
            }

            //Se elimina el Estudiante de la base de datos por medio del context
            _context.Estudiante.Remove(estudiante);
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
