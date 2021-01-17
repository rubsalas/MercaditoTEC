using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ.VendedorJ;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_MercaditoTEC.Controllers.ControllersJ
{
    //[Route("api/vendedoresJ")]
    [ApiController]
    public class VendedorJController : ControllerBase
    {
        private readonly IVendedorJRepo _repository;
        private readonly IMapper _mapper;

        public VendedorJController(IVendedorJRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * GET api/vendedoresJ
         * 
         * Obtiene todos los datos de todas las filas de las tablas Vendedor y las de EstudianteJ.
         */
        [Route("api/vendedoresJ")]
        [HttpGet]
        public ActionResult<IEnumerable<VendedorJReadDto>> GetAll()
        {
            var vendedorJItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<VendedorJReadDto>>(vendedorJItems));
        }

        /*
         * GET api/estudiantesJ/{id}
         * 
         * Obtiene los datos de una sola fila de las tablas Vendedor y las de EstudianteJ,
         * con un id especifico de Vendedor.
         */
        [Route("api/vendedoresJ/{id}")]
        [HttpGet]
        public ActionResult<VendedorJReadDto> GetById(int id)
        {
            //Se trae de la base de datos el VendedorJ con el id especificado
            var vendedorJItem = _repository.GetById(id);

            //Se verifica si este existe
            if (vendedorJItem != null)
            {
                return Ok(_mapper.Map<VendedorJReadDto>(vendedorJItem));
            }

            //Si no existe envia un NotFound
            return NotFound();
        }
    }
}
