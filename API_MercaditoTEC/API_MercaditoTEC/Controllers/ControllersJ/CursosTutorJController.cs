using API_MercaditoTEC.Data;
using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_MercaditoTEC.Controllers.ControllersJ
{
    //[Route("api/cursosTutorJ")]
    [ApiController]
    public class CursosTutorJController : ControllerBase
    {
        private readonly ICursoTutorJRepo _repository;
        private readonly IMapper _mapper;

        public CursosTutorJController(ICursoTutorJRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/cursosTutorJ
         * 
         * Obtiene todos los datos de todas las filas de las tablas CursoTutor, Curso y Tutor.
         */
        [Route("api/cursosTutorJ")]
        [HttpGet]
        public ActionResult<IEnumerable<CursoTutorJReadDto>> GetAll()
        {
            var cursoTutorJItems = _repository.GetAll();

            //Se verifica si este existe
            if (cursoTutorJItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<CursoTutorJReadDto>>(cursoTutorJItems));
            }

            return NoContent();
        }

        /*
         * GET api/cursosTutorJ/{idCursoTutor}
         * 
         * Obtiene todos los datos de una fila especifica de las tablas CursoTutor, Curso y Tutor.
         */
        [Route("api/cursosTutorJ/{idCursoTutor}")]
        [HttpGet]
        public ActionResult<CursoTutorJReadDto> GetById(int idCursoTutor)
        {
            var cursoTutorJItem = _repository.GetById(idCursoTutor);

            //Se verifica si este existe
            if (cursoTutorJItem != null)
            {
                return Ok(_mapper.Map<CursoTutorJReadDto>(cursoTutorJItem));
            }

            return NoContent();
        }

        /*
         * GET api/cursosTutorJ/Estudiante/{idEstudiante}
         * 
         * Obtiene los CursosTutorJ de un Estudiante en especifico.
         */
        [Route("api/cursosTutorJ/Estudiante/{idEstudiante}")]
        [HttpGet]
        public ActionResult<IEnumerable<CursoTutorJReadDto>> GetByEstudiante(int idEstudiante)
        {
            var cursoTutorJItemsByEstudiante = _repository.GetByEstudiante(idEstudiante);

            //Se verifica si este existe
            if (cursoTutorJItemsByEstudiante != null)
            {
                return Ok(_mapper.Map<IEnumerable<CursoTutorJReadDto>>(cursoTutorJItemsByEstudiante));
            }

            return NoContent();
        }

        /*
         * GET api/cursosTutorJ/Curso/{idCurso}
         * 
         * Obtiene los CursosTutorJ de un Curso en especifico
         */
        [Route("api/cursosTutorJ/Curso/{idCurso}")]
        [HttpGet]
        public ActionResult<IEnumerable<CursoTutorJReadDto>> GetByCurso(int idCurso)
        {
            var cursoTutorJItemsByCurso = _repository.GetByCurso(idCurso);

            //Se verifica si este existe
            if (cursoTutorJItemsByCurso != null)
            {
                return Ok(_mapper.Map<IEnumerable<CursoTutorJReadDto>>(cursoTutorJItemsByCurso));
            }

            return NoContent();
        }

        /*
         * GET api/cursosTutorJ/Tutor/{idTutor}
         * 
         * Obtiene los CursosTutorJ de un Tutor en especifico
         */
        [Route("api/cursosTutorJ/Tutor/{idTutor}")]
        [HttpGet]
        public ActionResult<IEnumerable<CursoTutorJReadDto>> GetByTutor(int idTutor)
        {
            var cursoTutorJItemsByTutor = _repository.GetByTutor(idTutor);

            //Se verifica si este existe
            if (cursoTutorJItemsByTutor != null)
            {
                return Ok(_mapper.Map<IEnumerable<CursoTutorJReadDto>>(cursoTutorJItemsByTutor));
            }

            return NoContent();
        }


        /*
         * POST api/cursosTutorJ
         * 
         * Crea un nuevo CursoTutor
         */
        [Route("api/cursosTutorJ")]
        [HttpPost]
        public ActionResult<Response> Create(CursoTutorJCreateDto cursoTutorJCreateDto)
        {
            //Se crea la respuesta por enviar
            Response response = new Response("CursoTutorJ", "api/cursosTutorJ", "HttpPost", "Creacion de CursoTutor: " + cursoTutorJCreateDto.idCurso);

            //Mappea el CursoTutor por crear a un Modelo CursoTutorJ
            CursoTutorJ cursoTutorJModel = _mapper.Map<CursoTutorJ>(cursoTutorJCreateDto);
            //Crea el CursoTutorJ nuevo en la base de datos
            _repository.Create(cursoTutorJModel);
            //Guarda los cambios en la base de datos
            _repository.SaveChanges(); //No implementado para CursoTutorJ

            //Se obtiene el idCursoTutor recien creado
            int idProductoJ = _repository.GetId(cursoTutorJCreateDto.idTutor, cursoTutorJCreateDto.idCurso);

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
             * Se agrega un value del idproductoJ que ha hecho login al response
             */
            response.setValue(idProductoJ);
            return Ok(response);

        }
    }
}
