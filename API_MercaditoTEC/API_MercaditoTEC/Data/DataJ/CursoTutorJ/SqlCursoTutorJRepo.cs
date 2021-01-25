using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data.DataJ
{
    public class SqlCursoTutorJRepo : ICursoTutorJRepo
    {
        private readonly MercaditoTECContext _context;
        private readonly ICursoTutorRepo _cursoTutorRepo;
        private readonly ICursoJRepo _cursoJRepo;
        private readonly ITutorJRepo _tutorJRepo;
        private readonly IMapper _mapper;

        public SqlCursoTutorJRepo(MercaditoTECContext context, ICursoTutorRepo cursoTutorRepo, ICursoJRepo cursoJRepo, ITutorJRepo tutorJRepo, IMapper mapper)
        {
            _context = context;
            _cursoTutorRepo = cursoTutorRepo;
            _cursoJRepo = cursoJRepo;
            _tutorJRepo = tutorJRepo;
            _mapper = mapper;
        }

        /*
         * Retorna todos los CursoTutorJ de la base de datos.
         */
        public IEnumerable<CursoTutorJ> GetAll()
        {
            //Mappeo de CursoTutor

            //Se retorna una lista de todos los CursoTutor
            IEnumerable<CursoTutor> cursoTutorItems = _cursoTutorRepo.GetAll();

            //Se mappea la parte de CursoTutor a CursoTutorJ
            IEnumerable<CursoTutorJ> cursoTutorJItems = _mapper.Map<IEnumerable<CursoTutorJ>>(cursoTutorItems);

            //Se itera atraves de todos los CursoTutor para mapearlos con su respectiva informacion restante de CursoTutorJ
            for (int i = 0; i < cursoTutorJItems.Count(); i++)
            {
                //Mappeo de CursoJ

                //Se obtiene el idCurso de CursoTutorJ
                int idCurso = cursoTutorJItems.ElementAt(i).idCurso;

                //Se obtiene el CursoJ especifico del CursoTutorJ
                CursoJ cursoJItem = _cursoJRepo.GetById(idCurso);

                //Se mappea el CursoJ al CursoTutorJ correspondiente
                _mapper.Map(cursoJItem, cursoTutorJItems.ElementAt(i));

                //Mappeo de TutorJ

                //Se obtiene el idTutor de CursoTutorJ
                int idTutor = cursoTutorJItems.ElementAt(i).idTutor;

                //Se obtiene el TutorJ especifico del CursoTutorJ
                TutorJ tutorJItem = _tutorJRepo.GetById(idTutor);

                //Se mappea el TutorJ al CursoTutorJ correspondiente
                _mapper.Map(tutorJItem, cursoTutorJItems.ElementAt(i));

                //Mappeo de CursoJ(nombreCurso)

                //Se debe mapear manualmente el nombre del curso despues por tener el mismo nombre con el nomobre del Estudiante
                cursoTutorJItems.ElementAt(i).nombreCurso = cursoJItem.nombre;
            }

            return cursoTutorJItems.ToList();
        }

        /*
         * Retorna un solo CursoTutorJ por su id.
         */
        public CursoTutorJ GetById(int id)
        {
            //Mappeo de CursoTutor

            //Se retorna un CursoTutor con el id indicado
            CursoTutor cursoTutorItem = _cursoTutorRepo.GetById(id);

            //Se mappea la parte de CursoTutor a CursoTutorJ
            CursoTutorJ cursoTutorJItem = _mapper.Map<CursoTutorJ>(cursoTutorItem);

            //Si el CursoTutor existe
            if (cursoTutorJItem != null)
            {
                //Mappeo de CursoJ

                //Se obtiene el idCurso de CursoTutorJ
                int idCurso = cursoTutorJItem.idCurso;

                //Se obtiene el CursoJ especifico del CursoTutorJ
                CursoJ cursoJItem = _cursoJRepo.GetById(idCurso);

                //Se mappea el CursoJ al CursoTutorJ correspondiente
                _mapper.Map(cursoJItem, cursoTutorJItem);

                //Mappeo de TutorJ

                //Se obtiene el idCurso de CursoTutorJ
                int idTutor = cursoTutorJItem.idTutor;

                //Se obtiene el TutorJ especifico del idTutor
                TutorJ tutorJItem = _tutorJRepo.GetById(idTutor);

                //Se mappea el TutorJ al CursoTutorJ correspondiente
                _mapper.Map(tutorJItem, cursoTutorJItem);

                //Mappeo de CursoJ(nombreCurso)

                //Se debe mapear manualmente el nombre del curso despues por tener el mismo nombre con el nomobre del Estudiante
                cursoTutorJItem.nombreCurso = cursoJItem.nombre;
            }

            return cursoTutorJItem;
        }

        /*
         * Retorna una lista de CursoTutor de un unico Curso indicado.
         */
        public IEnumerable<CursoTutorJ> GetByCurso(int idCurso)
        {
            //Mappeo de CursoTutor

            //Se retorna una lista de todos los CursoTutor con el idCurso indicado
            IEnumerable<CursoTutor> cursoTutorItemsByCurso = _cursoTutorRepo.GetByCurso(idCurso);

            //Se mappea la parte de CursoTutor a CursoTutorJ
            IEnumerable<CursoTutorJ> cursoTutorJItemsByCurso = _mapper.Map<IEnumerable<CursoTutorJ>>(cursoTutorItemsByCurso);

            //Se itera atraves de todos los CursoTutor para mapearlos con su respectiva informacion restante de CursoTutorJ
            for (int i = 0; i < cursoTutorJItemsByCurso.Count(); i++)
            {
                //Mappeo de CursoJ

                //Se obtiene el CursoJ especifico del CursoTutorJ
                CursoJ cursoJItem = _cursoJRepo.GetById(idCurso);

                //Se mappea el CursoJ al CursoTutorJ correspondiente
                _mapper.Map(cursoJItem, cursoTutorJItemsByCurso.ElementAt(i));

                //Mappeo de TutorJ

                //Se obtiene el idCurso de CursoTutorJ
                int idTutor = cursoTutorJItemsByCurso.ElementAt(i).idTutor;

                //Se obtiene el TutorJ especifico del idTutor
                TutorJ tutorJItem = _tutorJRepo.GetById(idTutor);

                //Se mappea el TutorJ al CursoTutorJ correspondiente
                _mapper.Map(tutorJItem, cursoTutorJItemsByCurso.ElementAt(i));

                //Mappeo de CursoJ(nombreCurso)

                //Se debe mapear manualmente el nombre del curso despues por tener el mismo nombre con el nomobre del Estudiante
                cursoTutorJItemsByCurso.ElementAt(i).nombreCurso = cursoJItem.nombre;
            }

            return cursoTutorJItemsByCurso.ToList();
        }

        /*
         * Retorna una lista de CursoTutorJ de un unico Estudiante indicado.
         */
        public IEnumerable<CursoTutorJ> GetByEstudiante(int idEstudiante)
        {
            //Se debe verificar el idEstudiante, si no existe se cae el API

            //Se obtiene el idTutor del idEstudiante ingresado
            int idTutor = _tutorJRepo.GetId(idEstudiante);

            //Mappeo de CursoTutor

            //Se retorna una lista de todos los CursoTutor con el idTutor obtenido
            IEnumerable<CursoTutor> cursoTutorItemsByEstudiante = _cursoTutorRepo.GetByTutor(idTutor);

            //Se mappea la parte de CursoTutor a CursoTutorJ
            IEnumerable<CursoTutorJ> cursoTutorJItemsByEstudiante = _mapper.Map<IEnumerable<CursoTutorJ>>(cursoTutorItemsByEstudiante);

            //Se itera atraves de todos los CursoTutor para mapearlos con su respectiva informacion restante de CursoTutorJ
            for (int i = 0; i < cursoTutorJItemsByEstudiante.Count(); i++)
            {
                //Revisa que se cumpla el idTutor
                if (cursoTutorJItemsByEstudiante.ElementAt(i).idTutor == idTutor)
                {
                    //Mappeo de CursoJ

                    //Se obtiene el idCurso de CursoTutorJ
                    int idCurso = cursoTutorJItemsByEstudiante.ElementAt(i).idCurso;

                    //Se obtiene el CursoJ especifico del CursoTutorJ
                    CursoJ cursoJItem = _cursoJRepo.GetById(idCurso);

                    //Se mappea el CursoJ al CursoTutorJ correspondiente
                    _mapper.Map(cursoJItem, cursoTutorJItemsByEstudiante.ElementAt(i));

                    //Mappeo de TutorJ

                    //Se obtiene el TutorJ especifico del idTutor
                    TutorJ tutorJItem = _tutorJRepo.GetById(idTutor);

                    //Se mappea el TutorJ al CursoTutorJ correspondiente
                    _mapper.Map(tutorJItem, cursoTutorJItemsByEstudiante.ElementAt(i));

                    //Mappeo de CursoJ(nombreCurso)

                    //Se debe mapear manualmente el nombre del curso despues por tener el mismo nombre con el nomobre del Estudiante
                    cursoTutorJItemsByEstudiante.ElementAt(i).nombreCurso = cursoJItem.nombre;
                }
            }

            return cursoTutorJItemsByEstudiante.ToList();
        }

        /*
         * Retorna una lista de CursoTutorJ de un unico Tutor indicado.
         */
        public IEnumerable<CursoTutorJ> GetByTutor(int idTutor)
        {
            //Mappeo de CursoTutor

            //Se retorna una lista de todos los CursoTutor con el idTutor indicado
            IEnumerable<CursoTutor> cursoTutorItemsByTutor = _cursoTutorRepo.GetByTutor(idTutor);

            //Se mappea la parte de CursoTutor a CursoTutorJ
            IEnumerable<CursoTutorJ> cursoTutorJItemsByTutor = _mapper.Map<IEnumerable<CursoTutorJ>>(cursoTutorItemsByTutor);

            //Se itera atraves de todos los CursoTutor para mapearlos con su respectiva informacion restante de CursoTutorJ
            for (int i = 0; i < cursoTutorJItemsByTutor.Count(); i++)
            {
                //Mappeo de CursoJ

                //Se obtiene el idCurso de CursoTutorJ
                int idCurso = cursoTutorJItemsByTutor.ElementAt(i).idCurso;

                //Se obtiene el CursoJ especifico del CursoTutorJ
                CursoJ cursoJItem = _cursoJRepo.GetById(idCurso);

                //Se mappea el CursoJ al CursoTutorJ correspondiente
                _mapper.Map(cursoJItem, cursoTutorJItemsByTutor.ElementAt(i));

                //Mappeo de TutorJ

                //Se obtiene el TutorJ especifico del idTutor
                TutorJ tutorJItem = _tutorJRepo.GetById(idTutor);

                //Se mappea el TutorJ al CursoTutorJ correspondiente
                _mapper.Map(tutorJItem, cursoTutorJItemsByTutor.ElementAt(i));

                //Mappeo de CursoJ(nombreCurso)

                //Se debe mapear manualmente el nombre del curso despues por tener el mismo nombre con el nomobre del Estudiante
                cursoTutorJItemsByTutor.ElementAt(i).nombreCurso = cursoJItem.nombre;
            }

            return cursoTutorJItemsByTutor.ToList();
        }

        public void Create(CursoTutorJ cursoTutorJ)
        {
            throw new NotImplementedException();
        }

        public void Update(CursoTutorJ cursoTutorJ)
        {
            throw new NotImplementedException();
        }

        public void Delete(CursoTutorJ cursoTutorJ)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
