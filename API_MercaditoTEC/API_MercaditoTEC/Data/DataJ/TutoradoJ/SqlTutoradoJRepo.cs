using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data.DataJ
{
    public class SqlTutoradoJRepo : ITutoradoJRepo
    {
        private readonly MercaditoTECContext _context;
        private readonly IEstudianteJRepo _estudianteJRepo;
        private readonly IMapper _mapper;

        public SqlTutoradoJRepo(MercaditoTECContext context, IEstudianteJRepo estudianteJRepo, IMapper mapper)
        {
            _context = context;
            _estudianteJRepo = estudianteJRepo;
            _mapper = mapper;
        }

        public IEnumerable<TutoradoJ> GetAll()
        {
            throw new NotImplementedException();
        }

        /*
         * Retorna un CompradorJ con la informacion de Tutorado y EstudianteJ.
         */
        public TutoradoJ GetById(int id)
        {
            //Mappeo de Tutorado

            //Se retorna un Tutorado especifico
            Tutorado tutoradoItem = _context.Tutorado.FirstOrDefault(t => t.idTutorado == id);

            //Se mappea la parte de Tutorado al TutoradoJ
            TutoradoJ tutoradoJItem = _mapper.Map<TutoradoJ>(tutoradoItem);

            //Si el Tutorado existe
            if (tutoradoJItem != null)
            {
                //Mappeo de EstudianteJ

                //Se obtiene el idEstudiante del TutoradoJ
                int idEstudianteJ = tutoradoJItem.idEstudiante;

                //Se obtiene el EstudianteJ especifico del idEstudiante
                EstudianteJ estudianteJItem = _estudianteJRepo.GetById(idEstudianteJ);

                //Se mappea la EstudianteJ al TutoradoJ
                _mapper.Map(estudianteJItem, tutoradoJItem);
            }

            return tutoradoJItem;
        }

        public TutoradoJ GetByEstudiante(int idEstudiante)
        {
            throw new NotImplementedException();
        }

        public int GetId(int idEstudiante)
        {
            throw new NotImplementedException();
        }

        public void Create(TutoradoJ tutoradoJ)
        {
            throw new NotImplementedException();
        }

        public void Update(TutoradoJ tutoradoJ)
        {
            throw new NotImplementedException();
        }

        public void Delete(TutoradoJ tutoradoJ)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
