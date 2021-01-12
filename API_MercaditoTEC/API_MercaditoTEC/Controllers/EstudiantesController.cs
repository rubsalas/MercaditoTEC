using System.Collections.Generic;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Dtos.Estudiante;
using API_MercaditoTEC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers
{
    [Route("api/estudiantes")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudianteRepo _repository;
        private readonly IMapper _mapper;

        public EstudiantesController(IEstudianteRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/estudiantes
         * 
         * Obtiene todos los datos de todas las filas de la tabla Estudiante.
         */
        [HttpGet]
        public ActionResult<IEnumerable<EstudianteReadDto>> GetAll()
        {
            var estudianteItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<EstudianteReadDto>>(estudianteItems));
        }
    }
}
