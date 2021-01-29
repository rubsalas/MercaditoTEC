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
    public class ComprasProductoJController : ControllerBase
    {
        private readonly ICompraProductoJRepo _repository;
        private readonly IMapper _mapper;

        public ComprasProductoJController(ICompraProductoJRepo repository, IMapper mapper)
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

        /*
         * GET api/comprasProductoJ/{idCompraProducto}
         * 
         * Obtiene los datos de una sola fila de las tablas que forman CompraProductoJ
         * con un id especifico de CompraProducto.
         */
        [Route("api/comprasProductoJ/{idCompraProducto}")]
        [HttpGet]
        public ActionResult<CompraProductoJReadDto> GetById(int idCompraProducto)
        {
            //Se trae de la base de datos la CompraProductoJ con el id especificado
            CompraProductoJ compraProductoJItem = _repository.GetById(idCompraProducto);

            //Se verifica si este existe
            if (compraProductoJItem != null)
            {
                return Ok(_mapper.Map<CompraProductoJReadDto>(compraProductoJItem));
            }

            //Si no existe envia un NoContent
            return NoContent();
        }

        /*
         * GET api/comprasProductoJ/Comprador/{idComprador}
         * 
         * Obtiene los datos de las tablas que forman CompraProductoJ de un Comprador especifico
         */
        [Route("api/comprasProductoJ/Comprador/{idComprador}")]
        [HttpGet]
        public ActionResult<CompraProductoJReadDto> GetByComprador(int idComprador)
        {
            var compraProductoJItems = _repository.GetByComprador(idComprador);

            //Se verifica si este existe
            if (compraProductoJItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<CompraProductoJReadDto>>(compraProductoJItems));
            }

            return NoContent();
        }

        /*
         * GET api/comprasProductoJ/Vendedor/{idVendedor}
         * 
         * Obtiene los datos de las tablas que forman CompraProductoJ de un Vendedor especifico
         */
        [Route("api/comprasProductoJ/Vendedor/{idVendedor}")]
        [HttpGet]
        public ActionResult<CompraProductoJReadDto> GetByVendedor(int idVendedor)
        {
            var compraProductoJItems = _repository.GetByVendedor(idVendedor);

            //Se verifica si este existe
            if (compraProductoJItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<CompraProductoJReadDto>>(compraProductoJItems));
            }

            return NoContent();
        }
    }
}
