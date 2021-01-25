﻿using API_MercaditoTEC.Data;
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
            return NotFound();
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

    }
}
