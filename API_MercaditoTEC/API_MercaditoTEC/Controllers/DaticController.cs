using System.Collections.Generic;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Dtos.Datic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers
{
    [Route("api/datic")]
    [ApiController]
    public class DaticController : ControllerBase
    {
        private IDaticRepo _repository;
        private IMapper _mapper;

        public DaticController(IDaticRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/datic
         * 
         * Obtiene los datos del correo y contrasena registrada de un Estudiante de XTEC.
         */
        [HttpGet]
        public ActionResult Verify(DaticVerifyDto daticVerifyDto)
        {
            //Se obtiene el correoInstitucional proveido
            string correoInstitucionalI = daticVerifyDto.correoInstitucional;

            //Trae de la base de datos el correoInstitucional y la contrasena registrada
            var daticItem = _repository.GetByCorreo(correoInstitucionalI);

            //Se verifica que exista el registro del Estudiante en la tabla de Datic
            if (daticItem != null)
            {
                //Se verifica que la contrasena es correcta
                if (daticVerifyDto.contrasena == daticItem.contrasena)
                {
                    return Ok(true);
                }

                //Si la contrasena esta mal
                return Ok(false);

            }

            //Si no existe envia un NotFound
            return NotFound();
        }
    }
}
