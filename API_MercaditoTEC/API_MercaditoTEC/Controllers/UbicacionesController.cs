using System.Collections.Generic;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers
{
    //[Route("api/ubicaciones")]
    [ApiController]
    public class UbicacionesController : ControllerBase
    {
        private readonly IUbicacionRepo _repository;
        private readonly IMapper _mapper;

        public UbicacionesController(IUbicacionRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/ubicaciones
         * 
         * Obtiene todas los datos de todas las filas de la tabla Ubicacion.
         */
        [Route("api/ubicaciones")]
        [HttpGet]
        public ActionResult<IEnumerable<UbicacionReadDto>> GetAll()
        {
            var ubicacionesItems = _repository.GetAll();

            //Se verifica si este existe
            if (ubicacionesItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<UbicacionReadDto>>(ubicacionesItems));
            }

            //Si no existe
            return NoContent();
        }

        /*
         * GET api/ubicaciones/{idUbicacion}
         * 
         * Obtiene los datos de una sola fila de la tabla Ubicacion con un id especifico.
         */
        [Route("api/ubicaciones/{idUbicacion}")]
        [HttpGet]
        public ActionResult<UbicacionReadDto> GetById(int idUbicacion)
        {
            //Se trae de la base de datos la Ubicacion con el id especificado
            var ubicacionItem = _repository.GetById(idUbicacion);

            //Se verifica si este existe
            if (ubicacionItem != null)
            {
                return Ok(_mapper.Map<UbicacionReadDto>(ubicacionItem));
            }

            //Si no existe
            return NoContent();
        }

        /*
         * GET api/ubicaciones/Canton/{idCanton}
         * 
         * Obtiene los datos de las Ubicaciones de un Canton especifico.
         */
        [Route("api/ubicaciones/Canton/{idCanton}")]
        [HttpGet]
        public ActionResult<IEnumerable<UbicacionReadDto>> GetByCanton(int idCanton)
        {
            var ubicacionesByCanton = _repository.GetByCanton(idCanton);

            //Se verifica si este existe
            if (ubicacionesByCanton != null)
            {
                return Ok(_mapper.Map<IEnumerable<UbicacionReadDto>>(ubicacionesByCanton));
            }

            //Si no existe
            return NoContent();
        }
    }
}
