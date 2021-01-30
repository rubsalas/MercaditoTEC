using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data.DataJ
{
    public class SqlCompraProductoJRepo : ICompraProductoJRepo
    {
        private readonly MercaditoTECContext _context;
        private readonly ICompraProductoRepo _compraProductoRepo;
        private readonly IProductoJRepo _productoJRepo;
        private readonly ICompradorJRepo _compradorJRepo;
        private readonly IMapper _mapper;

        public SqlCompraProductoJRepo(MercaditoTECContext context, ICompraProductoRepo compraProductoRepo, //ICompradorJRepo compradorJRepo,
            IProductoJRepo productoJRepo, ICompradorJRepo compradorJRepo, IMapper mapper)
        {
            _context = context;
            _compraProductoRepo = compraProductoRepo;
            _productoJRepo = productoJRepo;
            _compradorJRepo = compradorJRepo;
            _mapper = mapper;
        }

        /*
         * Retorna todos los CompraProductoJ con la informacion de CompraProducto y ... .
         */
        public IEnumerable<CompraProductoJ> GetAll()
        {
            //Mappeo de CompraProducto

            //Se retorna una lista de todas las CompraProducto
            IEnumerable<CompraProducto> compraProductoItems = _compraProductoRepo.GetAll();

            //Se mappea la parte de CompraProducto al CompraProductoJ
            IEnumerable<CompraProductoJ> compraProductoJItems = _mapper.Map<IEnumerable<CompraProductoJ>>(compraProductoItems);

            //Se itera atraves de todas las CompraProducto para mapearlos con su respectiva informacion restante de CompraProductoJ
            for (int i = 0; i < compraProductoJItems.Count(); i++)
            {
                //Mappeo de Comprador
                
                //Se obtiene el idComprador de la CompraProductoJ
                int idComprador = compraProductoJItems.ElementAt(i).idComprador;

                //Se obtiene el CompradorJ especifico del Producto
                CompradorJ compradorJItem = _compradorJRepo.GetById(idComprador);

                //Se mappea el CompradorJ a la CompraProducto a mano por ser nombres diferentes
                compraProductoJItems.ElementAt(i).nombreComprador = compradorJItem.nombre + ' ' + compradorJItem.apellidos;
                
                //Mappeo de ProductoJ

                //Se obtiene el idProducto de la CompraProductoJ
                int idProducto = compraProductoJItems.ElementAt(i).idProducto;

                //Se obtiene el ProductoJ especifico de la CompraProductoJ
                ProductoJ productoJItem = _productoJRepo.GetById(idProducto);

                //Se mappea el ProductoJ a la CompraProductoJ correspondiente
                _mapper.Map(productoJItem, compraProductoJItems.ElementAt(i));

                //Se deja solo la primera imagen del ProductoJ
                compraProductoJItems.ElementAt(i).imagenes = new List<ImagenProducto>() { compraProductoJItems.ElementAt(i).imagenes.First() };

            }

            return compraProductoJItems.ToList();
        }

        /*
         * Retorna una CompraProductoJ especifico por su idCompraProducto.
         */
        public CompraProductoJ GetById(int id)
        {
            //Mappeo de CompraProducto

            //Se retorna un CompraProducto especifico por su id
            CompraProducto compraProductoItem = _compraProductoRepo.GetById(id);

            //Se mappea la parte de CompraProducto al CompraProductoJ
            CompraProductoJ compraProductoJItem = _mapper.Map<CompraProductoJ>(compraProductoItem);

            //Si la CompraProducto existe
            if (compraProductoJItem != null)
            {
                //Mappeo de Comprador

                //Se obtiene el idComprador de la CompraProductoJ
                int idComprador = compraProductoJItem.idComprador;

                //Se obtiene el CompradorJ especifico del Producto
                CompradorJ compradorJItem = _compradorJRepo.GetById(idComprador);

                //Se mappea el CompradorJ a la CompraProducto a mano por ser nombres diferentes
                compraProductoJItem.nombreComprador = compradorJItem.nombre + ' ' + compradorJItem.apellidos;

                //Mappeo de ProductoJ

                //Se obtiene el idProducto de la CompraProductoJ
                int idProducto = compraProductoJItem.idProducto;

                //Se obtiene el ProductoJ especifico de la CompraProductoJ
                ProductoJ productoJItem = _productoJRepo.GetById(idProducto);

                //Se mappea el ProductoJ a la CompraProductoJ correspondiente
                _mapper.Map(productoJItem, compraProductoJItem);

                //Se deja solo la primera imagen del ProductoJ
                compraProductoJItem.imagenes = new List<ImagenProducto>() { compraProductoJItem.imagenes.First() };
            }

            return compraProductoJItem;
        }

        /*
         * Retorna una CompraProductoJ especifico por su idComprador.
         */
        public IEnumerable<CompraProductoJ> GetByComprador(int idComprador)
        {
            //VERIFICAR QUE EL IDCOMPRADOR EXISTA ?

            //Mappeo de CompraProducto

            //Se retorna una lista de todas las CompraProducto de un Comprador
            IEnumerable<CompraProducto> compraProductoItems = _compraProductoRepo.GetByComprador(idComprador);

            //Se mappea la parte de CompraProducto al CompraProductoJ
            IEnumerable<CompraProductoJ> compraProductoJItems = _mapper.Map<IEnumerable<CompraProductoJ>>(compraProductoItems);

            //Se itera atraves de todas las CompraProducto para mapearlos con su respectiva informacion restante de CompraProductoJ
            for (int i = 0; i < compraProductoJItems.Count(); i++)
            {
                //Mappeo de Comprador

                //idComprador

                //Se obtiene el CompradorJ especifico del Producto
                CompradorJ compradorJItem = _compradorJRepo.GetById(idComprador);

                //Se mappea el CompradorJ a la CompraProducto a mano por ser nombres diferentes
                compraProductoJItems.ElementAt(i).nombreComprador = compradorJItem.nombre + ' ' + compradorJItem.apellidos;

                //Mappeo de ProductoJ

                //Se obtiene el idProducto de la CompraProductoJ
                int idProducto = compraProductoJItems.ElementAt(i).idProducto;

                //Se obtiene el ProductoJ especifico de la CompraProductoJ
                ProductoJ productoJItem = _productoJRepo.GetById(idProducto);

                //Se mappea el ProductoJ a la CompraProductoJ correspondiente
                _mapper.Map(productoJItem, compraProductoJItems.ElementAt(i));

                //Se deja solo la primera imagen del ProductoJ
                compraProductoJItems.ElementAt(i).imagenes = new List<ImagenProducto>() { compraProductoJItems.ElementAt(i).imagenes.First() };
            }

            return compraProductoJItems.ToList();
        }

        /*
         * Retorna una CompraProductoJ especifico por su idProducto.
         */
        public IEnumerable<CompraProductoJ> GetByProducto(int idProducto)
        {
            throw new NotImplementedException();
        }

        /*
         * Retorna una CompraProductoJ especifico por su idVendedor.
         */
        public IEnumerable<CompraProductoJ> GetByVendedor(int idVendedor)
        {
            //VERIFICAR QUE EL IDVENDEDOR EXISTA ?

            //Mappeo de CompraProducto

            //Se retorna una lista de todas las CompraProducto de un Vendedor
            IEnumerable<CompraProductoJ> compraProductoJItems = GetByVendedorAux(idVendedor);

            //Se mappea la parte de CompraProducto al CompraProductoJ
            //IEnumerable<CompraProductoJ> compraProductoJItems = _mapper.Map<IEnumerable<CompraProductoJ>>(compraProductoItems);

            //Se itera atraves de todas las CompraProducto para mapearlos con su respectiva informacion restante de CompraProductoJ
            for (int i = 0; i < compraProductoJItems.Count(); i++)
            {
                //Mappeo de Comprador

                //Se obtiene el idComprador de la CompraProductoJ
                int idComprador = compraProductoJItems.ElementAt(i).idComprador;

                //Se obtiene el CompradorJ especifico del Producto
                CompradorJ compradorJItem = _compradorJRepo.GetById(idComprador);

                //Se mappea el CompradorJ a la CompraProducto a mano por ser nombres diferentes
                compraProductoJItems.ElementAt(i).nombreComprador = compradorJItem.nombre + ' ' + compradorJItem.apellidos;

                //Mappeo de ProductoJ

                //Se obtiene el idProducto de la CompraProductoJ
                int idProducto = compraProductoJItems.ElementAt(i).idProducto;

                //Se obtiene el ProductoJ especifico de la CompraProductoJ
                ProductoJ productoJItem = _productoJRepo.GetById(idProducto);

                //Se mappea el ProductoJ a la CompraProductoJ correspondiente
                _mapper.Map(productoJItem, compraProductoJItems.ElementAt(i));

                //Se deja solo la primera imagen del ProductoJ
                compraProductoJItems.ElementAt(i).imagenes = new List<ImagenProducto>() { compraProductoJItems.ElementAt(i).imagenes.First() };
            }

            return compraProductoJItems.ToList();
        }

        public IEnumerable<CompraProductoJ> GetByVendedorAux(int idVendedor)
        {
            //Se obtienen todas las CompraProductoJ
            IEnumerable<CompraProductoJ> compraProductoJItems = GetAll();

            //Se crea una nueva lista donde se dejaran las CompraProducto especificas
            List<CompraProductoJ> compraProductoJByVendedor = new List<CompraProductoJ>();

            //Se iterara sobre todas las CompraProductosJ y quedaran solo los de un Vendedor especifico
            for (int i = 0; i < compraProductoJItems.Count(); i++)
            {
                //Revisa que se cumpla el idProducto
                if (compraProductoJItems.ElementAt(i).idVendedor == idVendedor)
                {
                    compraProductoJByVendedor.Add(compraProductoJItems.ElementAt(i));
                }
            }

            return compraProductoJByVendedor;
        }

        /*
         * Retorna el idCompraProducto de una CompraProducto especifica.
         */
        public int GetId(int idProducto, int idComprador)
        {
            return _compraProductoRepo.GetId(idProducto, idComprador);
        }

        /*
         * Ingresa a la base de datos una nueva CompraProducto.
         */
        public void Create(CompraProductoJ compraProductoJ)
        {
            //Se verifica si la CompraProductoJ ingresada no es nulo
            if (compraProductoJ == null)
            {
                throw new ArgumentNullException(nameof(compraProductoJ));
            }

            //Mappea la CompraProductoJ obtenido a un Modelo CompraProducto
            CompraProducto compraProductoModel = _mapper.Map<CompraProducto>(compraProductoJ);

            //Se crea la CompraProductoJ nueva en la base de datos
            _compraProductoRepo.Create(compraProductoModel);
            //Se guardan los cambios en la tabla CompraProducto en la base de datos
            _compraProductoRepo.SaveChanges();
        }

        public void Update(CompraProductoJ compraProductoJ)
        {
            throw new NotImplementedException();
        }

        public void Delete(CompraProductoJ compraProductoJ)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return true;
        } 
    }
}
