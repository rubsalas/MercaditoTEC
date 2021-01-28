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
        private readonly IVendedorJRepo _vendedorJRepo;
        private readonly IMapper _mapper;

        public SqlCompraProductoJRepo(MercaditoTECContext context, ICompraProductoRepo compraProductoRepo, IProductoJRepo productoJRepo, IVendedorJRepo vendedorJRepo,
            IMapper mapper)
        {
            _context = context;
            _compraProductoRepo = compraProductoRepo;
            _productoJRepo = productoJRepo;
            _vendedorJRepo = vendedorJRepo;
            _mapper = mapper;
        }

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
                //Mappeo de ProductoJ

                //Mappeo de Comprador
            }

            return compraProductoJItems.ToList();

        }

        public CompraProductoJ GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompraProductoJ> GetByComprador(int idComprador)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompraProductoJ> GetByProducto(int idProducto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompraProductoJ> GetByVendedor(int idVendedor)
        {
            throw new NotImplementedException();
        }

        public int GetId(int idProducto, int idComprador)
        {
            throw new NotImplementedException();
        }

        public void Create(CompraProductoJ compraProductoJ)
        {
            throw new NotImplementedException();
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
