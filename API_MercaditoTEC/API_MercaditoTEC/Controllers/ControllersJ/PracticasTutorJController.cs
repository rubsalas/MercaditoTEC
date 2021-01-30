using System.Collections.Generic;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers.ControllersJ
{
    //[Route("api/practicasTutorJ")]
    [ApiController]
    public class PracticasTutorJController : ControllerBase
    {
        private readonly IPracticaTutorJRepo _repository;
        private readonly IMapper _mapper;

        public PracticasTutorJController(IPracticaTutorJRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/practicasTutorJ
         * 
         * Obtiene todas los datos de todas las filas de las tablas PracticaTutor, TemaPracticaTutor y MetodoPagoPracticaTutor.
         */
        [Route("api/practicasTutorJ")]
        [HttpGet]
        public ActionResult<IEnumerable<PracticaTutorJReadDto>> GetAll()
        {
            var practicaTutorJItems = _repository.GetAll();

            //Se verifica si este existe
            if (practicaTutorJItems != null)
            {
                return Ok(_mapper.Map< IEnumerable<PracticaTutorJReadDto>>(practicaTutorJItems));
            }

            return NoContent();
        }

        /*
         * GET api/practicasTutorJ/{idPracticaTutor}
         * 
         * Obtiene todos los datos de una fila especifica de las tablas PracticaTutor, TemaPracticaTutor y MetodoPagoPracticaTutor.
         */
        [Route("api/practicasTutorJ/{idPracticaTutor}")]
        [HttpGet]
        public ActionResult<PracticaTutorJReadDto> GetById(int idPracticaTutor)
        {
            var practicaTutorJItem = _repository.GetById(idPracticaTutor);

            //Se verifica si este existe
            if (practicaTutorJItem != null)
            {
                return Ok(_mapper.Map<PracticaTutorJReadDto>(practicaTutorJItem));
            }

            return NoContent();
        }

        /*
         * GET api/practicasTutorJ/CursoTutor/{idCursoTutor}
         * 
         * Obtiene las PracticaTutorJ de un CursoTutor en especifico.
         */
        [Route("api/practicasTutorJ/CursoTutor/{idCursoTutor}")]
        [HttpGet]
        public ActionResult<IEnumerable<PracticaTutorJReadDto>> GetByCursoTutor(int idCursoTutor)
        {
            var practicaTutorJItemByCursoTutor = _repository.GetByCursoTutor(idCursoTutor);

            //Se verifica si este existe
            if (practicaTutorJItemByCursoTutor != null)
            {
                return Ok(_mapper.Map<IEnumerable<PracticaTutorJReadDto>>(practicaTutorJItemByCursoTutor));
            }

            return NoContent();
        }

        /*
         * POST api/practicasTutorJ
         * 
         * Crea una nueva PracticaTutor
         */
        [Route("api/practicasTutorJ")]
        [HttpPost]
        public ActionResult<Response> Create(PracticaTutorJCreateDto practicaTutorJCreateDto)
        {
            //Se crea la respuesta por enviar
            Response response = new Response("PracticasTutor", "api/practicasTutorJ", "HttpPost", "Creacion de PracticaTutor: " + practicaTutorJCreateDto.nombre);

            //Mappea la PracticaTutor por crear a un Modelo PracticaTutorJ
            PracticaTutorJ practicaTutorJModel = _mapper.Map<PracticaTutorJ>(practicaTutorJCreateDto);
            //Crea la PracticaTutorJ nueva en la base de datos
            _repository.Create(practicaTutorJModel);
            //Guarda los cambios en la base de datos
            _repository.SaveChanges(); //No implementado para PracticaTutorJ

            //Se obtiene el idPracticaTutor recien creado
            int idPracticaTutor = _repository.GetId(practicaTutorJModel.idCursoTutor, practicaTutorJModel.nombre, practicaTutorJModel.descripcion);

            //Se revisa si se completo la creacion de la PracticaTutorJ
            if (idPracticaTutor == -1)
            {
                /*
                 * Como no se agrego el PracticaTutorJ
                 * Se agrega un value de 0 al response
                 */
                response.setValue(0);
                return Ok(response);
            }

            /*
             * Como se creo la PracticaTutorJ exitosamente
             * Se agrega un value del idPracticaTutor al response
             */
            response.setValue(idPracticaTutor);
            return Ok(response);

        }

    }
}
