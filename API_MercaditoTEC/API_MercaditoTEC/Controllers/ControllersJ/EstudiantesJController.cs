using System.Collections.Generic;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ.EstudianteJ;
using API_MercaditoTEC.Models;
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
        private readonly IEstudianteRepo _estudianteRepository;

        public EstudiantesJController(IEstudianteJRepo repository, IMapper mapper, IDaticRepo daticRepository, IEstudianteRepo estudianteRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _daticRepository = daticRepository;
            _estudianteRepository = estudianteRepository;
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
         * con un id especifico de Estudiante.
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
         * GET api/estudiantesJ/Perfil/{id}
         * 
         * Obtiene los datos completos del Estudiante para mostrarlos en el Perfil
         * con un id especifico.
         */
        [Route("api/estudiantesJ/Perfil/{id}")]
        [HttpGet]
        public ActionResult<EstudianteJReadDto> GetPerfil(int id)
        {
            //Se trae de la base de datos el EstudianteJ con el id especificado
            var estudianteJItem = _repository.GetById(id);

            //Se verifica si este existe
            if (estudianteJItem != null)
            {
                return Ok(_mapper.Map<EstudianteJProfileDto>(estudianteJItem));
            }

            //Si no existe envia un NotFound
            return NotFound();
        }

        /*
         * GET api/estudiantesJ/Login
         * 
         * Obtiene los datos de login del Estudiante.
         */
        [Route("api/estudiantesJ/Login")]
        [HttpPost]
        public ActionResult<EstudianteJReadDto> LoginStudent(EstudianteJLoginDto estudianteJLoginDto)
        {
            //Se obtiene el correoInstitucional del usuario
            string correoInstitucional = estudianteJLoginDto.correoInstitucional;

            //Trae de la base de datos el correoInstitucional y la contrasena registrada en Datic
            var daticItem = _daticRepository.GetByCorreo(correoInstitucional);

            //Trae de la base de datos el idEstudiante registrado con el correo
            int idEstudiante = _repository.GetId(correoInstitucional);

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

                        /*
                         * Como se verifica exitosamente el login de estudiante
                         * Se agrega un value del idEstudiante que ha hecho login al response
                         */
                        response.setValue(idEstudiante);
                        return Ok(response);
                    }

                    /*
                    * Como la contrasena es incorrecta
                    * Se agrega un value de 0 al response
                    */
                    response.setValue(0);
                    return Ok(response);
                }

            }

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
            if (idEstudiantePorRegistrar != -1)
            {
                /*
                 * Como el estudiante ya esta registrado
                 * Se agrega un value de -1 al response
                 */
                response.setValue(-1);
                return Ok(response);
            }

            //Mappea el Estudiante por crear a un Modelo EstudianteJ
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

            /*
             * Como se registro el estudiante exitosamente
             * Se agrega un value del idEstudiante que ha hecho login al response
             */
            response.setValue(idEstudianteJ);
            return Ok(response);
        }


        /*
         * PUT api/estudiantesJ/Guia
         * 
         * Confirma con el API para que se guarde que el estudiante ya vio la guia en el cliente especifico.
         */
        [Route("api/estudiantesJ/Guia")]
        [HttpPut]
        public ActionResult<EstudianteJReadDto> GuideConfirmation(EstudianteJGuideDto estudianteJGuideDto)
        {
            //Se obtiene el Estudiante, con id especifico, del repositorio
            Estudiante estudiante = _estudianteRepository.GetById(estudianteJGuideDto.idEstudiante);

            //Se crea la respuesta por enviar
            Response response = new Response("EstudiantesJ", "api/estudiantesJ/Guia", "HttpPost", "Guia Estudiante");

            //Se verifica si el estudiante existe
            if (estudiante == null)
            {
                /*
                 * Como el estudiante por actualizar no existe
                 * Se agrega un value de -1 al response
                 */
                response.setValue(-1);
                return Ok(response);
            }
            else
            {
                //No se esta verificando si ya tiene haIngresado = true

                //Se verifica de donde viene la confirmacion de la guia
                if (estudianteJGuideDto.cliente == "Web")
                {
                    estudiante.haIngresadoWeb = true;
                }
                else if (estudianteJGuideDto.cliente == "App")
                {
                    estudiante.haIngresadoApp = true;
                }
                else
                {
                    /*
                    * Como no viene especificado el cliente
                    * Se agrega un value de 0 al response
                    */
                    response.setValue(0);
                    return Ok(response);
                }

                //Guarda los cambios en la base de datos
                _estudianteRepository.SaveChanges();
            }

            /*
             * Como se actualiza exitosamente al Estudiante
             * Se agrega un value de 1 al response
             */
            response.setValue(1);
            return Ok(response);
        }


        /*
         * 
         */
        [Route("api/estudiantesJ/{id}")]
        [HttpPut]
        public ActionResult Update(int id, EstudianteJUpdateDto estudianteJUpdateDto)
        {

            //FALTA IMPLEMENTAR ESTE Update

            //ESTO ES UNA PRUEBA PARA "GuideConfirmation"

            //Se obtiene el Estudiante, con id especifico, del repositorio
            Estudiante estudianteModelFromRepo = _estudianteRepository.GetById(id);
            //Se verifica que exista el Estudiante obtenido con el id especifico
            if (estudianteModelFromRepo == null)
            {
                return NotFound();
            }

            estudianteModelFromRepo.haIngresadoWeb = estudianteJUpdateDto.haIngresadoWeb;

            _estudianteRepository.SaveChanges();

            return Ok(estudianteModelFromRepo);

        }

    }
}
