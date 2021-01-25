using API_MercaditoTEC.Data;
using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ.ProductoJ;
using API_MercaditoTEC.Models;
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
        private readonly IMetodoPagoProductoJRepo _metodoPagoProductoJRepo;
        private readonly IImagenProductoRepo _imagenProductoRepo;
        private readonly IUbicacionProductoJRepo _ubicacionProductoJRepo;

        public ProductosJController(IProductoJRepo repository, IMapper mapper, IVendedorJRepo vendedorJRepository,
            IMetodoPagoProductoJRepo metodoPagoProductoJRepo, IImagenProductoRepo imagenProductoRepo, IUbicacionProductoJRepo ubicacionProductoJRepo)
        {
            _repository = repository;
            _mapper = mapper;
            _vendedorJRepository = vendedorJRepository;
            _metodoPagoProductoJRepo = metodoPagoProductoJRepo;
            _imagenProductoRepo = imagenProductoRepo;
            _ubicacionProductoJRepo = ubicacionProductoJRepo;
        }

        /*
         * GET api/productosJ
         * 
         * Obtiene todos los datos de todas las filas de las tablas que forman ProductoJ.
         */
        [Route("api/productosJ")]
        [HttpGet]
        public ActionResult<IEnumerable<ProductoJReadDto>> GetAll()
        {
            IEnumerable<ProductoJ> productoJItems = _repository.GetAll();

            //Aqui es donde se podria cambiar al ReadDto de MetodoPago, Ubicaciones, Imagenes

            return Ok(_mapper.Map<IEnumerable<ProductoJReadDto>>(productoJItems));
        }

        /*
         * GET api/productosJ/{id}
         * 
         * Obtiene los datos de una sola fila de las tablas que forman ProductoJ
         * con un id especifico de Producto.
         */
        [Route("api/productosJ/{idProducto}")]
        [HttpGet]
        public ActionResult<ProductoJReadDto> GetById(int idProducto)
        {
            //Se trae de la base de datos el ProductoJ con el id especificado
            ProductoJ productoJItem = _repository.GetById(idProducto);

            //Se verifica si este existe
            if (productoJItem != null)
            {
                //Aqui es donde se podria cambiar al ReadDto de MetodoPago, Ubicaciones, Imagenes

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
                    //Aqui es donde se podria cambiar al ReadDto de MetodoPago, Ubicaciones, Imagenes

                    productoJItemsByVendedor.Add(_mapper.Map<ProductoJReadDto>(productoJItems.ElementAt(i)));
                }
            }

            return Ok(productoJItemsByVendedor);
        }

        /*
         * GET api/productosJ/Estudiante/Preview/{idEstudiante}
         * 
         * Obtiene los ProductosJ de un Estudiante en especifico para presentarlos enlistados como un preview
         */
        [Route("api/productosJ/Estudiante/Preview/{idEstudiante}")]
        [HttpGet]
        public ActionResult<IEnumerable<ProductoJReadDto>> GetByEstudiantePreview(int idEstudiante)
        {
            IEnumerable<ProductoJ> productoJItems = _repository.GetByEstudiante(idEstudiante);

            //Aqui es donde se podria cambiar al ReadDto de MetodoPago, Ubicaciones, Imagenes

            return Ok(_mapper.Map<IEnumerable<ProductoJReadDto>>(productoJItems));
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
                    //Aqui es donde se podria cambiar al ReadDto de MetodoPago, Ubicaciones, Imagenes

                    productoJItemsByCategoria.Add(_mapper.Map<ProductoJReadDto>(productoJItems.ElementAt(i)));
                }
            }

            return Ok(productoJItemsByCategoria);
        }



        /*
          * GET api/productosJ/Categoria/Preview/{idCategoria}
          * 
          * Obtiene los ProductosJ de una Categoria en especifico para presentarlos enlistados como un preview
          */
        [Route("api/productosJ/Categoria/Preview/{idCategoria}")]
        [HttpGet]
        public ActionResult<IEnumerable<ProductoJReadDto>> GetByCategoriaPreview(int idCategoria)
        {
            IEnumerable<ProductoJ> productoJItems = _repository.GetByCategoria(idCategoria);

            //Aqui es donde se podria cambiar al ReadDto de MetodoPago, Ubicaciones, Imagenes

            return Ok(_mapper.Map<IEnumerable<ProductoJReadDto>>(productoJItems));
        }






        /*
         * GET api/productosJ/Test
         * 
         * TEST
         */
        [Route("api/productosJ/Test")]
        [HttpGet]
        public ActionResult<IEnumerable<ImagenProducto>> GetTest()
        {
            /*
            //Test de MetodoPagoProductoJReadDto
            IEnumerable<MetodoPagoProductoJ> metodoPagoProductoJItems = _metodoPagoProductoJRepo.GetAll();
            return Ok(_mapper.Map<IEnumerable<MetodoPagoProductoJReadDto>>(metodoPagoProductoJItems));
            */

            /*
            //Test de MetodoPagoProductoJReadDto
            IEnumerable<ImagenProducto> Items = _imagenProductoRepo.GetAll();
            return Ok(Items);
            */


            //Test de MetodoPagoProductoJReadDto
            IEnumerable<UbicacionProductoJ> Items = _ubicacionProductoJRepo.GetAll();
            return Ok(Items);


            //return NoContent();
        }

    }
}
