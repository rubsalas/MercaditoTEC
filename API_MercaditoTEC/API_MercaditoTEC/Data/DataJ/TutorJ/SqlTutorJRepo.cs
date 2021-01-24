using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data.DataJ
{
    public class SqlTutorJRepo : ITutorJRepo
    {
        private readonly MercaditoTECContext _context;
        private readonly ITutorRepo _tutorRepo;
        private readonly IPersonaRepo _personaRepo;
        private readonly IEstudianteRepo _estudianteRepo;
        private readonly IMapper _mapper;

        public SqlTutorJRepo(MercaditoTECContext context, ITutorRepo tutorRepo, IPersonaRepo personaRepo, IEstudianteRepo estudianteRepo, IMapper mapper)
        {
            _context = context;
            _tutorRepo = tutorRepo;
            _personaRepo = personaRepo;
            _estudianteRepo = estudianteRepo;
            _mapper = mapper;
        }

        /*
         * Retorna todos los TutoresJ con la informacion de Tutor y EstudianteJ
         */
        public IEnumerable<TutorJ> GetAll()
        {
            //Mappeo de Tutor

            //Se retorna una lista de todos los Tutores
            IEnumerable<Tutor> tutorItems = _tutorRepo.GetAll();

            //Se mappea la parte de Tutor a TutorJ
            IEnumerable<TutorJ> tutorJItems = _mapper.Map<IEnumerable<TutorJ>>(tutorItems);

            //Se itera atraves de todos los Tutores para mapearlos con su respectiva informacion restante de TutorJ
            for (int i = 0; i < tutorJItems.Count(); i++)
            {
                //Mappeo de EstudianteJ
                
                //Se obtiene el idEstudiante de TutorJ
                int idEstudiante = tutorJItems.ElementAt(i).idEstudiante;

                //Se obtiene el EstudianteJ especifico del TutorJ
                Estudiante estudianteItem = _estudianteRepo.GetById(idEstudiante);

                //Se mappea el EstudianteJ al TutorJ correspondiente
                _mapper.Map(estudianteItem, tutorJItems.ElementAt(i));

                //Mappeo de Persona

                //Se obtiene el idPersona del Estudiante
                int idPersonaI = estudianteItem.idPersona;

                //Se obtiene la Persona especifica del Estudiante
                Persona personaItem = _personaRepo.GetById(idPersonaI);

                //Se mappea la Persona al TutorJ correspondiente
                _mapper.Map(personaItem, tutorJItems.ElementAt(i));

            }

            return tutorJItems.ToList();
        }

        public TutorJ GetById(int id)
        {
            //Mappeo de Tutor

            //Se retorna un Tutor especifico
            Tutor tutorItem = _tutorRepo.GetById(id);

            //Se mappea la parte de Tutor a TutorJ
            TutorJ tutorJItem = _mapper.Map<TutorJ>(tutorItem);

            //Si el Tutor existe
            if (tutorJItem != null)
            {
                //Mappeo de EstudianteJ

                //Se obtiene el idEstudiante del EstudianteJ
                int idEstudiante = tutorJItem.idEstudiante;

                //Se obtiene el EstudianteJ especifico del idEstudiante
                Estudiante estudianteItem = _estudianteRepo.GetById(idEstudiante);

                //Se mappea el EstudianteJ al TutorJ
                _mapper.Map(estudianteItem, tutorJItem);

                //Mappeo de Persona

                //Se obtiene el idPersona del Estudiante
                int idPersonaI = estudianteItem.idPersona;

                //Se obtiene la Persona especifica del Estudiante
                Persona personaItem = _personaRepo.GetById(idPersonaI);

                //Se mappea la Persona al TutorJ correspondiente
                _mapper.Map(personaItem, tutorJItem);

            }

            return tutorJItem;

        }

        public TutorJ GetByEstudiante(int idEstudiante)
        {
            throw new NotImplementedException();
        }

        /*
         * Retorna el idTutor de un TutorJ especifico.
         */
        public int GetId(int idEstudiante)
        {
            return _tutorRepo.GetId(idEstudiante);
        }

        public void Create(TutorJ tutorJ)
        {
            throw new NotImplementedException();
        }

        public void Update(TutorJ tutorJ)
        {
            throw new NotImplementedException();
        }

        public void Delete(TutorJ tutorJ)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
