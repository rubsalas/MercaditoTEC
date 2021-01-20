using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data.DataJ
{
    public class SqlProductoJRepo : IProductoJRepo
    {
        private readonly MercaditoTECContext _context;
        private readonly IProductoRepo _productoRepo;
        private readonly IVendedorJRepo _vendedorJRepo;
        private readonly IMetodoPagoProductoJRepo _metodoPagoProductoJRepo;
        private readonly IImagenProductoRepo _imagenProductoRepo;
        private readonly IUbicacionProductoJRepo _ubicacionProductoJRepo;
        private readonly IMapper _mapper;

        /*
         * Retorna todos los ProductosJ con la informacion de ....
         */
        public SqlProductoJRepo(MercaditoTECContext context, IProductoRepo productoRepo, IVendedorJRepo vendedorJRepo,
            IMetodoPagoProductoJRepo metodoPagoProductoJRepo, IImagenProductoRepo imagenProductoRepo, IUbicacionProductoJRepo ubicacionProductoJRepo,
            IMapper mapper)
        {
            _context = context;
            _productoRepo = productoRepo;
            _vendedorJRepo = vendedorJRepo;
            _metodoPagoProductoJRepo = metodoPagoProductoJRepo;
            _imagenProductoRepo = imagenProductoRepo;
            _ubicacionProductoJRepo = ubicacionProductoJRepo;
            _mapper = mapper;
        }

        /*
         * Retorna todos los ProductoJ con la informacion de Producto, Vendedor, MetodoPagoProductos, ....
         */
        public IEnumerable<ProductoJ> GetAll()
        {
            //Mappeo de Productos

            //Se retorna una lista de todos los Productos
            IEnumerable<Producto> productosItems = _productoRepo.GetAll();

            //Se mappea la parte de Producto al ProductoJ
            IEnumerable<ProductoJ> productosJItems = _mapper.Map<IEnumerable<ProductoJ>>(productosItems);

            //Se itera atraves de todos los productos para mapearlos con su respectiva informacion restante de ProductosJ
            for (int i = 0; i < productosJItems.Count(); i++)
            {
                //Mappeo de Vendedor

                //Se obtiene el idVendedor del ProductoJ
                int idVendedor = productosJItems.ElementAt(i).idVendedor;

                //Se obtiene el VendedorJ especifico del Producto
                VendedorJ vendedorJItem = _vendedorJRepo.GetById(idVendedor);

                //Se mappea el VendedorJ al ProductoJ a mano por ser nombres diferentes
                //productoJItem.idVendedor = idVendedor;
                productosJItems.ElementAt(i).nombreVendedor = vendedorJItem.nombre + ' ' + vendedorJItem.apellidos;
                productosJItems.ElementAt(i).calificacionPromedioVendedor = vendedorJItem.calificacionPromedioProductos;

                //Mappeo de MetodoPagoProducto

                //Se obtienen los MetodoPagoProductoJ
                IEnumerable<MetodoPagoProductoJ> metodoPagoProductoJItems = _metodoPagoProductoJRepo.GetByProducto(productosJItems.ElementAt(i).idProducto);

                //Se mappea el MetodoPagoProductoJ al ProductoJ correspondiente a mano por ser nombres diferentes
                productosJItems.ElementAt(i).metodosPago = metodoPagoProductoJItems;

                //Mappeo de ImagenProducto

                //Se obtienen los ImagenProducto
                IEnumerable<ImagenProducto> imagenProductoItems = _imagenProductoRepo.GetByProducto(productosJItems.ElementAt(i).idProducto);

                //Se mappea la ImagenProducto al ProductoJ correspondiente a mano por ser nombres diferentes
                productosJItems.ElementAt(i).imagenes = imagenProductoItems;

                //Mappeo de UbicacionProducto

                //Se obtienen las UbicacionProducto
                IEnumerable<UbicacionProductoJ> ubicacionProductoJItems = _ubicacionProductoJRepo.GetByProducto(productosJItems.ElementAt(i).idProducto);

                //Se mappea la UbicacionProductoJ al ProductoJ correspondiente a mano por ser nombres diferentes
                productosJItems.ElementAt(i).ubicaciones = ubicacionProductoJItems;
            }

            return productosJItems.ToList();
        }

        /*
         * Retorna un ProductoJ con la informacion de Producto, Vendedor, MetodoPagoProductos, ....
         */
        public ProductoJ GetById(int id)
        {
            //Mappeo de Producto

            //Se retorna un Producto especifico
            Producto productoItem = _context.Producto.FirstOrDefault(p => p.idProducto == id);

            //Se mappea la parte de Estudiante al EstudianteJ
            ProductoJ productoJItem = _mapper.Map<ProductoJ>(productoItem);

            //Si el Producto existe
            if (productoJItem != null)
            {
                //Mappeo de Vendedor

                //Se obtiene el idVendedor del ProductoJ
                int idVendedor = productoJItem.idVendedor;

                //Se obtiene el VendedorJ especifico del Producto
                VendedorJ vendedorJItem = _vendedorJRepo.GetById(idVendedor);

                //Se mappea el VendedorJ al ProductoJ a mano por ser nombres diferentes
                //productoJItem.idVendedor = idVendedor;
                productoJItem.nombreVendedor = vendedorJItem.nombre + ' ' + vendedorJItem.apellidos;
                productoJItem.calificacionPromedioVendedor = vendedorJItem.calificacionPromedioProductos;

                //Mappeo de MetodoPagoProducto

                //Se obtienen los MetodoPagoProductoJ
                IEnumerable<MetodoPagoProductoJ> metodoPagoProductoJItems = _metodoPagoProductoJRepo.GetByProducto(productoJItem.idProducto);

                //Se mappea el MetodoPagoProductoJ al ProductoJ correspondiente a mano por ser nombres diferentes
                productoJItem.metodosPago = metodoPagoProductoJItems;

                //Mappeo de ImagenProducto

                //Se obtienen los ImagenProducto
                IEnumerable<ImagenProducto> imagenProductoItems = _imagenProductoRepo.GetByProducto(productoJItem.idProducto);

                //Se mappea la ImagenProducto al ProductoJ correspondiente a mano por ser nombres diferentes
                productoJItem.imagenes = imagenProductoItems;

                //Mappeo de UbicacionProducto

                //Se obtienen las UbicacionProducto
                IEnumerable<UbicacionProductoJ> ubicacionProductoJItems = _ubicacionProductoJRepo.GetByProducto(productoJItem.idProducto);

                //Se mappea la UbicacionProductoJ al ProductoJ correspondiente a mano por ser nombres diferentes
                productoJItem.ubicaciones = ubicacionProductoJItems;
            }

                return productoJItem;
        }

        public int GetId(string nombre)
        {
            throw new NotImplementedException();
        }

        public void Create(ProductoJ productoJ)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductoJ productoJ)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductoJ productoJ)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
