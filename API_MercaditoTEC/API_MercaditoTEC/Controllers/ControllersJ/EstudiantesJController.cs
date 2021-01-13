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
        [HttpPost]
        public ActionResult<EstudianteJReadDto> LoginStudent(EstudianteJLoginDto estudianteJLoginDto)
        {
            //Se obtiene el correoInstitucional proveido
            string correoInstitucional = estudianteJLoginDto.correoInstitucional;

            //Trae de la base de datos el correoInstitucional y la contrasena registrada en Datic
            var daticItem = _daticRepository.GetByCorreo(correoInstitucional);

            //Trae de la base de datos el idEstudiante registrado con el correo
            int idEstudiante = _repository.GetId(correoInstitucional);

            //NO - Contendra el EstudianteJ por enviar como respuesta si hay un error
            EstudianteJ estudianteJItemError = new EstudianteJ();

            //Se crea la respuesta por enviar
            Response response = new Response("EstudiantesJ", "api/estudiantesJ/Login", "HttpPost", "Login Estudiante");

            //Se verifica que exista el correo del Estudiante en la tabla de Datic
            if (daticItem != null)
            {
                
                //Se verifica que el estudiante este registrado en el sistema de MercaditoTEC
                if (idEstudiante != -1)
                {

                    //Se verifica que la contrasena es correcta
                    if (estudianteJLoginDto.contrasena == daticItem.contrasena)
                    {
                        //Se trae de la base de datos el EstudianteJ con el id especificado
                        //var estudianteJItem = _repository.GetById(idEstudiante);

                        //Retorna un EstudianteGuideJDto con la informacion de si ha ingresado a las plataformas
                        //return Ok(_mapper.Map<EstudianteJGuideDto>(estudianteJItem));

                        /*
                         * Como se verifica exitosamente el login de estudiante
                         * Se agrega un value del idEstudiante que ha hecho login al response
                         */
                        response.setValue(idEstudiante);
                        return Ok(response);
                    }

                    //Si la contrasena esta mal

                    //NO - Se ingresa como idEstudiante un 0
                    //estudianteJItemError.idEstudiante = 0;

                    //NO - Se convierte a un estudianteJGuideDto para enviarse como JSON
                    //return Ok(_mapper.Map<EstudianteJGuideDto>(estudianteJItemError));

                    /*
                    * Como la contrasena es incorrecta
                    * Se agrega un value de 0 al response
                    */
                    response.setValue(0);
                    return Ok(response);
                }

                //Si no esta registrado, pero si existe en Datic, envia un NotFound true
                //return NotFound(true);

            }

            //Si no existe envia un NotFound false

            //NO - Se ingresa como idEstudiante un -1
            //estudianteJItemError.idEstudiante = -1;

            //NO - Se convierte a un estudianteJGuideDto para enviarse como JSON
            //return Ok(_mapper.Map<EstudianteJGuideDto>(estudianteJItemError));

            /*
             * Como no existe en al tabla de Datic
             * Se agrega un value de -1 al response
             */
            response.setValue(-1);
            return Ok(response);
        }

        /*
         * POST api/estudiantesJ
         * 
         * Crea una nueva Persona y un Estudiante con el correo institucional ya verificado en Datic.
         */
        [Route("api/estudiantesJ/Registro")]
        [HttpPost]
        public ActionResult<EstudianteJReadDto> RegisterStudent(EstudianteJCreateDto estudianteJCreateDto)
        {
            //Se crea la respuesta por enviar
            Response response = new Response("EstudiantesJ", "api/estudiantesJ/Registro", "HttpPost", "Registro Estudiante");

            //Se intentara obtener un idEstudiante para verificar si ya existe
            int idEstudiantePorRegistrar = _repository.GetId(estudianteJCreateDto.correoInstitucional);

            //Se debe revisar que el Estudiante no este ya registrado
            if (idEstudiantePorRegistrar == -1)
            {
                /*
                 * Como el estudiante ya esta registrado
                 * Se agrega un value de -1 al response
                 */
                response.setValue(-1);
                return Ok(response);
            }

            //Mappea el Estudiante creado a un Modelo EstudianteJ
            EstudianteJ estudianteJModel = _mapper.Map<EstudianteJ>(estudianteJCreateDto);
            //Crea el EstudianteJ nuevo en la base de datos
            _repository.Create(estudianteJModel);
            //Guarda los cambios en la base de datos
            _repository.SaveChanges(); //No implementado para EstudianteJ

            //Se obtiene el idEstudiante recien creado
            int idEstudianteJ = _repository.GetId(estudianteJCreateDto.correoInstitucional);

            //Se revisa si se completo el registro
            if (idEstudianteJ == -1)
            {
                /*
                 * Como no se registro el estudiante
                 * Se agrega un value de 0 al response
                 */
                response.setValue(0);
                return Ok(response);
            }

            //Se obtiene el estudiante de la base de datos
            //EstudianteJ estudianteRegistrado = _repository.GetById(idEstudianteJ);

            //Mappea el Modelo del EstudianteJ a un EstudianteJRead para retornarlo
            //var estudianteJReadDto = _mapper.Map<EstudianteJReadDto>(estudianteRegistrado);

            //Retorna un ActionResult 201 Created al hacer el Post, con el EstudianteJRead
            //return Ok(estudianteJReadDto);

            /*
             * Como se registro el estudiante exitosamente
             * Se agrega un value del idEstudiante que ha hecho login al response
             */
            response.setValue(idEstudianteJ);
            return Ok(response);
        }
    }
}
