using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_MercaditoTEC.Controllers.ControllersJ
{
    //[Route("api/ofertasLaboralesJ")]
    [ApiController]
    public class OfertasLaboralesJController : ControllerBase
    {
        private readonly IOfertaLaboralJRepo _repository;
        private readonly IMapper _mapper;

        public OfertasLaboralesJController(IOfertaLaboralJRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/ofertasLaboralesJ/{idOfertaLaboral}
         * 
         * Obtiene los datos de una sola fila de las tablas que forman OfertaLaboralJ
         * con un id especifico de OfertaLaboral.
         */
        [Route("api/ofertasLaboralesJ/{idOfertaLaboral}")]
        [HttpGet]
        public ActionResult<OfertaLaboralJReadDto> GetById(int idOfertaLaboral)
        {
            //Se trae de la base de datos la OfertaLaboral con el id especificado
            OfertaLaboralJ ofertaLaboralJItem = _repository.GetById(idOfertaLaboral);

            //Se verifica si este existe
            if (ofertaLaboralJItem != null)
            {
                return Ok(_mapper.Map<OfertaLaboralJReadDto>(ofertaLaboralJItem));
            }

            //Si no existe envia un NoContent
            return NoContent();
        }

        /*
         * GET api/ofertasLaboralesJ/Carrera/{idCarrera}
         * 
         * Obtiene las OfertasLaborales de una Carrera en especifico.
         */
        [Route("api/ofertasLaboralesJ/Carrera/{idCarrera}")]
        [HttpGet]
        public ActionResult<IEnumerable<OfertaLaboralJReadDto>> GetByCarrera(int idCarrera)
        {
            IEnumerable<OfertaLaboralJ> ofertaLaboralJItems = _repository.GetByCarrera(idCarrera);

            //Se verifica si este existe
            if (ofertaLaboralJItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<OfertaLaboralJReadDto>>(ofertaLaboralJItems));
            }

            //Si no existe envia un NoContent
            return NoContent();
        }
    }
}
