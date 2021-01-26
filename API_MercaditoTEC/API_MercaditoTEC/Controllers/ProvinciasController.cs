using System.Collections.Generic;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers
{
    //[Route("api/provincias")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        private readonly IProvinciaRepo _repository;
        private readonly IMapper _mapper;

        public ProvinciasController(IProvinciaRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/provincias
         * 
         * Obtiene todas los datos de todas las filas de la tabla Provincia.
         */
        [Route("api/provincias")]
        [HttpGet]
        public ActionResult<IEnumerable<ProvinciaReadDto>> GetAll()
        {
            var provinciasItem = _repository.GetAll();

            //Se verifica si este existe
            if (provinciasItem != null)
            {
                return Ok(_mapper.Map<IEnumerable<ProvinciaReadDto>>(provinciasItem));
            }

            //Si no existe
            return NoContent();
        }

        /*
         * GET api/provincias/{idProvincia}
         * 
         * Obtiene los datos de una sola fila de la tabla Provincia con un id especifico.
         */
        [Route("api/provincias/{idProvincia}")]
        [HttpGet]
        public ActionResult<ProvinciaReadDto> GetById(int idProvincia)
        {
            //Se trae de la base de datos la Provincia con el id especificado
            var provinciaItem = _repository.GetById(idProvincia);

            //Se verifica si este existe
            if (provinciaItem != null)
            {
                return Ok(_mapper.Map<ProvinciaReadDto>(provinciaItem));
            }

            //Si no existe
            return NoContent();
        }
    }
}
