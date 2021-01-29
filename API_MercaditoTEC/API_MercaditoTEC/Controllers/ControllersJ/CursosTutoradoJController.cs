using System.Collections.Generic;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers.ControllersJ
{
    //[Route("api/cursosTutoradoJ")]
    [ApiController]
    public class CursosTutoradoJController : ControllerBase
    {
        private readonly ICursoTutoradoJRepo _repository;
        private readonly IMapper _mapper;

        public CursosTutoradoJController(ICursoTutoradoJRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/cursosTutoradoJ
         * 
         * Obtiene los datos de las filas de las tablas CursoTutorado, y las de TutoradoJ y CursoTutorJ.
         */
        [Route("api/cursosTutoradoJ")]
        [HttpGet]
        public ActionResult<IEnumerable<CursoTutoradoJReadDto>> GetAll()
        {
            var cursoTutoradoJItems = _repository.GetAll();

            //Se verifica si este existe
            if (cursoTutoradoJItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<CursoTutoradoJReadDto>>(cursoTutoradoJItems));
            }

            return NoContent();
        }

        /*
         * GET api/cursosTutoradoJ/{idCursoTutorado}
         * 
         * Obtiene los datos de una sola fila de las tablas que forman CursoTutoradoJ
         * con un id especifico de CursoTutorado.
         */
        [Route("api/cursosTutoradoJ/{idCursoTutorado}")]
        [HttpGet]
        public ActionResult<CursoTutoradoJReadDto> GetById(int idCursoTutorado)
        {
            //Se trae de la base de datos el CursoTutoradoJ con el id especificado
            CursoTutoradoJ cursoTutoradoJItem = _repository.GetById(idCursoTutorado);

            //Se verifica si este existe
            if (cursoTutoradoJItem != null)
            {
                return Ok(_mapper.Map<CursoTutoradoJReadDto>(cursoTutoradoJItem));
            }

            //Si no existe envia un NoContent
            return NoContent();
        }

        /*
         * GET api/cursosTutoradoJ/Tutorado/{idTutorado}
         * 
         * Obtiene los datos de las tablas que forman CursoTutoradoJ de un Tutorado especifico
         */
        [Route("api/cursosTutoradoJ/Tutorado/{idTutorado}")]
        [HttpGet]
        public ActionResult<CursoTutoradoJReadDto> GetByTutorado(int idTutorado)
        {
            var cursoTutoradoJItemsByTutorado = _repository.GetByTutorado(idTutorado);

            //Se verifica si este existe
            if (cursoTutoradoJItemsByTutorado != null)
            {
                return Ok(_mapper.Map<IEnumerable<CursoTutoradoJReadDto>>(cursoTutoradoJItemsByTutorado));
            }

            return NoContent();
        }
    }
}
