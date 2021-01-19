using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data.DataJ
{
    public class SqlMetodoPagoProductoJRepo : IMetodoPagoProductoJRepo
    {
        private readonly MercaditoTECContext _context;
        private readonly IMetodoPagoProductoRepo _metodoPagoProductoRepo;
        private readonly IMetodoPagoRepo _metodoPagoRepo;
        private readonly IMapper _mapper;

        public SqlMetodoPagoProductoJRepo(MercaditoTECContext context, IMetodoPagoProductoRepo metodoPagoProductoRepo,
            IMetodoPagoRepo metodoPagoRepo, IMapper mapper)
        {
            _context = context;
            _metodoPagoProductoRepo = metodoPagoProductoRepo;
            _metodoPagoRepo = metodoPagoRepo;
            _mapper = mapper;
        }

        /*
         * Retorna todos los MetodoPagoProductoJ con la informacion de MetodoPago y MetodoPagoProducto.
         */
        public IEnumerable<MetodoPagoProductoJ> GetAll()
        {
            //Mappeo de MetodoPagoProducto

            //Se retorna una lista de todos los MetodoPagoProducto
            IEnumerable<MetodoPagoProducto> metodoPagoProductoItems = _metodoPagoProductoRepo.GetAll();

            //Se mappea la parte de MetodoPagoProducto a MetodoPagoProductoJ
            IEnumerable<MetodoPagoProductoJ> metodoPagoProductoJItems = _mapper.Map<IEnumerable<MetodoPagoProductoJ>>(metodoPagoProductoItems);

            //Se itera atraves de todos los MetodoPagoProducto para mapearlos con su respectiva informacion restante de MetodoPagoProductoJ
            for (int i = 0; i < metodoPagoProductoJItems.Count(); i++)
            {
                //Mappeo de MetodoPago

                //Se obtiene el idMetodoPago de MetodoPagoProducto
                int idMetodoPago = metodoPagoProductoJItems.ElementAt(i).idMetodoPago;

                //Se obtiene el MetodoPago especifico de MetodoPagoProducto
                MetodoPago metodoPagoItem = _metodoPagoRepo.GetById(idMetodoPago);

                //Se mappea el MetodoPago al MetodoPagoProductoJ correspondiente
                _mapper.Map(metodoPagoItem, metodoPagoProductoJItems.ElementAt(i));
            }

            return metodoPagoProductoJItems.ToList();
        }

        /*
         * Retorna un MetodoPagoProductoJ con la informacion de MetodoPago y MetodoPagoProducto.
         */
        public MetodoPagoProductoJ GetById(int id)
        {
            //Mappeo de MetodoPagoProducto

            //Se retorna un MetodoPagoProducto especifico
            MetodoPagoProducto metodoPagoProductoItem = _context.MetodoPagoProducto.FirstOrDefault(mpp => mpp.idMetodoPagoProducto == id);

            //Se mappea la parte de MetodoPagoProducto a MetodoPagoProductoJ
            MetodoPagoProductoJ metodoPagoProductoJItem = _mapper.Map<MetodoPagoProductoJ>(metodoPagoProductoItem);

            //Si el MetodoPagoProductoJ existe
            if (metodoPagoProductoJItem != null)
            {
                //Mappeo de MetodoPago

                //Se obtiene el idMetodoPago de MetodoPagoProducto
                int idMetodoPago = metodoPagoProductoJItem.idMetodoPago;

                //Se obtiene el MetodoPago especifico de MetodoPagoProducto
                MetodoPago metodoPagoItem = _metodoPagoRepo.GetById(idMetodoPago);

                //Se mappea el MetodoPago al MetodoPagoProductoJ correspondiente
                _mapper.Map(metodoPagoItem, metodoPagoProductoJItem);
            }

            return metodoPagoProductoJItem;
        }

        /*
         * Retorna una lista de MetodoPagoProductoJ de un unico Producto indicado.
         */
        /*public IEnumerable<MetodoPagoProductoJ> GetByProducto(int idProducto)
        {
            //Mappeo de MetodoPagoProducto

            //Se retorna una lista de todos los MetodoPagoProducto
            IEnumerable<MetodoPagoProducto> metodoPagoProductoItems = _metodoPagoProductoRepo.GetAll();

            //Se mappea la parte de MetodoPagoProducto a MetodoPagoProductoJ
            IEnumerable<MetodoPagoProductoJ> metodoPagoProductoJItemsByProducto = _mapper.Map<IEnumerable<MetodoPagoProductoJ>>(metodoPagoProductoItems);

            //Se itera atraves de todos los MetodoPagoProducto para mapearlos con su respectiva informacion restante de MetodoPagoProductoJ
            for (int i = 0; i < metodoPagoProductoJItemsByProducto.Count(); i++)
            {
                //Se verifica que se ingresen solo los del Producto indicado
                if (metodoPagoProductoJItemsByProducto.ElementAt(i).idProducto == idProducto)
                {
                    //Mappeo de MetodoPago

                    //Se obtiene el idMetodoPago de MetodoPagoProducto
                    int idMetodoPago = metodoPagoProductoJItemsByProducto.ElementAt(i).idMetodoPago;

                    //Se obtiene el MetodoPago especifico de MetodoPagoProducto
                    MetodoPago metodoPagoItem = _metodoPagoRepo.GetById(idMetodoPago);

                    //Se mappea el MetodoPago al MetodoPagoProductoJ correspondiente
                    _mapper.Map(metodoPagoItem, metodoPagoProductoJItemsByProducto.ElementAt(i));
                }
            }

            return metodoPagoProductoJItemsByProducto.ToList();
        }*/

        /*
         * Retorna una lista de MetodoPagoProductoJ de un unico Producto indicado.
         */
        public IEnumerable<MetodoPagoProductoJ> GetByProducto(int idProducto)
        {
            //Mappeo de MetodoPagoProducto

            //Se retorna una lista de todos los MetodoPagoProducto con el idProducto indicado
            IEnumerable<MetodoPagoProducto> metodoPagoProductoItemsByProducto = _metodoPagoProductoRepo.GetByProducto(idProducto);

            //Se mappea la parte de MetodoPagoProducto a MetodoPagoProductoJ
            IEnumerable<MetodoPagoProductoJ> metodoPagoProductoJItemsByProducto = _mapper.Map<IEnumerable<MetodoPagoProductoJ>>(metodoPagoProductoItemsByProducto);

            //Se itera atraves de los MetodoPagoProducto respectivos para mapearlos con su respectiva informacion restante de MetodoPagoProductoJ
            for (int i = 0; i < metodoPagoProductoJItemsByProducto.Count(); i++)
            {
                //Mappeo de MetodoPago

                //Se obtiene el idMetodoPago de MetodoPagoProducto
                int idMetodoPago = metodoPagoProductoJItemsByProducto.ElementAt(i).idMetodoPago;

                //Se obtiene el MetodoPago especifico de MetodoPagoProducto
                MetodoPago metodoPagoItem = _metodoPagoRepo.GetById(idMetodoPago);

                //Se mappea el MetodoPago al MetodoPagoProductoJ correspondiente
                _mapper.Map(metodoPagoItem, metodoPagoProductoJItemsByProducto.ElementAt(i));
            }

            return metodoPagoProductoJItemsByProducto.ToList();
        }
        

            public void Create(MetodoPagoProductoJ metodoPagoProductoJ)
        {
            throw new NotImplementedException();
        }

        public void Update(MetodoPagoProductoJ metodoPagoProductoJ)
        {
            throw new NotImplementedException();
        }

        public void Delete(MetodoPagoProductoJ metodoPagoProductoJ)
        {
            throw new NotImplementedException();
        }
        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
        
    }
}
