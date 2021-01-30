using System.Collections.Generic;
using System.Linq;
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
        private readonly MercaditoTECContext _context;
        private readonly IMapper _mapper;

        public CursosTutoradoJController(ICursoTutoradoJRepo repository, MercaditoTECContext context, IMapper mapper)
        {
            _repository = repository;
            _context = context;
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

        /*
         * POST api/cursosTutoradoJ
         * 
         * Crea un nuevo Cursotutorado
         */
        [Route("api/cursosTutoradoJ")]
        [HttpPost]
        public ActionResult<Response> Create(CursoTutoradoJCreateDto cursoTutoradoJCreateDto)
        {
            //Se crea la respuesta por enviar
            Response response = new Response("CursoTutoradoJ", "api/cursosTutoradoJ", "HttpPost", 
                "Creacion de CursoTutorado: [" + cursoTutoradoJCreateDto.idTutorado + ", " + cursoTutoradoJCreateDto.idCursoTutor + "]");

            //SE DEBE VERIFICAR LA EXISTENCIA DEL TUTORADO COMO DEL CURSOTUTOR, SI NO SE CAE
            if (_context.Tutorado.Any(t => t.idTutorado == cursoTutoradoJCreateDto.idTutorado) &&
                _context.CursoTutor.Any(ct => ct.idCursoTutor == cursoTutoradoJCreateDto.idCursoTutor) )
            {
                //Mappea el CursoTutorado por crear a un Modelo CursoTutoradoJ
                CursoTutoradoJ cursoTutoradoJModel = _mapper.Map<CursoTutoradoJ>(cursoTutoradoJCreateDto);
                //Crea el CursoTutoradoJ nuevo en la base de datos
                _repository.Create(cursoTutoradoJModel);
                //Guarda los cambios en la base de datos
                _repository.SaveChanges(); //No implementado para CursoTutoradoJ

                //Se obtiene el idCursoTutorado recien creado
                int idCursoTutorado = _repository.GetId(cursoTutoradoJCreateDto.idTutorado, cursoTutoradoJCreateDto.idCursoTutor);

                //Se revisa si se completo la creacion del CursoTutorado
                if (idCursoTutorado == -1)
                {
                    /*
                     * Como no se agrego el CursoTutorado
                     * Se agrega un value de 0 al response
                     */
                    response.setValue(0);
                    return Ok(response);
                }

                /*
                 * Como se creo el CursoTutor exitosamente
                 * Se agrega un value del idCursoTutor al response
                 */
                response.setValue(idCursoTutorado);
                return Ok(response);
            }

            /*
             * Como no existe alguno
             * Se agrega un value de -1 al response
             */
            response.setValue(-1);
            return Ok(response);
        }
    }
}
