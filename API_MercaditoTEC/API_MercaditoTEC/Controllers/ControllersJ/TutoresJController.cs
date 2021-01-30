using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ.TutorJ;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_MercaditoTEC.Controllers.ControllersJ
{
    //[Route("api/tutoresJ")]
    [ApiController]
    public class TutoresJController : ControllerBase
    {
        private readonly ITutorJRepo _repository;
        private readonly IMapper _mapper;

        public TutoresJController(ITutorJRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/tutoresJ
         * 
         * Obtiene todos los datos de todas las filas de las tablas Tutor, Estudiante y Persona.
         */
        [Route("api/tutoresJ")]
        [HttpGet]
        public ActionResult<IEnumerable<TutorJReadDto>> GetAll()
        {
            var tutorJItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<TutorJReadDto>>(tutorJItems));
        }

        /*
         * GET api/tutoresJ/{id}
         * 
         * Obtiene los datos de una sola fila de las tablas Tutor, Estudiante y Persona,
         * con un id especifico de Tutor.
         */
        [Route("api/tutoresJ/{id}")]
        [HttpGet]
        public ActionResult<TutorJReadDto> GetById(int id)
        {
            //Se trae de la base de datos el TutorJ con el id especificado
            var tutorJItem = _repository.GetById(id);

            //Se verifica si este existe
            if (tutorJItem != null)
            {
                return Ok(_mapper.Map<TutorJReadDto>(tutorJItem));
            }

            //Si no existe envia un NotFound
            return NotFound();
        }

        /*
         * GET api/tutoresJ/{id}
         * 
         * Obtiene los datos de una sola fila de las tablas Tutor, Estudiante y Persona,
         * con un id especifico de Tutor.
         */
        [Route("api/tutoresJ/Estudiante/{idEstudiante}")]
        [HttpGet]
        public ActionResult<TutorJReadDto> GetByEstudiante(int idEstudiante)
        {
            //Se trae de la base de datos el TutorJ con el idEstudiante especificado
            var tutorJItem = _repository.GetByEstudiante(idEstudiante);

            //Se verifica si este existe
            if (tutorJItem != null)
            {
                return Ok(_mapper.Map<TutorJReadDto>(tutorJItem));
            }

            //Si no existe envia un NotFound
            return NotFound();
        }
        
    }
}
