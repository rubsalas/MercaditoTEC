using API_MercaditoTEC.Data;
using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ;
using API_MercaditoTEC.Dtos.DtosJ.ProductoJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
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

            //Si no existe envia un NotFound
            return NotFound();
        }
    }
}
