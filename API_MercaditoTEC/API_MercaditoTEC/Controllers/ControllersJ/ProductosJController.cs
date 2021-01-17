using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ.ProductoJ;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_MercaditoTEC.Controllers.ControllersJ
{
    //[Route("api/productosJ")]
    [ApiController]
    public class ProductosJController : ControllerBase
    {
        private readonly IProductoJRepo _repository;
        private readonly IMapper _mapper;

        public ProductosJController(IProductoJRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/productosJ
         * 
         * Obtiene todos los datos de todas las filas de las tablas Producto, ... .
         */
        [Route("api/productosJ")]
        [HttpGet]
        public ActionResult<IEnumerable<ProductoJReadDto>> GetAll()
        {
            IEnumerable<ProductoJ> productoJItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<ProductoJReadDto>>(productoJItems));
        }

        /*
         * GET api/productosJ/{id}
         * 
         * Obtiene los datos de una sola fila de las tablas Producto, ...,
         * con un id especifico de Producto.
         */
        [Route("api/productosJ/{id}")]
        [HttpGet]
        public ActionResult<ProductoJReadDto> GetById(int id)
        {
            //Se trae de la base de datos el EstudianteJ con el id especificado
            ProductoJ productoJItem = _repository.GetById(id);

            //Se verifica si este existe
            if (productoJItem != null)
            {
                return Ok(_mapper.Map<ProductoJReadDto>(productoJItem));
            }

            //Si no existe envia un NotFound
            return NotFound();
        }

    }
}
