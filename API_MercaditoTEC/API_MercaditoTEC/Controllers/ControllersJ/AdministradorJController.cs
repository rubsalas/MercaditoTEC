using System.Collections.Generic;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ;
using API_MercaditoTEC.Dtos.DtosJ.EstudianteJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers.ControllersJ
{
    //[Route("api/administradoresJ")]
    [ApiController]
    public class AdministradorJController : ControllerBase
    {
        private readonly IAdministradorJRepo _repository;
        private readonly IMapper _mapper;
        private readonly IPersonaRepo _personaRepo;

        public AdministradorJController(IAdministradorJRepo repository, IMapper mapper, IPersonaRepo personaRepo)
        {
            _repository = repository;
            _mapper = mapper;
            _personaRepo = personaRepo;
        }

        /*
         * GET api/administradoresJ
         * 
         * Obtiene todos los datos de todas las filas de las tablas Persona y Administrador.
         */
        [Route("api/administradoresJ")]
        [HttpGet]
        public ActionResult<IEnumerable<AdministradorJReadDto>> GetAll()
        {
            var administradorJItem = _repository.GetAll();

            //Se verifica si este existe
            if (administradorJItem != null)
            {
                return Ok(_mapper.Map<IEnumerable<AdministradorJReadDto>>(administradorJItem));
            }

            //Si no existe envia un NoContent
            return NoContent();
        }

        //GET/id

        /*
         * GET api/estudiantesJ/{idAdministrador}
         * 
         * Obtiene los datos de una sola fila de las tablas Persona y Estudiante,
         * con un id especifico de Estudiante.
         */
        [Route("api/administradoresJ/{idAdministrador}")]
        [HttpGet]
        public ActionResult<AdministradorJReadDto> GetById(int idAdministrador)
        {
            //Se trae de la base de datos el AdministradorJ con el id especificado
            var administradorJItem = _repository.GetById(idAdministrador);

            //Se verifica si este existe
            if (administradorJItem != null)
            {
                return Ok(_mapper.Map<AdministradorJReadDto>(administradorJItem));
            }

            //Si no existe envia un NoContent
            return NoContent();
        }


        /*
         * GET api/administradoresJ/Login
         * 
         * Obtiene los datos de login del Administrador y verifica su autenticidad.
         */
        [Route("api/administradoresJ/Login")]
        [HttpPost]
        public ActionResult<Response> LoginAdministrador(AdministradorJLoginDto administradorJLoginDto)
        {
            //Se crea la respuesta por enviar
            Response response = new Response("AdministradoresJ", "api/administradoresJ/Login", "HttpPost", "Login Administrador: " + administradorJLoginDto.usuario);

            //Se obtiene el usuario del usuario
            string usuario = administradorJLoginDto.usuario;

            //Trae de la base de datos el usuario y la contrasena registrada en la tabla de Administrador
            var administradorItem = _repository.GetByUsuario(usuario);

            //Trae de la base de datos el idAdministrador registrado con el usuario
            int idAdministrador = _repository.GetId(usuario);

            //Se verifica que exista el usuario del Administrador
            if (administradorItem != null)
            {

                //Se verifica que el Administrador este registrado en el sistema de MercaditoTEC
                if (idAdministrador != -1)
                {

                    //Se verifica que la contrasena es correcta
                    if (administradorJLoginDto.contrasena == administradorItem.contrasena)
                    {

                        /*
                         * Como se verifica exitosamente el login del Administrador
                         * Se agrega un value del idAdministrador que ha hecho login al response
                         */
                        response.setValue(idAdministrador);
                        return Ok(response);
                    }

                    /*
                    * Como la contrasena es incorrecta
                    * Se agrega un value de 0 al response
                    */
                    response.setValue(0);
                    return Ok(response);
                }

            }

            /*
             * Como no existe el Administrador
             * Se agrega un value de -1 al response
             */
            response.setValue(-1);
            return Ok(response);
        }


    }
}
