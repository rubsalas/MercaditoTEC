using System.Collections.Generic;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ.EstudianteJ;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers.ControllersJ
{
    //[Route("api/estudiantesJ")]
    [ApiController]
    public class EstudiantesJController : ControllerBase
    {
        private readonly IEstudianteJRepo _repository;
        private readonly IMapper _mapper;
        private readonly IDaticRepo _daticRepository;

        public EstudiantesJController(IEstudianteJRepo repository, IMapper mapper, IDaticRepo daticRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _daticRepository = daticRepository;
        }

        /*
         * GET api/estudiantesJ
         * 
         * Obtiene todos los datos de todas las filas de las tablas Persona y Estudiante.
         */
        [Route("api/estudiantesJ")]
        [HttpGet]
        public ActionResult<IEnumerable<EstudianteJReadDto>> GetAll()
        {
            var estudianteJItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<EstudianteJReadDto>>(estudianteJItems));
        }

        /*
         * GET api/estudiantesJ/{id}
         * 
         * Obtiene los datos de una sola fila de las tablas Persona y Estudiante,
         * con un id especifico.
         */
        [Route("api/estudiantesJ/{id}")]
        [HttpGet]
        public ActionResult<EstudianteJReadDto> GetById(int id)
        {
            //Se trae de la base de datos el EstudianteJ con el id especificado
            var estudianteJItem = _repository.GetById(id);

            //Se verifica si este existe
            if (estudianteJItem != null)
            {
                return Ok(_mapper.Map<EstudianteJReadDto>(estudianteJItem));
            }

            //Si no existe envia un NotFound
            return NotFound();
        }

        /*
         * GET api/estudiantesLogin
         * 
         * Obtiene los datos de login del Estudiante.
         */
        [Route("api/estudiantesJ/Login")]
        [HttpGet]
        public ActionResult<EstudianteJReadDto> GetLogin(EstudianteJLoginDto estudianteJLoginDto)
        {
            //Se obtiene el correoInstitucional proveido
            string correoInstitucional = estudianteJLoginDto.correoInstitucional;

            //Trae de la base de datos el correoInstitucional y la contrasena registrada en Datic
            var daticItem = _daticRepository.GetByCorreo(correoInstitucional);

            //Trae de la base de datos el idEstudiante registrado con el correo
            int idEstudiante = _repository.GetId(correoInstitucional);

            //Se verifica que exista el correo del Estudiante en la tabla de Datic
            if (daticItem != null)
            {
                
                //Se verifica que el estudiante este registrado en el sistema
                if (idEstudiante != -1)
                {
                    //Se trae de la base de datos el EstudianteJ con el id especificado
                    var estudianteJItem = _repository.GetById(idEstudiante);

                    //Se verifica que la contrasena es correcta
                    if (estudianteJLoginDto.contrasena == daticItem.contrasena)
                    {
                        //Retorna un EstudianteGuideJDto con la informacion de si ha ingresado a las plataformas
                        return Ok(_mapper.Map<EstudianteJGuideDto>(estudianteJItem));
                    }

                    //Si la contrasena esta mal
                    return Ok(false);
                }

                //Si no esta registrado envia un NotFound true
                return NotFound(true);

            }

            //Si no existe envia un NotFound false
            return NotFound(false);
        }

        /*
         * POST api/estudiantesJ
         * 
         * Crea una nueva Persona y un Estudiante con el correo institucional ya verificado en Datic.
         */
        [Route("api/estudiantesJ")]
        [HttpPost]
        public ActionResult<EstudianteJReadDto> Create(EstudianteJCreateDto estudianteJCreateDto)
        {
            //Mappea el Estudiante creado a un Modelo EstudianteJ
            EstudianteJ estudianteJModel = _mapper.Map<EstudianteJ>(estudianteJCreateDto);
            //Crea el EstudianteJ nuevo en la base de datos
            _repository.Create(estudianteJModel);
            //Guarda los cambios en la base de datos
            _repository.SaveChanges(); //No implementado para EstudianteJ

            //Mappea el Modelo del EstudianteJ a un EstudianteJRead para retornarlo
            var estudianteJReadDto = _mapper.Map<EstudianteJReadDto>(estudianteJModel);

            //Se obtiene el idEstudiante recien creado
            int idEstudianteJ = _repository.GetId(estudianteJCreateDto.correoInstitucional);

            //Se le ingresa el idEstudiante al EstudianteJRead
            estudianteJReadDto.idEstudiante = idEstudianteJ;

            //Retorna un ActionResult 201 Created al hacer el Post, con el EstudianteJRead
            return Ok(estudianteJReadDto);
        }
    }
}
