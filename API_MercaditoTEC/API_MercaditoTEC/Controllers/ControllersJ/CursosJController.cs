using API_MercaditoTEC.Data;
using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Controllers.ControllersJ
{
    //[Route("api/cursosJ")]
    [ApiController]
    public class CursosJController : ControllerBase
    {
        private readonly ICursoJRepo _repository;
        private readonly IMapper _mapper;

        public CursosJController(ICursoJRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/cursosJ
         * 
         * Obtiene todos los datos de todas las filas de las tablas que forman CursoJ.
         */
        [Route("api/cursosJ")]
        [HttpGet]
        public ActionResult<IEnumerable<CursoJReadDto>> GetAll()
        {
            IEnumerable<CursoJ> cursoJItems = _repository.GetAll();

            if (cursoJItems.Count() != 0)
            {
                return Ok(_mapper.Map<IEnumerable<CursoJReadDto>>(cursoJItems));
            }

            return NoContent();
        }

        /*
         * GET api/cursosJ/{idCurso}
         * 
         * Obtiene los datos de una sola fila de las tablas que forman CursoJ
         * con un id especifico de Curso.
         */
        [Route("api/cursosJ/{idCurso}")]
        [HttpGet]
        public ActionResult<CursoJReadDto> GetById(int idCurso)
        {
            //Se trae de la base de datos el CursoJ con el id especificado
            CursoJ cursoJItem = _repository.GetById(idCurso);

            //Se verifica si este existe
            if (cursoJItem != null)
            {
                return Ok(_mapper.Map<CursoJReadDto>(cursoJItem));
            }

            //Si no existe envia un NotFound
            return NotFound();
        }

        /*
         * GET api/cursosJ/Carrera/{idCarrera}
         * 
         * Obtiene todos los datos de todas las filas de las tablas que forman CursoJ con una Carrera especifica.
         */
        [Route("api/cursosJ/Carrera/{idCarrera}")]
        [HttpGet]
        public ActionResult<IEnumerable<CursoJReadDto>> GetByCarrera(int idCarrera)
        {
            //Se trae de la base de datos los CursoJ con la Carrera especifica
            IEnumerable<CursoJ> cursoJItemsByCarrera = _repository.GetByCarrera(idCarrera);

            if (cursoJItemsByCarrera.Count() != 0)
            {
                return Ok(_mapper.Map<IEnumerable<CursoJReadDto>>(cursoJItemsByCarrera));
            }

            return NoContent();
        }
    }
}
