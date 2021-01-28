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
        private readonly ICategoriaRepo _categoriaRepo;
        private readonly IMapper _mapper;

        public SqlProductoJRepo(MercaditoTECContext context, IProductoRepo productoRepo, IVendedorJRepo vendedorJRepo,
            IMetodoPagoProductoJRepo metodoPagoProductoJRepo, IImagenProductoRepo imagenProductoRepo, IUbicacionProductoJRepo ubicacionProductoJRepo,
            ICategoriaRepo categoriaRepo, IMapper mapper)
        {
            _context = context;
            _productoRepo = productoRepo;
            _vendedorJRepo = vendedorJRepo;
            _metodoPagoProductoJRepo = metodoPagoProductoJRepo;
            _imagenProductoRepo = imagenProductoRepo;
            _ubicacionProductoJRepo = ubicacionProductoJRepo;
            _categoriaRepo = categoriaRepo;
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

                //Mappeo de Categoria

                //Se obtiene la Categoria
                Categoria categoriaItem = _categoriaRepo.GetById(productosJItems.ElementAt(i).idCategoria);

                //Se mappean los puntos de Canje al ProductoJ correspondiente a mano por ser nombres diferentes
                productosJItems.ElementAt(i).puntosCanje = categoriaItem.puntaje;
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

                //Mappeo de Categoria

                //Se obtiene la Categoria
                Categoria categoriaItem = _categoriaRepo.GetById(productoJItem.idCategoria);

                //Se mappean los puntos de Canje al ProductoJ correspondiente a mano por ser nombres diferentes
                productoJItem.puntosCanje = categoriaItem.puntaje;
            }

                return productoJItem;
        }

        /*
         * Retorna una lista de ProductosJ de la Categoria especificada.
         */
        public IEnumerable<ProductoJ> GetByCategoria(int idCategoria)
        {
            //Mappeo de Productos

            //Se retorna una lista de todos los Productos de la Categoria indicada
            IEnumerable<Producto> productosItems = _productoRepo.GetByCategoria(idCategoria);

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

                //Mappeo de Categoria

                //Se obtiene la Categoria
                Categoria categoriaItem = _categoriaRepo.GetById(productosJItems.ElementAt(i).idCategoria);

                //Se mappean los puntos de Canje al ProductoJ correspondiente a mano por ser nombres diferentes
                productosJItems.ElementAt(i).puntosCanje = categoriaItem.puntaje;
            }

            return productosJItems.ToList();
        }


        /*
         * Retorna una lista de ProductosJ del Estudiante especificado.
         */
        public IEnumerable<ProductoJ> GetByEstudiante(int idEstudiante)
        {
            //Mappeo de Productos

            //Se retorna una lista de todos los Productos del Estudiante indicado
            IEnumerable<Producto> productosItems = _productoRepo.GetByEstudiante(idEstudiante);

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

                //Mappeo de Categoria

                //Se obtiene la Categoria
                Categoria categoriaItem = _categoriaRepo.GetById(productosJItems.ElementAt(i).idCategoria);

                //Se mappean los puntos de Canje al ProductoJ correspondiente a mano por ser nombres diferentes
                productosJItems.ElementAt(i).puntosCanje = categoriaItem.puntaje;
            }

            return productosJItems.ToList();
        }

        /*
         * Retorna el idProducto de un Producto especifico.
         */
        public int GetId(string nombre, int idVendedor)
        {
            return _productoRepo.GetId(nombre, idVendedor);
        }

        /*
         * Ingresa a la base de datos un nuevo Producto, MetodoPagoProducto, UbicacionProducto e ImagenProducto.
         */
        public void Create(ProductoJ productoJ)
        {
            //Se verifica si el ProductoJ ingresado no es nulo
            if (productoJ == null)
            {
                throw new ArgumentNullException(nameof(productoJ));
            }

            /*
             * Create de Producto
             */

            //Mappea el ProductoJ obtenido a un Modelo Producto
            var productoModel = _mapper.Map<Producto>(productoJ);

            //Crea el Producto nuevo en la base de datos
            _productoRepo.Create(productoModel);
            //Guarda los cambios en la tabla Producto en la base de datos
            _productoRepo.SaveChanges();

            //Se obtiene el idProducto recien creado
            int idProductoJ = _productoRepo.GetId(productoJ.nombre, productoJ.idVendedor);

            /*
             * Create de MetodoPagoProducto
             */

            //Se obtienen los MetodoPagoProductoJ
            IEnumerable<MetodoPagoProductoJ> metodoPagoProductoJItems = productoJ.metodosPago;

            //Se itera atraves de todos los MetodoPagoProductoJ
            for (int i = 0; i < metodoPagoProductoJItems.Count(); i++)
            {
                //Se mappea el idProducto del Producto recien creado
                metodoPagoProductoJItems.ElementAt(i).idProducto = idProductoJ;

                //Crea el MetodoPagoProducto correspondiente
                _metodoPagoProductoJRepo.Create(metodoPagoProductoJItems.ElementAt(i));
                //Guarda los cambios en la tabla MetodoPagoProducto en la base de datos
                _metodoPagoProductoJRepo.SaveChanges();
            }

            /*
             * Create de UbicacionProducto
             */

            //Se obtienen las UbicacionProductoJ
            IEnumerable<UbicacionProductoJ> ubicacionProductoJItems = productoJ.ubicaciones;

            //Se itera atraves de todos los UbicacionProductoJ
            for (int i = 0; i < ubicacionProductoJItems.Count(); i++)
            {
                //Se mappea el idProducto del Producto recien creado
                ubicacionProductoJItems.ElementAt(i).idProducto = idProductoJ;

                //Crea la UbicacionProducto correspondiente
                _ubicacionProductoJRepo.Create(ubicacionProductoJItems.ElementAt(i));
                //Guarda los cambios en la tabla UbicacionProducto en la base de datos
                _ubicacionProductoJRepo.SaveChanges();
            }

            /*
             * Create de ImagenProducto
             */

            //Se obtienen las ImagenProducto
            IEnumerable<ImagenProducto> imagenProductoItems = productoJ.imagenes;

            //Se itera atraves de todos las ImagenProducto
            for (int i = 0; i < imagenProductoItems.Count(); i++)
            {
                //Se mappea el idProducto del Producto recien creado
                imagenProductoItems.ElementAt(i).idProducto = idProductoJ;

                //Crea la ImagenProducto correspondiente
                _imagenProductoRepo.Create(imagenProductoItems.ElementAt(i));
                //Guarda los cambios en la tabla ImagenProducto en la base de datos
                _imagenProductoRepo.SaveChanges();
            }

        }

        public void Update(ProductoJ productoJ)
        {
            //IMPLEMENTAR
        }

        public void Delete(ProductoJ productoJ)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return true;
        }
    }
}
