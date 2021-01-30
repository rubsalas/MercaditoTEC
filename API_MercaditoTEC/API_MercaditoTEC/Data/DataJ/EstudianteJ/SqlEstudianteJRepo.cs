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
        private readonly IDaticRepo _daticRepository;
        private readonly ITutorRepo _tutorRepo;
        private readonly IVendedorRepo _vendedorRepo;
        private readonly IMapper _mapper;

        public SqlEstudianteJRepo(MercaditoTECContext context, IPersonaRepo personaRepository, IEstudianteRepo estudianteRepository, 
                                  IDaticRepo daticRepository, ITutorRepo tutorRepo, IVendedorRepo vendedorRepo, IMapper mapper)
        {
            _context = context;
            _personaRepository = personaRepository;
            _estudianteRepository = estudianteRepository;
            _daticRepository = daticRepository;
            _tutorRepo = tutorRepo;
            _vendedorRepo = vendedorRepo;
            _mapper = mapper;
        }
        
        /*
         * Retorna todos los Estudiantes con la informacion de Persona, Estudiante y Datic.
         */
        public IEnumerable<EstudianteJ> GetAll()
        {
            //Mappeo de Estudiantes

            //Se retorna una lista de todos los Estudiantes
            var estudianteItems = _estudianteRepository.GetAll();

            //Se mappea la parte de Estudiante al EstudianteJ
            IEnumerable<EstudianteJ> estudianteJItems = _mapper.Map<IEnumerable<EstudianteJ>>(estudianteItems);

            //Se itera atraves de todos los estudiantes para mapearlos con su respectiva informacion de la Persona y contrasena de Datic
            for (int i = 0; i < estudianteItems.Count(); i++)
            {
                //Se obtiene el idEstudiante
                int idEstudianteI = estudianteItems.ElementAt(i).idEstudiante;

                //Mappeo de Persona

                //Se obtiene el idPersona del Estudiante
                int idPersonaI = estudianteItems.ElementAt(i).idPersona;

                //Se obtiene la Persona especifica del Estudiante
                Persona personaItem = _personaRepository.GetById(idPersonaI);

                //Se mappea la Persona al EstudianteJ correspondiente
                _mapper.Map(personaItem, estudianteJItems.ElementAt(i));

                /*
                //Mappeo de Datic

                //Se obtiene el correoInstitucional del Estudiante
                string correoInstitucionalI = estudianteItems.ElementAt(i).correoInstitucional;

                //Se obtiene la informacion de Datic especifica del Estudiante
                Datic daticItem = _daticRepository.GetByCorreo(correoInstitucionalI);

                //Se mappea la contrasena de Datic al EstudianteJ correspondiente
                _mapper.Map(daticItem, estudianteJItems.ElementAt(i));
                */

                //Mappeo Tutor

                //Se obtiene el Tutor
                Tutor tutorItem = _tutorRepo.GetByEstudiante(idEstudianteI);

                //Se mapper el Tutor al EstudianteJ
                _mapper.Map(tutorItem, estudianteJItems.ElementAt(i));

                //Mappeo de Aplicaciones

                // ---------------------

                //Mappeo de Vendedor

                //Se obtiene el Vendedor
                Vendedor vendedorItem = _vendedorRepo.GetByEstudiante(idEstudianteI);

                //Se mappea el Vendedor al EstudianteJ
                _mapper.Map(vendedorItem, estudianteJItems.ElementAt(i));
            }

            return estudianteJItems.ToList();
        }

        /*
         * Retorna un Estudiante con la informacion de Persona y Estudiante.
         */
        public EstudianteJ GetById(int id)
        {
            //Mappeo de Estudiante

            //Se retorna un Estudiante especifico
            Estudiante estudianteItem = _context.Estudiante.FirstOrDefault(e => e.idEstudiante == id);

            //Se mappea la parte de Estudiante al EstudianteJ
            EstudianteJ estudianteJItem = _mapper.Map<EstudianteJ>(estudianteItem);

            //Si el Estudiante existe
            if (estudianteJItem != null)
            {
                //Mappeo de Persona

                //Se obtiene el idPersona del Estudiante
                int idPersona = estudianteItem.idPersona;

                //Se obtiene la Persona especifica del Estudiante
                Persona personaItem = _personaRepository.GetById(idPersona);

                //Se mappea la Persona al EstudianteJ
                _mapper.Map(personaItem, estudianteJItem);

                //Mappeo Tutor

                //Se obtiene el Tutor
                Tutor tutorItem = _tutorRepo.GetByEstudiante(id);

                //Se mapper el Tutor al EstudianteJ
                _mapper.Map(tutorItem, estudianteJItem);

                //Mappeo de Aplicaciones

                // ---------------------

                //Mappeo de Vendedor

                //Se obtiene el Vendedor
                Vendedor vendedorItem = _vendedorRepo.GetByEstudiante(id);

                //Se mappea el Vendedor al EstudianteJ
                _mapper.Map(vendedorItem, estudianteJItem);
            }

            return estudianteJItem;
        }

        /*
         * Retorna el idEstudiante de un EstudianteJ especifico.
         */
        public int GetId(string correoInstitucional)
        {
            //Se retorna el idEstudiante del EstudianteJ usando el repositorio de Estudiante
            return _estudianteRepository.GetId(correoInstitucional);
        }

        /*
         * Ingresa a la base de datos una nueva Persona y Estudiante.
         */
        public void Create(EstudianteJ estudianteJ)
        {
            //Se verifica si el EstudianteJ ingresado no es nulo
            if (estudianteJ == null)
            {
                throw new ArgumentNullException(nameof(estudianteJ));
            }

            //Mappea el EstudianteJ obtenido a un Modelo Persona
            var personaModel = _mapper.Map<Persona>(estudianteJ);

            //Crea la Persona nueva en la base de datos
            _personaRepository.Create(personaModel);
            //Guarda los cambios en la tabla Persona en la base de datos
            _personaRepository.SaveChanges();

            //Mappea el EstudianteJ obtenido a un Modelo Estudiante
            Estudiante estudianteModel = _mapper.Map<Estudiante>(estudianteJ);

            //Se agrega el idPersona de la persona recien creada al Modelo Estudiante
            estudianteModel.idPersona = _personaRepository.GetId(personaModel.nombre, personaModel.apellidos, personaModel.telefono);

            //Se crea el Estudiante nuevo en la base de datos
            _estudianteRepository.Create(estudianteModel);
            //Se guardan los cambios en la tabla Estudiante en la base de datos
            _estudianteRepository.SaveChanges();  
        }

        public void Update(EstudianteJ estudianteJ)
        {
            //throw new NotImplementedException();
        }

        public void Delete(EstudianteJ estudianteJ)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            //throw new NotImplementedException();
            return _estudianteRepository.SaveChanges();
        }
    }
}
