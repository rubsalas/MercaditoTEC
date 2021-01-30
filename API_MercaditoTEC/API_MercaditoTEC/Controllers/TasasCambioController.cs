using System.Collections.Generic;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Dtos.TasaCambio;
using API_MercaditoTEC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers
{
    //[Route("api/tasasCambio")]S
    [ApiController]
    public class TasasCambioController : ControllerBase
    {
        private readonly ITasaCambioRepo _repository;
        private readonly IMapper _mapper;

        public TasasCambioController(ITasaCambioRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/tasasCambio
         * 
         * Obtiene todas los datos de todas las filas de la tabla TasaCambio.
         */
        [Route("api/tasasCambio")]
        [HttpGet]
        public ActionResult<IEnumerable<TasaCambioReadDto>> GetAll()
        {
            IEnumerable<TasaCambio> tasaCambioItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<TasaCambioReadDto>>(tasaCambioItems));
        }

        /*
         * GET api/tasasCambio
         * 
         * Obtiene la ultima fila de la tabla TasaCambio.
         */
        [Route("api/tasasCambio/Actual")]
        [HttpGet]
        public ActionResult<IEnumerable<TasaCambioReadDto>> GetCurrent()
        {
            TasaCambio tasaCambioCurrent = _repository.GetCurrent();

            return Ok(_mapper.Map<TasaCambioReadDto>(tasaCambioCurrent));
        }

    }
}
