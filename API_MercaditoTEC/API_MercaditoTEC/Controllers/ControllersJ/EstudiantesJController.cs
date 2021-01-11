using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ.EstudianteJ;
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
    }
}
