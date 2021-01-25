using System.Collections.Generic;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Dtos.PracticaTutor;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers
{
    //[Route("api/practicasTutor")]
    [ApiController]
    public class PracticasTutorController : ControllerBase
    {
        private readonly IPracticaTutorRepo _repository;
        private readonly IMapper _mapper;

        public PracticasTutorController(IPracticaTutorRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/practicasTutor
         * 
         * Obtiene todas los datos de todas las filas de la tabla PracticaTutor.
         */
        [Route("api/practicasTutor")]
        [HttpGet]
        public ActionResult<IEnumerable<PracticaTutorReadDto>> GetAll()
        {
            var practicaTutorItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<PracticaTutorReadDto>>(practicaTutorItems));
        }

        /*
         * GET api/practicasTutor/{idPracticaTutor}
         * 
         * Obtiene todos los datos de una fila especifica de la tabla PracticaTutor.
         */
        [Route("api/practicasTutor/{idPracticaTutor}")]
        [HttpGet]
        public ActionResult<PracticaTutorReadDto> GetById(int idPracticaTutor)
        {
            var practicaTutorItem = _repository.GetById(idPracticaTutor);

            //Se verifica si este existe
            if (practicaTutorItem != null)
            {
                return Ok(_mapper.Map<PracticaTutorReadDto>(practicaTutorItem));
            }

            return NoContent();
        }

        /*
         * GET api/practicasTutor/CursoTutor/{idCursoTutor}
         * 
         * Obtiene las PracticaTutor de un CursoTutor en especifico.
         */
        [Route("api/practicasTutor/CursoTutor/{idCursoTutor}")]
        [HttpGet]
        public ActionResult<IEnumerable<PracticaTutorReadDto>> GetByCursoTutor(int idCursoTutor)
        {
            var practicaTutorItemByCursoTutor = _repository.GetByCursoTutor(idCursoTutor);

            //Se verifica si este existe
            if (practicaTutorItemByCursoTutor != null)
            {
                return Ok(_mapper.Map<IEnumerable<PracticaTutorReadDto>>(practicaTutorItemByCursoTutor));
            }

            return NoContent();
        }
    }
}
