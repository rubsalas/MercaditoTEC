using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data.DataJ
{
    public class SqlEstudianteJRepo : IEstudianteJRepo
    {
        private readonly MercaditoTECContext _context;
        private readonly IPersonaRepo _personaRepository;
        private readonly IEstudianteRepo _estudianteRepository;
        private readonly IMapper _mapper;

        public SqlEstudianteJRepo(MercaditoTECContext context, IPersonaRepo personaRepository, IEstudianteRepo estudianteRepository, IMapper mapper)
        {
            _context = context;
            _personaRepository = personaRepository;
            _estudianteRepository = estudianteRepository;
            _mapper = mapper;
        }
        
        public IEnumerable<EstudianteJ> GetAll()
        {
            //Se retorna una lista de todos los Estudiantes
            var estudianteItems = _estudianteRepository.GetAll();

            //Se mappea la parte de Estudiante al EstudianteJ
            IEnumerable<EstudianteJ> estudianteJItems = _mapper.Map<IEnumerable<EstudianteJ>>(estudianteItems);

            //Se itera atraves de todos los estudiantes para mapearlos con su respectiva informacion de la Persona
            for (int i = 0; i < estudianteItems.Count(); i++)
            {
                //Se obtiene el idPersona del Estudiante
                int idPersonaI = estudianteItems.ElementAt(i).idPersona;

                //Se obtiene la Persona especifica del Estudiante
                Persona personaItem = _personaRepository.GetById(idPersonaI);

                //Se mappea al EstudianteJ correspondiente
                _mapper.Map(personaItem, estudianteJItems.ElementAt(i));
            }

            return estudianteJItems.ToList();
        }

        public EstudianteJ GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(EstudianteJ estudianteJ)
        {
            throw new NotImplementedException();
        }
        public void Update(EstudianteJ estudianteJ)
        {
            throw new NotImplementedException();
        }

        public void Delete(EstudianteJ estudianteJ)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
