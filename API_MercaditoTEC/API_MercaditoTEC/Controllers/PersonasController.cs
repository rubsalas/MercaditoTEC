using System.Collections.Generic;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Dtos.Persona;
using API_MercaditoTEC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers
{
    [Route("api/personas")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaRepo _repository;
        private readonly IMapper _mapper;

        public PersonasController(IPersonaRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/personas
         * 
         * Obtiene todas los datos de todas las filas de la tabla Persona.
         */
        [HttpGet]
        public ActionResult<IEnumerable<PersonaReadDto>> GetAll()
        {
            var personaItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<PersonaReadDto>>(personaItems));
        }

        /*
         * GET api/personas/{id}
         * 
         * Obtiene los datos de una sola fila de la tabla Persona con un id especifico.
         */
        [HttpGet("{id}", Name="GetById")]
        public ActionResult <PersonaReadDto> GetById(int id)
        {
            //Trae de la base de datos la Persona con el id especificado
            var personaItem = _repository.GetById(id);

            //Verifica si este existe
            if(personaItem != null)
            {
                return Ok(_mapper.Map<PersonaReadDto>(personaItem));
            }

            //Sino existe envia un NotFound
            return NotFound();
        }

        /*
         * POST api/personas
         * 
         * Crea una nueva fila con datos en la tabla Persona.
         */
        [HttpPost]
        public ActionResult <PersonaReadDto> Create(PersonaCreateDto personaCreateDto)
        {
            //Mappea la Persona creada a un Modelo Persona
            var personaModel = _mapper.Map<Persona>(personaCreateDto);
            //Crea la Persona nueva en la base de datos
            _repository.Create(personaModel);
            //Guarda los cambios en la base de datos
            _repository.SaveChanges();

            //Mappea el Modelo de la Persona a una PersonaRead para retornarlo
            var personaReadDto = _mapper.Map<PersonaReadDto>(personaModel);

            //Retorna un ActionResult 201 Created al hacer el Post, con la PersonaRead
            return CreatedAtRoute(nameof(GetById), new { Id = personaReadDto.idPersona }, personaReadDto);
            //return Ok(personaReadDto);
        }

        /*
         * PUT api/personas/{id}
         * 
         * Actualiza la informacion de una fila de datos en la tabla Persona.
         */
        [HttpPut("{id}")]
        public ActionResult Update(int id, PersonaUpdateDto personaUpdateDto)
        {
            //Se obtiene la Persona, con id especifico, del repositorio
            var personaModelFromRepo = _repository.GetById(id);
            //Se verifica que exista la Persona obtenida con el id especifico
            if (personaModelFromRepo == null)
            {
                return NotFound();
            }

            //Se mappean los cambios que vienen en la PersonaUpdate con la Persona del repo
            _mapper.Map(personaUpdateDto, personaModelFromRepo);

            //Llama a la funcion de Update en SqlPersonaRepo
            _repository.Update(personaModelFromRepo);

            //Guarda los cambios en la base de datos
            _repository.SaveChanges();

            //Envia la confirmacion a donde viene el request sin contenido
            return NoContent();
        }
    }
}
