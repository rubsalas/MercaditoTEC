using System.Collections.Generic;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers.ControllersJ
{
    //[Route("api/comprasProductoJ")]
    [ApiController]
    public class ComprasProductoController : ControllerBase
    {
        private readonly ICompraProductoJRepo _repository;
        private readonly IMapper _mapper;

        public ComprasProductoController(ICompraProductoJRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/comprasProductoJ
         * 
         * Obtiene los datos de las filas de las tablas CompraProducto, Comprador y las de ProductoJ.
         */
        [Route("api/comprasProductoJ")]
        [HttpGet]
        public ActionResult<IEnumerable<CompraProductoJReadDto>> GetAll()
        {
            var compraProductoJItems = _repository.GetAll();

            //Se verifica si este existe
            if (compraProductoJItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<CompraProductoJReadDto>>(compraProductoJItems));
            }

            return NoContent();
        }
    }
}
