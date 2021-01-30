using System.Collections.Generic;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Dtos.Categoria;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers
{
    //[Route("api/categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepo _repository;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/categorias
         * 
         * Obtiene todas los datos de todas las filas de la tabla Categoria.
         */
        [Route("api/categorias")]
        [HttpGet]
        public ActionResult<IEnumerable<CategoriaReadDto>> GetAll()
        {
            var categoriaItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<CategoriaReadDto>>(categoriaItems));
        }

        /*
         * GET api/categorias/{id}
         * 
         * Obtiene los datos de una sola fila de la tabla Categoria con un id especifico.
         */
        [Route("api/categorias/{id}")]
        [HttpGet]
        public ActionResult<CategoriaReadDto> GetById(int id)
        {
            //Se trae de la base de datos la Categoria con el id especificado
            var categoriaItem = _repository.GetById(id);

            //Se verifica si este existe
            if (categoriaItem != null)
            {
                return Ok(_mapper.Map<CategoriaReadDto>(categoriaItem));
            }

            //Si no existe envia un NotFound
            return NotFound();
        }

    }

}
