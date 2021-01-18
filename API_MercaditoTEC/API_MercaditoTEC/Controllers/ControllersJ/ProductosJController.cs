using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ.ProductoJ;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Controllers.ControllersJ
{
    //[Route("api/productosJ")]
    [ApiController]
    public class ProductosJController : ControllerBase
    {
        private readonly IProductoJRepo _repository;
        private readonly IMapper _mapper;
        private readonly IVendedorJRepo _vendedorJRepository;

        public ProductosJController(IProductoJRepo repository, IMapper mapper, IVendedorJRepo vendedorJRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _vendedorJRepository = vendedorJRepository;
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

        /*
         * GET api/productosJ/Vendedor/{idVendedor}
         * 
         * Obtiene los ProductosJ de un vendedor en especifico
         */
        [Route("api/productosJ/Estudiante/{idEstudiante}")]
        [HttpGet]
        public ActionResult<IEnumerable<ProductoJReadDto>> GetByEstudiante(int idEstudiante)
        {
            //Se obtienen todos los ProductosJ
            IEnumerable<ProductoJ> productoJItems = _repository.GetAll();

            //Esta es la lista que se retornara, cambiar Dto si se hace un diferente, aqui
            List<ProductoJReadDto> productoJItemsByVendedor = new List<ProductoJReadDto>();

            //Se iterara sobre todos los productos y quedaran solo los de un vendedor especifico
            for (int i = 0; i < productoJItems.Count(); i++)
            {
                int idVendedor = _vendedorJRepository.GetId(idEstudiante);

                //Revisa que se cumpla el idVendedor
                if (productoJItems.ElementAt(i).idVendedor == idVendedor)
                {
                    productoJItemsByVendedor.Add(_mapper.Map<ProductoJReadDto>(productoJItems.ElementAt(i)));
                }
            }

            return Ok(productoJItemsByVendedor);
        }

        /*
         * GET api/productosJ/Categoria/{idCategoria}
         * 
         * Obtiene los ProductosJ de una Categoria en especifico
         */
        [Route("api/productosJ/Categoria/{idCategoria}")]
        [HttpGet]
        public ActionResult<IEnumerable<ProductoJReadDto>> GetByCategoria(int idCategoria)
        {
            //Se obtienen todos los ProductosJ
            IEnumerable<ProductoJ> productoJItems = _repository.GetAll();

            //Esta es la lista que se retornara, cambiar Dto si se hace un diferente, aqui
            List<ProductoJReadDto> productoJItemsByCategoria = new List<ProductoJReadDto>();

            //Se iterara sobre todos los productos y quedaran solo los de una Categoria especifica
            for (int i = 0; i < productoJItems.Count(); i++)
            {
                //Revisa que se cumpla el idCategoria
                if (productoJItems.ElementAt(i).idCategoria == idCategoria)
                {
                    productoJItemsByCategoria.Add(_mapper.Map<ProductoJReadDto>(productoJItems.ElementAt(i)));
                }
            }

            return Ok(productoJItemsByCategoria);
        }

    }
}
