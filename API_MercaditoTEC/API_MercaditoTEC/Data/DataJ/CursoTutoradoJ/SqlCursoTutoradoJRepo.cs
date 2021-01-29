using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data.DataJ
{
    public class SqlCursoTutoradoJRepo : ICursoTutoradoJRepo
    {
        private readonly MercaditoTECContext _context;
        private readonly ICursoTutoradoRepo _cursoTutoradoRepo;
        private readonly ITutoradoJRepo _tutoradoJRepo;
        private readonly ICursoTutorJRepo _cursoTutorJRepo;
        private readonly IMapper _mapper;

        public SqlCursoTutoradoJRepo(MercaditoTECContext context, ICursoTutoradoRepo cursoTutoradoRepo, ITutoradoJRepo tutoradoJRepo,
            ICursoTutorJRepo cursoTutorJRepo, IMapper mapper)
        {
            _context = context;
            _cursoTutoradoRepo = cursoTutoradoRepo;
            _tutoradoJRepo = tutoradoJRepo;
            _cursoTutorJRepo = cursoTutorJRepo;
            _mapper = mapper;
        }

        /*
         * Retorna todos los CursoTutoradoJ con la informacion de CursoTutorado y ... .
         */
        public IEnumerable<CursoTutoradoJ> GetAll()
        {
            //Mappeo de CursoTutorado

            //Se retorna una lista de todas los CursoTutorado
            IEnumerable<CursoTutorado> cursoTutoradoItems = _cursoTutoradoRepo.GetAll();

            //Se mappea la parte de CursoTutorado al CursoTutoradoJ
            IEnumerable<CursoTutoradoJ> cursoTutoradoJItems = _mapper.Map<IEnumerable<CursoTutoradoJ>>(cursoTutoradoItems);

            //Se itera atraves de todos los CursoTutorado para mapearlos con su respectiva informacion restante de CursoTutoradoJ
            for (int i = 0; i < cursoTutoradoJItems.Count(); i++)
            {
                //Mappeo de TutoradoJ

                //Se obtiene el idTutorado del CursoTutoradoJ
                int idTutorado = cursoTutoradoJItems.ElementAt(i).idTutorado;

                //Se obtiene el TutoradoJ especifico del CursoTutorado
                TutoradoJ tutoradoJItem = _tutoradoJRepo.GetById(idTutorado);

                //Se mappea el TutoradoJ al CursoTutorado a mano por ser nombres diferentes
                cursoTutoradoJItems.ElementAt(i).nombreTutorado = tutoradoJItem.nombre + ' ' + tutoradoJItem.apellidos;

                //Mappeo del CursoTutorJ

                //Se obtiene el idCursoTutor del CursoTutoradoJ
                int idCursoTutor = cursoTutoradoJItems.ElementAt(i).idCursoTutor;

                //Se obtiene el CursoTutorJ especifico del CursoTutoradoJ
                CursoTutorJ cursoTutorJItem = _cursoTutorJRepo.GetById(idCursoTutor);

                //Se mappea el CursoTutorJ al CursoTutoradoJ correspondiente
                _mapper.Map(cursoTutorJItem, cursoTutoradoJItems.ElementAt(i));

                //Se mappea el nombre del Tutor del CursoTutorJ al CursoTutoradoJ a mano por ser nombres diferentes
                cursoTutoradoJItems.ElementAt(i).nombreTutor = cursoTutorJItem.nombre + ' ' + cursoTutorJItem.apellidos;
            }

            return cursoTutoradoJItems.ToList();
        }

        /*
         * Retorna una CursoTutoradoJ especifico por su idCursoTutorado.
         */
        public CursoTutoradoJ GetById(int id)
        {
            //Mappeo de CursoTutorado

            //Se retorna un CursoTutorado en especifico por su idCursoTutorado
            CursoTutorado cursoTutoradoItem = _cursoTutoradoRepo.GetById(id);

            //Se mappea la parte de CursoTutorado al CursoTutoradoJ
            CursoTutoradoJ cursoTutoradoJItem = _mapper.Map<CursoTutoradoJ>(cursoTutoradoItem);

            //Si el CursoTutorado existe
            if (cursoTutoradoJItem != null)
            {
                //Mappeo de TutoradoJ

                //Se obtiene el idTutorado del CursoTutoradoJ
                int idTutorado = cursoTutoradoJItem.idTutorado;

                //Se obtiene el TutoradoJ especifico del CursoTutorado
                TutoradoJ tutoradoJItem = _tutoradoJRepo.GetById(idTutorado);

                //Se mappea el TutoradoJ al CursoTutorado a mano por ser nombres diferentes
                cursoTutoradoJItem.nombreTutorado = tutoradoJItem.nombre + ' ' + tutoradoJItem.apellidos;

                //Mappeo del CursoTutorJ

                //Se obtiene el idCursoTutor del CursoTutoradoJ
                int idCursoTutor = cursoTutoradoJItem.idCursoTutor;

                //Se obtiene el CursoTutorJ especifico del CursoTutoradoJ
                CursoTutorJ cursoTutorJItem = _cursoTutorJRepo.GetById(idCursoTutor);

                //Se mappea el CursoTutorJ al CursoTutoradoJ correspondiente
                _mapper.Map(cursoTutorJItem, cursoTutoradoJItem);

                //Se mappea el nombre del Tutor del CursoTutorJ al CursoTutoradoJ a mano por ser nombres diferentes
                cursoTutoradoJItem.nombreTutor = cursoTutorJItem.nombre + ' ' + cursoTutorJItem.apellidos;
            }

            return cursoTutoradoJItem;
        }

        /*
         * Retorna una lista de CursoTutoradoJ del Tutorado especificado.
         */
        public IEnumerable<CursoTutoradoJ> GetByTutorado(int idTutorado)
        {
            //Mappeo de CursoTutorado

            //Se retorna una lista de todos los CursoTutorado de un Tutorado en especifico
            IEnumerable<CursoTutorado> cursoTutoradoItemsByTutorado = _cursoTutoradoRepo.GetByTutorado(idTutorado);

            //Se mappea la parte de CursoTutorado al CursoTutoradoJ
            IEnumerable<CursoTutoradoJ> cursoTutoradoJItemsByTutorado = _mapper.Map<IEnumerable<CursoTutoradoJ>>(cursoTutoradoItemsByTutorado);

            //Se itera atraves de todos los CursoTutorado para mapearlos con su respectiva informacion restante de CursoTutoradoJ
            for (int i = 0; i < cursoTutoradoJItemsByTutorado.Count(); i++)
            {
                //Mappeo de TutoradoJ

                //idTutorado

                //Se obtiene el TutoradoJ especifico del CursoTutorado
                TutoradoJ tutoradoJItem = _tutoradoJRepo.GetById(idTutorado);

                //Se mappea el TutoradoJ al CursoTutorado a mano por ser nombres diferentes
                cursoTutoradoJItemsByTutorado.ElementAt(i).nombreTutorado = tutoradoJItem.nombre + ' ' + tutoradoJItem.apellidos;

                //Mappeo del CursoTutorJ

                //Se obtiene el idCursoTutor del CursoTutoradoJ
                int idCursoTutor = cursoTutoradoJItemsByTutorado.ElementAt(i).idCursoTutor;

                //Se obtiene el CursoTutorJ especifico del CursoTutoradoJ
                CursoTutorJ cursoTutorJItem = _cursoTutorJRepo.GetById(idCursoTutor);

                //Se mappea el CursoTutorJ al CursoTutoradoJ correspondiente
                _mapper.Map(cursoTutorJItem, cursoTutoradoJItemsByTutorado.ElementAt(i));

                //Se mappea el nombre del Tutor del CursoTutorJ al CursoTutoradoJ a mano por ser nombres diferentes
                cursoTutoradoJItemsByTutorado.ElementAt(i).nombreTutor = cursoTutorJItem.nombre + ' ' + cursoTutorJItem.apellidos;
            }

            return cursoTutoradoJItemsByTutorado.ToList();
        }

        public IEnumerable<CursoTutoradoJ> GetByCursoTutor(int idCursoTutor)
        {
            throw new NotImplementedException();
        }

        public int GetId(int idTutorado, int idCursoTutor)
        {
            throw new NotImplementedException();
        }

        public void Create(CursoTutoradoJ cursoTutoradoJ)
        {
            throw new NotImplementedException();
        }

        public void Update(CursoTutoradoJ cursoTutoradoJ)
        {
            throw new NotImplementedException();
        }

        public void Delete(CursoTutoradoJ cursoTutoradoJ)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

    }
}
