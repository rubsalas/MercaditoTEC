using System.Collections.Generic;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.Datic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers
{
    //[Route("api/datic")]
    [ApiController]
    public class DaticController : ControllerBase
    {
        private IDaticRepo _repository;
        private IMapper _mapper;
        private IEstudianteJRepo _estudianteJRepository;

        public DaticController(IDaticRepo repository, IMapper mapper, IEstudianteJRepo estudianteJRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _estudianteJRepository = estudianteJRepository;
        }

        /*
         * POST api/datic
         * 
         * Obtiene los datos del correo y contrasena registrada de un Estudiante de XTEC y los verifica.
         */
        [Route("api/datic")]
        [HttpPost]
        public ActionResult Verify(DaticVerifyDto daticVerifyDto)
        {
            //Se obtiene el correoInstitucional proveido
            string correoInstitucionalI = daticVerifyDto.correoInstitucional;

            //Trae de la base de datos el correoInstitucional y la contrasena registrada
            var daticItem = _repository.GetByCorreo(correoInstitucionalI);

            //Se crea la respuesta por enviar
            Response response = new Response("Datic", "api/datic", "HttpPost", "Verificacion en Datic");

            //Se verifica que exista el registro del Estudiante en la tabla de Datic
            if (daticItem != null)
            {
                //Se verifica que la contrasena es correcta
                if (daticVerifyDto.contrasena == daticItem.contrasena)
                {
                    //Se obtiene un posible idEstudiante de un estudiante registrado
                    int idEstudiantePosible = _estudianteJRepository.GetId(correoInstitucionalI);

                    //Se verifica si ya hay un estudiante registrado con este correo
                    if (idEstudiantePosible == -1)
                    {
                        /*
                         * Como no hay un estudiante registrado a MercaditoTEC con este correo, se verifica exitosamente
                         * Se agrega un value de 1 al response
                         */
                        response.setValue(1);
                        return Ok(response);
                    }

                    /*
                     * Como si hay un estudiante registrado a MercaditoTEC con este correo, se verifica exitosamente
                     * Se agrega un value de 2 al response
                     */
                    response.setValue(2);
                    return Ok(response);
                }

                /*
                 * Como la contrasena es incorrecta
                 * Se agrega un value de 0 al response
                 */
                response.setValue(0);
                return Ok(response);

            }

            /*
             * Como no existe en al tabla de Datic
             * Se agrega un value de -1 al response
             */
            response.setValue(-1);
            return Ok(response);

        }
    }
}
