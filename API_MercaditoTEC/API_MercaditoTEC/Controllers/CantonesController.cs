using System.Collections.Generic;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers
{
    //[Route("api/cantones")]
    [ApiController]
    public class CantonesController : ControllerBase
    {
        private readonly ICantonRepo _repository;
        private readonly IMapper _mapper;

        public CantonesController(ICantonRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/cantones
         * 
         * Obtiene todas los datos de todas las filas de la tabla Canton.
         */
        [Route("api/cantones")]
        [HttpGet]
        public ActionResult<IEnumerable<CantonReadDto>> GetAll()
        {
            var cantonesItems = _repository.GetAll();

            //Se verifica si este existe
            if (cantonesItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<CantonReadDto>>(cantonesItems));
            }

            //Si no existe
            return NoContent();
        }

        /*
         * GET api/cantones/{idCanton}
         * 
         * Obtiene los datos de una sola fila de la tabla Canton con un id especifico.
         */
        [Route("api/cantones/{idCanton}")]
        [HttpGet]
        public ActionResult<CantonReadDto> GetById(int idCanton)
        {
            //Se trae de la base de datos el Canton con el id especificado
            var cantonItem = _repository.GetById(idCanton);

            //Se verifica si este existe
            if (cantonItem != null)
            {
                return Ok(_mapper.Map<CantonReadDto>(cantonItem));
            }

            //Si no existe
            return NoContent();
        }

        /*
         * GET api/cantones/Provincia/{idProvincia}
         * 
         * Obtiene los datos de los Cantones de una Provincia especifica.
         */
        [Route("api/cantones/Provincia/{idProvincia}")]
        [HttpGet]
        public ActionResult<IEnumerable<CantonReadDto>> GetByProvincia(int idProvincia)
        {
            var cantonesByProvincia = _repository.GetByProvincia(idProvincia);

            //Se verifica si este existe
            if (cantonesByProvincia != null)
            {
                return Ok(_mapper.Map<IEnumerable<CantonReadDto>>(cantonesByProvincia));
            }

            //Si no existe
            return NoContent();
        }
    }
}
