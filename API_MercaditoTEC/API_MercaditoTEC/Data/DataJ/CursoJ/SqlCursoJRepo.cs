using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data.DataJ
{
    public class SqlCursoJRepo : ICursoJRepo
    {
        private readonly MercaditoTECContext _context;
        private readonly ICursoRepo _cursoRepo;
        private readonly ICarreraRepo _carreraRepo;
        private readonly IMapper _mapper;

        public SqlCursoJRepo(MercaditoTECContext context, ICursoRepo cursoRepo, ICarreraRepo carreraRepo, IMapper mapper)
        {
            _context = context;
            _cursoRepo = cursoRepo;
            _carreraRepo = carreraRepo;
            _mapper = mapper;
        }

        /*
         * Retorna todos los CursoJ con la informacion de Curso y Carrera.
         */
        public IEnumerable<CursoJ> GetAll()
        {
            //Mappeo de Curso

            //Se retorna una lista de todos los Cursos
            IEnumerable<Curso> cursoItems = _cursoRepo.GetAll();

            //Se mappea la parte de Curso a CursoJ
            IEnumerable<CursoJ> cursoJItems = _mapper.Map<IEnumerable<CursoJ>>(cursoItems);

            //Se itera atraves de todos los Cursos para mapearlos con su respectiva informacion restante de CursosJ
            for (int i = 0; i < cursoJItems.Count(); i++)
            {
                //Mappeo de Carrera

                //Se obtiene el idCarrera de Curso
                int idCarrera = cursoJItems.ElementAt(i).idCarrera;

                //Se obtiene la Carrera especifica del Curso
                Carrera carreraitem = _carreraRepo.GetById(idCarrera);

                //Se mappea el nombre de la carrera a mano por tener nombres diferentes
                cursoJItems.ElementAt(i).carrera = carreraitem.nombre;
            }

            return cursoJItems.ToList();
        }

        /*
         * Retorna un Curso con la informacion de Curso y Carrera.
         */
        public CursoJ GetById(int id)
        {
            //Mappeo de Curso

            //Se retorna un Curso con el idCurso indicado
            Curso cursoItemById = _cursoRepo.GetById(id);

            //Se mappea la parte de Curso a CursoJ
            CursoJ cursoJItemById = _mapper.Map<CursoJ>(cursoItemById);

            //Si el CursoJ existe
            if (cursoJItemById != null)
            {
                //Mappeo de Carrera

                //Se obtiene el idCarrera de Curso
                int idCarrera = cursoJItemById.idCarrera;

                //Se obtiene la Carrera especifica del Curso
                Carrera carreraitem = _carreraRepo.GetById(idCarrera);

                //Se mappea el nombre de la carrera a mano por tener nombres diferentes
                cursoJItemById.carrera = carreraitem.nombre;
            }

            return cursoJItemById;
        }

        /*
         * Retorna una lista de Cursos de una unica Carrera indicada.
         */
        public IEnumerable<CursoJ> GetByCarrera(int idCarrera)
        {
            //Mappeo de Curso

            //Se retorna una lista de todos los Cursos con el idCarrera indicado
            IEnumerable<Curso> cursoItemsByProducto = _cursoRepo.GetByCarrera(idCarrera);

            //Se mappea la parte de Curso a CursoJ
            IEnumerable<CursoJ> cursoJItemsByProducto = _mapper.Map<IEnumerable<CursoJ>>(cursoItemsByProducto);

            //Se obtiene la Carrera especifica del Curso con el idCarrera indicada
            Carrera carreraitem = _carreraRepo.GetById(idCarrera);

            //Se itera atraves de todos los Cursos respectivos para mapearlos con su respectiva informacion restante de CursosJ
            for (int i = 0; i < cursoJItemsByProducto.Count(); i++)
            {
                //Mappeo de Carrera

                //Se mappea el nombre de la carrera a mano por tener nombres diferentes
                cursoJItemsByProducto.ElementAt(i).carrera = carreraitem.nombre;
            }

            return cursoJItemsByProducto.ToList();
        }

        /*
         * Retorna el idCurso de un Curso especifico.
         */
        public int GetId(string nombre)
        {
            return _cursoRepo.GetId(nombre);
        }

        public void Create(CursoJ curso)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
