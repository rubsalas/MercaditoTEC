using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data.DataJ
{
    public class SqlUbicacionJRepo : IUbicacionJRepo
    {
        private readonly MercaditoTECContext _context;
        private readonly IUbicacionRepo _ubicacionRepo;
        private readonly ICantonRepo _cantonRepo;
        private readonly IProvinciaRepo _provinciaRepo;
        private readonly IMapper _mapper;

        public SqlUbicacionJRepo(MercaditoTECContext context, IUbicacionRepo ubicacionRepo, ICantonRepo cantonRepo, IProvinciaRepo provinciaRepo,
            IMapper mapper)
        {
            _context = context;
            _ubicacionRepo = ubicacionRepo;
            _cantonRepo = cantonRepo;
            _provinciaRepo = provinciaRepo;
            _mapper = mapper;
        }

        /*
         * Retorna todas las UbicacionJ con la informacion de Ubicacion, Canton y Provincia.
         */
        public IEnumerable<UbicacionJ> GetAll()
        {
            //Mappeo de Ubicacion

            //Se retorna una lista de todas las Ubicaciones
            IEnumerable<Ubicacion> ubicacionItems = _ubicacionRepo.GetAll();

            //Se mappea la parte de Ubicacion a UbicacionJ
            IEnumerable<UbicacionJ> ubicacionJItems = _mapper.Map<IEnumerable<UbicacionJ>>(ubicacionItems);

            //Se itera atraves de todos los ubicacionJItems para mapearlos con su respectiva informacion restante de Canton y Provincia
            for (int i = 0; i < ubicacionJItems.Count(); i++)
            {
                //Mappeo de Canton

                //Se obtiene el idCanton de Ubicacion
                int idCanton = ubicacionJItems.ElementAt(i).idCanton;

                //Se obtiene el Canton especifico de Ubicacion
                Canton cantonItem = _cantonRepo.GetById(idCanton);

                //Se mappea el nombre del canton a la UbicacionJ por ser nombres diferentes
                ubicacionJItems.ElementAt(i).canton = cantonItem.nombre;
                //Se mappea tambien el idProvincia
                ubicacionJItems.ElementAt(i).idProvincia = cantonItem.idProvincia;

                //Mappeo de Provincia

                //Se obtiene el idProvincia de Canton
                int idProvincia = cantonItem.idProvincia;

                //Para obtener la Provincia especifica de Canton
                Provincia provinciaItem = _provinciaRepo.GetById(idProvincia);

                //Se mappea el nombre de la provincia a la UbicacionJ por ser nombres diferentes
                ubicacionJItems.ElementAt(i).provincia = provinciaItem.nombre;
            }

            return ubicacionJItems.ToList();
        }

        public UbicacionJ GetByDistrito(string distrito)
        {
            throw new NotImplementedException();
        }

        /*
         * Retorna una UbicacionJ con la informacion de Ubicacion, Canton y Provincia.
         */
        public UbicacionJ GetById(int id)
        {
            //Mappeo de Ubicacion

            //Se retorna una Ubicacion especifica
            Ubicacion ubicacionItem = _ubicacionRepo.GetById(id);

            //Se mappea la parte de Ubicacion a UbicacionJ
            UbicacionJ ubicacionJItem = _mapper.Map<UbicacionJ>(ubicacionItem);

            if (ubicacionJItem != null)
            {
                //Mappeo de Canton

                //Se obtiene el idCanton de Ubicacion
                int idCanton = ubicacionJItem.idCanton;

                //Se obtiene el Canton especifico de Ubicacion
                Canton cantonItem = _cantonRepo.GetById(idCanton);

                //Se mappea el nombre del canton a la UbicacionJ por ser nombres diferentes
                ubicacionJItem.canton = cantonItem.nombre;
                //Se mappea tambien el idProvincia
                ubicacionJItem.idProvincia = cantonItem.idProvincia;

                //Mappeo de Provincia

                //Se obtiene el idProvincia de Canton
                int idProvincia = cantonItem.idProvincia;

                //Para obtener la Provincia especifica de Canton
                Provincia provinciaItem = _provinciaRepo.GetById(idProvincia);

                //Se mappea el nombre de la provincia a la UbicacionJ por ser nombres diferentes
                ubicacionJItem.provincia = provinciaItem.nombre;
            }

            return ubicacionJItem;
        }

        public void Create(UbicacionJ ubicacionJ)
        {
            throw new NotImplementedException();
        }

        public void Delete(UbicacionJ ubicacionJ)
        {
            throw new NotImplementedException();
        }

        public void Update(UbicacionJ ubicacionJ)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
   
    }
}
