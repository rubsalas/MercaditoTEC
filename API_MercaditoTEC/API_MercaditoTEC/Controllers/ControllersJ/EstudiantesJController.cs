using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ.EstudianteJ;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers.ControllersJ
{
    [Route("api/estudiantesJ")]
    [ApiController]
    public class EstudiantesJController : ControllerBase
    {
        private readonly IEstudianteJRepo _repository;
        private readonly IMapper _mapper;

        public EstudiantesJController(IEstudianteJRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/estudiantesJ
         * 
         * Obtiene todos los datos de todas las filas de las tablas Persona y Estudiante.
         */
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
        [HttpGet("{id}", Name = "GetByIdEstudianteJ")]
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
         * POST api/estudiantesJ
         * 
         * Crea una nueva Persona y un Estudiante con el correo institucional ya verificado en Datic.
         */
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
