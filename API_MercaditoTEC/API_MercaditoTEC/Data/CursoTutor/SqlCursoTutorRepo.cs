﻿using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlCursoTutorRepo : ICursoTutorRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlCursoTutorRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todos los CursoTutor de la base de datos.
         */
        public IEnumerable<CursoTutor> GetAll()
        {
            //Se retorna una lista de todos los CursoTutor.
            return _context.CursoTutor.ToList();
        }

        /*
         * Retorna un solo CursoTutor por su id.
         */
        public CursoTutor GetById(int id)
        {
            return _context.CursoTutor.FirstOrDefault(ct => ct.idCursoTutor == id);
        }

        /*
         * Retorna una lista de CursoTutor de un unico Curso indicado.
         */
        public IEnumerable<CursoTutor> GetByCurso(int idCurso)
        {
            //Se obtienen todos los CursoTutor
            IEnumerable<CursoTutor> cursoTutorItems = GetAll();

            //Se crea una nueva lista donde se dejaran los CursoTutor especificos
            List<CursoTutor> cursoTutorEspecificos = new List<CursoTutor>();

            //Se itera en la lista de todos los CursoTutor
            for (int i = 0; i < cursoTutorItems.Count(); i++)
            {
                //Se obtiene de la lista de CursoTutor los que correspondan al idCurso indicado
                if (cursoTutorItems.ElementAt(i).idCurso == idCurso)
                {
                    cursoTutorEspecificos.Add(cursoTutorItems.ElementAt(i));
                }
            }

            return cursoTutorEspecificos;
        }

        /*
         * Retorna una lista de CursoTutor de un unico Tutor indicado.
         */
        public IEnumerable<CursoTutor> GetByTutor(int idTutor)
        {
            //Se obtienen todos los CursoTutor
            IEnumerable<CursoTutor> cursoTutorItems = GetAll();

            //Se crea una nueva lista donde se dejaran los CursoTutor especificos
            List<CursoTutor> cursoTutorEspecificos = new List<CursoTutor>();

            //Se itera en la lista de todos los CursoTutor
            for (int i = 0; i < cursoTutorItems.Count(); i++)
            {
                //Se obtiene de la lista de CursoTutor los que correspondan al idTutor indicado
                if (cursoTutorItems.ElementAt(i).idTutor == idTutor)
                {
                    cursoTutorEspecificos.Add(cursoTutorItems.ElementAt(i));
                }
            }

            return cursoTutorEspecificos;
        }

        public int GetId(int idTutor, int idCurso)
        {
            //Se obtiene el idCrusoTutor de un CursoTutor especifico
            int idCursoTutor = _context.CursoTutor.FirstOrDefault(ct => ct.idTutor == idTutor && ct.idCurso == idCurso).idCursoTutor;

            //Se verifica que el Producto exista
            if (idCursoTutor > 0)
            {
                //Si existe, se retorna el idProducto
                return idCursoTutor;
            }

            //Si no existe, se retorna un -1
            return -1;
        }

        /*
         * Ingresa a la base de datos un nuevo CursoTutor.
         */
        public void Create(CursoTutor cursoTutor)
        {
            //Se verifica si el CursoTutor existe
            if (cursoTutor == null)
            {
                throw new ArgumentNullException(nameof(cursoTutor));
            }

            //Se crea el CursoTutor en la base de datos por medio del context
            _context.CursoTutor.Add(cursoTutor);
        }

        public void Update(CursoTutor cursoTutor)
        {
            throw new NotImplementedException();
        }

        public void Delete(CursoTutor cursoTutor)
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
