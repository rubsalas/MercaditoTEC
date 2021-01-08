using System.Collections.Generic;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers
{
    [Route("api/personas")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaRepo _repository;

        public PersonasController(IPersonaRepo repository)
        {
            _repository = repository;
        }
        
        //private readonly MockPersonaRepo _repository = new MockPersonaRepo();

        //GET api/personas
        [HttpGet]
        public ActionResult<IEnumerable<Persona>> GetAll()
        {
            var personaItems = _repository.GetAll();

            return Ok(personaItems);
        }

        //GET api/personas{id}
        [HttpGet("{id}")]
        public ActionResult <Persona> GetById(int id)
        {
            var personaItem = _repository.GetById(id);

            return Ok(personaItem);
        }
    }
}
