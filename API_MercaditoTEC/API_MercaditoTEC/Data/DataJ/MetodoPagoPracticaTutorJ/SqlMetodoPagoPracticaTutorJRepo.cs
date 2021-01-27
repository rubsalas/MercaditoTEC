using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data.DataJ
{
    public class SqlMetodoPagoPracticaTutorJRepo : IMetodoPagoPracticaTutorJRepo
    {
        private readonly MercaditoTECContext _context;
        private readonly IMetodoPagoPracticaTutorRepo _metodoPagoPracticaTutor;
        private readonly IMetodoPagoRepo _metodoPagoRepo;
        private readonly IMapper _mapper;

        public SqlMetodoPagoPracticaTutorJRepo(MercaditoTECContext context, IMetodoPagoPracticaTutorRepo metodoPagoPracticaTutor,
            IMetodoPagoRepo metodoPagoRepo, IMapper mapper)
        {
            _context = context;
            _metodoPagoPracticaTutor = metodoPagoPracticaTutor;
            _metodoPagoRepo = metodoPagoRepo;
            _mapper = mapper;
        }

        /*
         * Retorna todos los MetodoPagoPracticaTutor de la base de datos.
         */
        public IEnumerable<MetodoPagoPracticaTutorJ> GetAll()
        {
            //Mappeo de MetodoPagoPracticaTutor

            //Se retorna una lista de todos los MetodoPagoPracticaTutor
            IEnumerable<MetodoPagoPracticaTutor> metodoPagoPracticaTutorItems = _metodoPagoPracticaTutor.GetAll();

            //Se mappea la parte de MetodoPagoPracticaTutor a MetodoPagoPracticaTutorJ
            IEnumerable<MetodoPagoPracticaTutorJ> metodoPagoPracticaTutorJItems = _mapper.Map<IEnumerable<MetodoPagoPracticaTutorJ>>(metodoPagoPracticaTutorItems);

            //Se itera atraves de todos los MetodoPagoPracticaTutor para mapearlos con su respectiva informacion restante de MetodoPagoPracticaTutorJ
            for (int i = 0; i < metodoPagoPracticaTutorJItems.Count(); i++)
            {
                //Mappeo de MetodoPago

                //Se obtiene el idMetodoPago de MetodoPagoProducto
                int idMetodoPago = metodoPagoPracticaTutorJItems.ElementAt(i).idMetodoPago;

                //Se obtiene el MetodoPago especifico de MetodoPagoProducto
                MetodoPago metodoPagoItem = _metodoPagoRepo.GetById(idMetodoPago);

                //Se mappea el MetodoPago al MetodoPagoProductoJ correspondiente
                _mapper.Map(metodoPagoItem, metodoPagoPracticaTutorJItems.ElementAt(i));
            }

            return metodoPagoPracticaTutorJItems;
        }

        public MetodoPagoPracticaTutorJ GetById(int id)
        {
            throw new NotImplementedException();
        }

        /*
         * Retorna una lista de MetodoPagoPracticaTutorJ de una unica PracticaTutor indicada.
         */
        public IEnumerable<MetodoPagoPracticaTutorJ> GetByPracticaTutor(int idPracticaTutor)
        {
            //Mappeo de MetodoPagoPracticaTutor

            //Se retorna una lista de todos los MetodoPagoPracticaTutor con el idPracticaTutor indicado
            IEnumerable<MetodoPagoPracticaTutor> metodoPagoPracticaTutorItems = _metodoPagoPracticaTutor.GetByPracticaTutor(idPracticaTutor);

            //Se mappea la parte de MetodoPagoPracticaTutor a MetodoPagoPracticaTutorJ
            IEnumerable<MetodoPagoPracticaTutorJ> metodoPagoPracticaTutorJItems = _mapper.Map<IEnumerable<MetodoPagoPracticaTutorJ>>(metodoPagoPracticaTutorItems);

            //Se itera atraves de todos los MetodoPagoPracticaTutor para mapearlos con su respectiva informacion restante de MetodoPagoPracticaTutorJ
            for (int i = 0; i < metodoPagoPracticaTutorJItems.Count(); i++)
            {
                //Mappeo de MetodoPago

                //Se obtiene el idMetodoPago de MetodoPagoProducto
                int idMetodoPago = metodoPagoPracticaTutorJItems.ElementAt(i).idMetodoPago;

                //Se obtiene el MetodoPago especifico de MetodoPagoProducto
                MetodoPago metodoPagoItem = _metodoPagoRepo.GetById(idMetodoPago);

                //Se mappea el MetodoPago al MetodoPagoProductoJ correspondiente
                _mapper.Map(metodoPagoItem, metodoPagoPracticaTutorJItems.ElementAt(i));
            }

            return metodoPagoPracticaTutorJItems;
        }

        /*
         * Ingresa a la base de datos un nuevo MetodoPagoPracticaTutor.
         */
        public void Create(MetodoPagoPracticaTutorJ metodoPagoPracticaTutorJ)
        {
            //Se verifica si el ingresado no es nulo
            if (metodoPagoPracticaTutorJ == null)
            {
                throw new ArgumentNullException(nameof(metodoPagoPracticaTutorJ));
            }

            //Mappea el MetodoPagoPracticaTutorJ obtenido a un Modelo MetodoPagoPracticaTutor
            var metodoPagoPracticaTutorModel = _mapper.Map<MetodoPagoPracticaTutor>(metodoPagoPracticaTutorJ);

            //Crea el nuevo en la base de datos
            _metodoPagoPracticaTutor.Create(metodoPagoPracticaTutorModel);
            //Guarda los cambios en la tabla en la base de datos
            _metodoPagoPracticaTutor.SaveChanges();
        }

        public void Update(MetodoPagoPracticaTutorJ metodoPagoPracticaTutorJ)
        {
            throw new NotImplementedException();
        }

        public void Delete(MetodoPagoPracticaTutorJ metodoPagoPracticaTutorJ)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return true;
        }

    }
}
