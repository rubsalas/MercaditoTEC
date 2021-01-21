using System.Collections.Generic;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Dtos.Carrera;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers
{
    //[Route("api/carreras")]
    [ApiController]
    public class CarrerasController : ControllerBase
    {
        private readonly ICarreraRepo _repository;
        private readonly IMapper _mapper;

        public CarrerasController(ICarreraRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/carreras
         * 
         * Obtiene todas los datos de todas las filas de la tabla Carrera.
         */
        [Route("api/carreras")]
        [HttpGet]
        public ActionResult<IEnumerable<CarreraReadDto>> GetAll()
        {
            var carreraItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<CarreraReadDto>>(carreraItems));
        }

        /*
         * GET api/carreras/{idCarrera}
         * 
         * Obtiene los datos de una sola fila de la tabla Carrera con un id especifico.
         */
        [Route("api/carreras/{idCarrera}")]
        [HttpGet]
        public ActionResult<CarreraReadDto> GetById(int idCarrera)
        {
            //Se trae de la base de datos la Categoria con el id especificado
            var carreraItem = _repository.GetById(idCarrera);

            //Se verifica si este existe
            if (carreraItem != null)
            {
                return Ok(_mapper.Map<CarreraReadDto>(carreraItem));
            }

            //Si no existe envia un NotFound
            return NotFound();
        }
    }
}
