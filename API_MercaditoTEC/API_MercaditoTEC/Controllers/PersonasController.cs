﻿using System.Collections.Generic;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Dtos.Persona;
using API_MercaditoTEC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers
{
    //[Route("api/personas")]
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
         * Obtiene todos los datos de todas las filas de la tabla Persona.
         */
        [Route("api/personas")]
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
        [Route("api/personas/{id}")]
        [HttpGet]
        public ActionResult<PersonaReadDto> GetById(int id)
        {
            //Se trae de la base de datos la Persona con el id especificado
            var personaItem = _repository.GetById(id);

            //Se verifica si este existe
            if(personaItem != null)
            {
                return Ok(_mapper.Map<PersonaReadDto>(personaItem));
            }

            //Si no existe envia un NotFound
            return NotFound();
        }

        /*
         * POST api/personas
         * 
         * Crea una nueva fila con datos en la tabla Persona.
         */
        [Route("api/personas")]
        [HttpPost]
        public ActionResult<PersonaReadDto> Create(PersonaCreateDto personaCreateDto)
        {
            //Mappea la Persona creada a un Modelo Persona
            Persona personaModel = _mapper.Map<Persona>(personaCreateDto);
            //Crea la Persona nueva en la base de datos
            _repository.Create(personaModel);
            //Guarda los cambios en la base de datos
            _repository.SaveChanges();

            //Mappea el Modelo de la Persona a una PersonaRead para retornarlo
            var personaReadDto = _mapper.Map<PersonaReadDto>(personaModel);

            //Retorna un ActionResult 201 Created al hacer el Post, con la PersonaRead
            return CreatedAtRoute(nameof(GetById), new { Id = personaReadDto.idPersona }, personaReadDto);
        }

        /*
         * PUT api/personas/{id}
         * 
         * Actualiza la informacion de una fila de datos en la tabla Persona.
         */
        [Route("api/personas/{id}")]
        [HttpPut]
        public ActionResult Update(int id, PersonaUpdateDto personaUpdateDto)
        {
            //Se obtiene la Persona, con id especifico, del repositorio
            Persona personaModelFromRepo = _repository.GetById(id);
            //Se verifica que exista la Persona obtenida con el id especifico
            if (personaModelFromRepo == null)
            {
                return NotFound();
            }

            //Se mappean los cambios que vienen en la PersonaUpdate con la Persona del repo
            _mapper.Map(personaUpdateDto, personaModelFromRepo);

            //Llama a la funcion de Update en SqlPersonaRepo
            //No hace nada
            _repository.Update(personaModelFromRepo);

            //Guarda los cambios en la base de datos
            _repository.SaveChanges();

            //Envia la confirmacion a donde viene el request, sin contenido
            return NoContent();
        }

        /*
         * DELETE api/personas/{id}
         * 
         * Elimina la informacion de una fila de datos en la tabla Persona.
         */
        [Route("api/personas/{id}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            //Se obtiene la Persona, con id especifico, del repositorio
            var personaModelFromRepo = _repository.GetById(id);
            //Se verifica que exista la Persona obtenida con el id especifico
            if (personaModelFromRepo == null)
            {
                return NotFound();
            }

            //Llama a la funcion de Update en SqlPersonaRepo
            _repository.Delete(personaModelFromRepo);

            //Guarda los cambios en la base de datos
            _repository.SaveChanges();

            //Envia la confirmacion a donde viene el request, sin contenido
            return NoContent();
        }
    }
}
