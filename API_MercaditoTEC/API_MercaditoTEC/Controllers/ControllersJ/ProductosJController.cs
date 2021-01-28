using API_MercaditoTEC.Data;
using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ.ProductoJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public ProductosJController(IProductoJRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

            //Se verifica si este existe
            if (productoJItems != null)
            {
                //Aqui es donde se podria cambiar al ReadDto de MetodoPago, Ubicaciones, Imagenes

                return Ok(_mapper.Map<IEnumerable<ProductoJReadDto>>(productoJItems));
            }

            //Si no existe envia un NotFound
            return NoContent();
        }

        /*
         * GET api/productosJ/{idProducto}
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
         * GET api/productosJ/Estudiante/{idEstudiante}
         * 
         * Obtiene los ProductosJ de un Estudiante en especifico.
         */
        [Route("api/productosJ/Estudiante/{idEstudiante}")]
        [HttpGet]
        public ActionResult<IEnumerable<ProductoJReadDto>> GetByEstudiante(int idEstudiante)
        {
            IEnumerable<ProductoJ> productoJItemsByEstudiante = _repository.GetByEstudiante(idEstudiante);

            //Se verifica si este existe
            if (productoJItemsByEstudiante != null)
            {
                //Aqui es donde se podria cambiar al ReadDto de MetodoPago, Ubicaciones, Imagenes

                return Ok(_mapper.Map<IEnumerable<ProductoJReadDto>>(productoJItemsByEstudiante));
            }

            //Si no existe envia un NotFound
            return NotFound();
        }

        /*
          * GET api/productosJ/Categoria/{idCategoria}
          * 
          * Obtiene los ProductosJ de una Categoria en especifico.
          */
        [Route("api/productosJ/Categoria/{idCategoria}")]
        [HttpGet]
        public ActionResult<IEnumerable<ProductoJReadDto>> GetByCategoria(int idCategoria)
        {
            IEnumerable<ProductoJ> productoJItemsByCategoria = _repository.GetByCategoria(idCategoria);

            //Se verifica si este existe
            if (productoJItemsByCategoria != null)
            {
                //Aqui es donde se podria cambiar al ReadDto de MetodoPago, Ubicaciones, Imagenes

                return Ok(_mapper.Map<IEnumerable<ProductoJ>>(productoJItemsByCategoria));
            }

            //Si no existe envia un NotFound
            return NotFound();
        }


        /*
         * POST api/productosJ
         * 
         * Crea un nuevo Producto
         */
        [Route("api/productosJ")]
        [HttpPost]
        public ActionResult<Response> Create(ProductoJCreateDto productoJCreateDto)
        {
            //Se crea la respuesta por enviar
            Response response = new Response("ProductosJ", "api/productosJ", "HttpPost", "Creacion de Producto: " + productoJCreateDto.nombre);

            //No es necesario verificar si ya existe

            //Se agrega la fecha actual de creacion
            productoJCreateDto.fechaPublicacion = DateTime.Now;

            //Mappea el Producto por crear a un Modelo ProductoJ
            ProductoJ productoJModel = _mapper.Map<ProductoJ>(productoJCreateDto);
            //Crea el ProductoJ nuevo en la base de datos
            _repository.Create(productoJModel);
            //Guarda los cambios en la base de datos
            _repository.SaveChanges(); //No implementado para ProductoJ


            //Se obtiene el idProducto recien creado
            int idProductoJ = _repository.GetId(productoJCreateDto.nombre, productoJCreateDto.idVendedor);

            //Se revisa si se completo la creacion del Producto
            if (idProductoJ == -1)
            {
                /*
                 * Como no se agrego el Producto
                 * Se agrega un value de 0 al response
                 */
                response.setValue(0);
                return Ok(response);
            }

            /*
             * Como se creo el Producto exitosamente
             * Se agrega un value del idproductoJ al response
             */
            response.setValue(idProductoJ);
            return Ok(response);
        }

        /*
         * PUT api/productosJ/{idProducto}
         * 
         * Actualiza la informacion de un producto
         */
        [Route("api/productosJ/{idProducto}")]
        [HttpPut]
        public ActionResult<Response> Update(int idProducto, ProductoJUpdateDto productoJUpdateDto)
        {
            //Se crea la respuesta por enviar
            Response response = new Response("ProductosJ", "api/productosJ/" + productoJUpdateDto.idProducto, "HttpPut", "Actualización de Producto: " + productoJUpdateDto.nombre);

            //Se obtiene el Producto, con id especifico, del repositorio
            ProductoJ productoJFromRepo = _repository.GetById(idProducto);

            //Se verifica que exista el Producto obtenida con el idProducto especifico
            if (productoJFromRepo == null)
            {
                /*
                 * Como no existe
                 * Se agrega un value de -1 al response
                 */
                response.setValue(-1);
                return Ok(response);
            }

            //Mappea el Producto por actualizar a un Modelo ProductoJ
            ProductoJ productoJModel = _mapper.Map<ProductoJ>(productoJUpdateDto);
            //Actualiza la informacion del Producto en la base de datos
            _repository.Update(productoJModel);                                         //IMPLEMENTAR ESTE METODO
            //Guarda los cambios en la base de datos
            _repository.SaveChanges(); //No implementado para ProductoJ


            /*
             * Como se actualizo el Producto exitosamente
             * Se agrega un value de 1 al response
             */
            response.setValue(1);
            return Ok(response);

        }

    }
}
