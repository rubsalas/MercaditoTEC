using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data.DataJ
{
    public class SqlUbicacionProductoJRepo : IUbicacionProductoJRepo
    {
        private readonly MercaditoTECContext _context;
        private readonly IUbicacionProductoRepo _ubicacionProductoRepo;
        private readonly IUbicacionJRepo _ubicacionJRepo;
        private readonly IMapper _mapper;

        public SqlUbicacionProductoJRepo(MercaditoTECContext context, IUbicacionProductoRepo ubicacionProductoRepo, IUbicacionJRepo ubicacionJRepo, IMapper mapper)
        {
            _context = context;
            _ubicacionProductoRepo = ubicacionProductoRepo;
            _ubicacionJRepo = ubicacionJRepo;
            _mapper = mapper;
        }

        public IEnumerable<UbicacionProductoJ> GetAll()
        {
            //Mappeo de UbicacionProducto

            //Se retorna una lista de todas las UbicacionesProductos
            IEnumerable<UbicacionProducto> ubicacionProductoItems = _ubicacionProductoRepo.GetAll();

            //Se mappea la parte de UbicacionProducto a UbicacionProductoJ
            IEnumerable<UbicacionProductoJ> ubicacionProductoJItems = _mapper.Map<IEnumerable<UbicacionProductoJ>>(ubicacionProductoItems);

            //Se itera atraves de todos los UbicacionProductoJ para mapearlos con su respectiva informacion restante de UbicacionJ
            for (int i = 0; i < ubicacionProductoJItems.Count(); i++)
            {
                //Mappeo de UbicacionJ

                //Se obtiene el idUbicacion de UbicacionProductoJ
                int idUbicacion = ubicacionProductoJItems.ElementAt(i).idUbicacion;

                //Se obtiene la UbicacionJ especifica
                UbicacionJ ubicacionJItem = _ubicacionJRepo.GetById(idUbicacion);

                //Se mappea la UbicacionJ a la UbicacionProductoJ
                ubicacionProductoJItems.ElementAt(i).ubicacion = ubicacionJItem;
            }

            return ubicacionProductoJItems;
        }

        /*
         * Retorna una UbicacionProductoJ con la informacion de UbicacionProducto y UbicacionJ.
         */
        public UbicacionProductoJ GetById(int id)
        {
            //Mappeo de UbicacionProducto

            //Se retorna una lista de todas las UbicacionesProductos
            UbicacionProducto ubicacionProductoItem = _ubicacionProductoRepo.GetById(id);

            //Se mappea la parte de UbicacionProducto a UbicacionProductoJ
            UbicacionProductoJ ubicacionProductoJItem = _mapper.Map<UbicacionProductoJ>(ubicacionProductoItem);

            if (ubicacionProductoJItem != null)
            {
                //Mappeo de UbicacionJ

                //Se obtiene el idUbicacion de UbicacionProductoJ
                int idUbicacion = ubicacionProductoJItem.idUbicacion;

                //Se obtiene la UbicacionJ especifica
                UbicacionJ ubicacionJItem = _ubicacionJRepo.GetById(idUbicacion);

                //Se mappea la UbicacionJ a la UbicacionProductoJ
                ubicacionProductoJItem.ubicacion = ubicacionJItem;
            }

            return ubicacionProductoJItem;
        }

        /*
         * Retorna una lista de UbicacionProductoJ de un unico Producto indicado.
         */
        public IEnumerable<UbicacionProductoJ> GetByProducto(int idProducto)
        {
            //Mappeo de UbicacionProducto

            //Se retorna una lista de todas las UbicacionesProductos con el idProducto indicado
            IEnumerable<UbicacionProducto> ubicacionProductoItemsByProducto = _ubicacionProductoRepo.GetByProducto(idProducto);

            //Se mappea la parte de UbicacionProducto a UbicacionProductoJ
            IEnumerable<UbicacionProductoJ> ubicacionProductoJItemsByProducto = _mapper.Map<IEnumerable<UbicacionProductoJ>>(ubicacionProductoItemsByProducto);

            //Se itera atraves de los UbicacionProductoJ respectivos al Producto para mapearlos con su respectiva informacion restante de UbicacionJ
            for (int i = 0; i < ubicacionProductoJItemsByProducto.Count(); i++)
            {
                //Mappeo de UbicacionJ

                //Se obtiene el idUbicacion de UbicacionProductoJ
                int idUbicacion = ubicacionProductoJItemsByProducto.ElementAt(i).idUbicacion;

                //Se obtiene la UbicacionJ especifica
                UbicacionJ ubicacionJItem = _ubicacionJRepo.GetById(idUbicacion);

                //Se mappea la UbicacionJ a la UbicacionProductoJ
                ubicacionProductoJItemsByProducto.ElementAt(i).ubicacion = ubicacionJItem;
            }

            return ubicacionProductoJItemsByProducto;
        }

        public void Create(UbicacionProductoJ ubicacionProductoJ)
        {
            throw new NotImplementedException();
        }

        public void Update(UbicacionProductoJ ubicacionProductoJ)
        {
            throw new NotImplementedException();
        }

        public void Delete(UbicacionProductoJ ubicacionProductoJ)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        
    }
}
