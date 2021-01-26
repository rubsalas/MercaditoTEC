using System.Collections.Generic;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers
{
    //[Route("api/metodosPago")]
    [ApiController]
    public class MetodosPagoController : ControllerBase
    {
        private readonly IMetodoPagoRepo _repository;
        private readonly IMapper _mapper;

        public MetodosPagoController(IMetodoPagoRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/metodosPago
         * 
         * Obtiene todas los datos de todas las filas de la tabla MetodoPago.
         */
        [Route("api/metodosPago")]
        [HttpGet]
        public ActionResult<IEnumerable<MetodoPagoReadDto>> GetAll()
        {
            var metodoPagoItems = _repository.GetAll();

            //Se verifica si este existe
            if (metodoPagoItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<MetodoPagoReadDto>>(metodoPagoItems));
            }

            //Si no existe
            return NoContent();
        }

        /*
         * GET api/metodosPago/{idMetodoPago}
         * 
         * Obtiene los datos de una sola fila de la tabla MetodoPago con un id especifico.
         */
        [Route("api/metodosPago/{idMetodoPago}")]
        [HttpGet]
        public ActionResult<MetodoPagoReadDto> GetById(int idMetodoPago)
        {
            //Se trae de la base de datos la Provincia con el id especificado
            var metodoPagoItem = _repository.GetById(idMetodoPago);

            //Se verifica si este existe
            if (metodoPagoItem != null)
            {
                return Ok(_mapper.Map<MetodoPagoReadDto>(metodoPagoItem));
            }

            //Si no existe
            return NoContent();
        }
    }
}
