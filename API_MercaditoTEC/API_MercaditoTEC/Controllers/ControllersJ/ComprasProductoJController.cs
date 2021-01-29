using System.Collections.Generic;
using System.Linq;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_MercaditoTEC.Controllers.ControllersJ
{
    //[Route("api/comprasProductoJ")]
    [ApiController]
    public class ComprasProductoJController : ControllerBase
    {
        private readonly ICompraProductoJRepo _repository;
        private readonly MercaditoTECContext _context;
        private readonly ICompraProductoRepo _compraProductoRepo;
        private readonly IMapper _mapper;

        public ComprasProductoJController(ICompraProductoJRepo repository, MercaditoTECContext context, ICompraProductoRepo compraProductoRepo,
            IMapper mapper)
        {
            _repository = repository;
            _context = context;
            _compraProductoRepo = compraProductoRepo;
            _mapper = mapper;
        }

        /*
         * GET api/comprasProductoJ
         * 
         * Obtiene los datos de las filas de las tablas CompraProducto, Comprador y las de ProductoJ.
         */
        [Route("api/comprasProductoJ")]
        [HttpGet]
        public ActionResult<IEnumerable<CompraProductoJReadDto>> GetAll()
        {
            var compraProductoJItems = _repository.GetAll();

            //Se verifica si este existe
            if (compraProductoJItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<CompraProductoJReadDto>>(compraProductoJItems));
            }

            return NoContent();
        }

        /*
         * GET api/comprasProductoJ/{idCompraProducto}
         * 
         * Obtiene los datos de una sola fila de las tablas que forman CompraProductoJ
         * con un id especifico de CompraProducto.
         */
        [Route("api/comprasProductoJ/{idCompraProducto}")]
        [HttpGet]
        public ActionResult<CompraProductoJReadDto> GetById(int idCompraProducto)
        {
            //Se trae de la base de datos la CompraProductoJ con el id especificado
            CompraProductoJ compraProductoJItem = _repository.GetById(idCompraProducto);

            //Se verifica si este existe
            if (compraProductoJItem != null)
            {
                return Ok(_mapper.Map<CompraProductoJReadDto>(compraProductoJItem));
            }

            //Si no existe envia un NoContent
            return NoContent();
        }

        /*
         * GET api/comprasProductoJ/Comprador/{idComprador}
         * 
         * Obtiene los datos de las tablas que forman CompraProductoJ de un Comprador especifico
         */
        [Route("api/comprasProductoJ/Comprador/{idComprador}")]
        [HttpGet]
        public ActionResult<CompraProductoJReadDto> GetByComprador(int idComprador)
        {
            var compraProductoJItems = _repository.GetByComprador(idComprador);

            //Se verifica si este existe
            if (compraProductoJItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<CompraProductoJReadDto>>(compraProductoJItems));
            }

            return NoContent();
        }

        /*
         * GET api/comprasProductoJ/Vendedor/{idVendedor}
         * 
         * Obtiene los datos de las tablas que forman CompraProductoJ de un Vendedor especifico
         */
        [Route("api/comprasProductoJ/Vendedor/{idVendedor}")]
        [HttpGet]
        public ActionResult<CompraProductoJReadDto> GetByVendedor(int idVendedor)
        {
            var compraProductoJItems = _repository.GetByVendedor(idVendedor);

            //Se verifica si este existe
            if (compraProductoJItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<CompraProductoJReadDto>>(compraProductoJItems));
            }

            return NoContent();
        }

        /*
         * POST api/comprasProductoJ
         * 
         * Crea una nueva CompraProducto
         */
        [Route("api/comprasProductoJ")]
        [HttpPost]
        public ActionResult<Response> Create(CompraProductoJCreateDto compraProductoJCreateDto)
        {
            //Se crea la respuesta por enviar
            Response response = new Response("CompraProductoJ", "api/comprasProductoJ", "HttpPost",
                "Creacion de CompraProducto: [" + compraProductoJCreateDto.idProducto + ", " + compraProductoJCreateDto.idComprador + "]");

            //Se verifica que exista el Producto y el Comprador este registrado
            if (_context.Producto.Any(p => p.idProducto == compraProductoJCreateDto.idProducto) &&
                _context.Comprador.Any(c => c.idComprador== compraProductoJCreateDto.idComprador))
            {
                //Mappea la CompraProducto por crear a un Modelo CompraProductoJ
                CompraProductoJ compraProductoModel = _mapper.Map<CompraProductoJ>(compraProductoJCreateDto);
                //Crea la CompraProductoJ nueva en la base de datos
                _repository.Create(compraProductoModel);
                //Guarda los cambios en la base de datos
                _repository.SaveChanges(); //No implementado para CompraProductoJ

                //Se obtiene el idCompraProducto recien creado
                int idCompraProducto = _repository.GetId(compraProductoJCreateDto.idProducto, compraProductoJCreateDto.idComprador);

                //Se revisa si se completo la creacion de la CompraProducto
                if (idCompraProducto == -1)
                {
                    /*
                     * Como no se agrego la CompraProducto
                     * Se agrega un value de 0 al response
                     */
                    response.setValue(0);
                    return Ok(response);
                }

                /*
                 * Como se creo la CompraProducto exitosamente
                 * Se agrega un value del idCursoTutor al response
                 */
                response.setValue(idCompraProducto);
                return Ok(response);
            }

            /*
             * Como no existe alguno
             * Se agrega un value de -1 al response
             */
            response.setValue(-1);
            return Ok(response);
        }

        /*
         * PUT api/comprasProductoJ/Confirmacion
         * 
         * El Comprador y el Vendedor confirmaran la compra de un Producto.
         */
        [Route("api/comprasProductoJ/Confirmacion")]
        [HttpPut]
        public ActionResult<Response> CompraProductoConfirmation(CompraProductoJConfirmationDto compraProductoJConfirmationDto)
        {
            //Se crea la respuesta por enviar
            Response response = new Response("ComprasProductoJ", "api/comprasProductoJ/Confirmacion", "HttpPut", 
                "Confirmacion en CompraProducto: " + compraProductoJConfirmationDto.idCompraProducto);

            //Se obtiene la CompraProducto, con id especifico, del repositorio
            CompraProducto compraProductoFromRepo = _compraProductoRepo.GetById(compraProductoJConfirmationDto.idCompraProducto);

            //Se verifica que exista la CompraProducto
            if (_context.CompraProducto.Any(cp => cp.idCompraProducto == compraProductoJConfirmationDto.idCompraProducto))
            {
                //Si proviene del Comprador
                if (compraProductoJConfirmationDto.confirmacionComprador == true)
                {
                    //Se actualiza el dato en la Tabla de la base de datos
                    compraProductoFromRepo.confirmacionComprador = true;
                }
                //Si proviene del Vendedor
                else if (compraProductoJConfirmationDto.confirmacionVendedor == true)
                {
                    //Se actualiza el dato en la Tabla de la base de datos
                    compraProductoFromRepo.confirmacionVendedor = true;
                }
                else
                {
                    /*
                     * Como la CompraProducto por actualizar no recibio ninguna actualizacion
                     * Se agrega un value de -1 al response
                     */
                    response.setValue(-1);
                    return Ok(response);
                }

                //Guarda los cambios en la base de datos
                _compraProductoRepo.SaveChanges();

                //Si se actualizo algun valor, se definira si ambos han confirmado para proceder a la Evaluacion
                if (compraProductoFromRepo.confirmacionComprador == true == compraProductoFromRepo.confirmacionVendedor)
                {
                    /*
                     * Como el Comprador y el Vendedor han confirmado
                     * Se agrega un value de 2 al response
                     */
                    response.setValue(2);
                    return Ok(response);
                }
                else
                {
                    /*
                     * Como falta alguno por confirmar
                     * Se agrega un value de 1 al response
                     */
                    response.setValue(1);
                    return Ok(response);
                }

            }

            /*
             * Como la CompraProducto por actualizar no existe
             * Se agrega un value de 0 al response
             */
            response.setValue(0);
            return Ok(response);
        }

    }
}
