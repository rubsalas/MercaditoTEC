using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data.DataJ
{
    public class SqlVendedorJRepo : IVendedorJRepo
    {
        private readonly MercaditoTECContext _context;
        private readonly IVendedorRepo _vendedorRepo;
        private readonly IPersonaRepo _personaRepo;
        private readonly IEstudianteJRepo _estudianteJRepo;
        private readonly IMapper _mapper;

        public SqlVendedorJRepo(MercaditoTECContext context, IVendedorRepo vendedorRepo, IPersonaRepo personaRepo, IEstudianteJRepo estudianteJRepo,
            IMapper mapper)
        {
            _context = context;
            _vendedorRepo = vendedorRepo;
            _personaRepo = personaRepo;
            _estudianteJRepo = estudianteJRepo;
            _mapper = mapper;
        }

        /*
         * Retorna todos los VendedorJ con la informacion de Vendedor y EstudianteJ.
         */
        public IEnumerable<VendedorJ> GetAll()
        {
            //Mappeo de Vendedor

            //Se retorna una lista de todos los Vendedores
            IEnumerable<Vendedor> vendedorItems = _vendedorRepo.GetAll();

            //Se mappea la parte de Vendedor a VendedorJ
            IEnumerable<VendedorJ> vendedorJItems = _mapper.Map<IEnumerable<VendedorJ>>(vendedorItems);

            //Se itera atraves de todos los Vendedores para mapearlos con su respectiva informacion restante de VendedorJ
            for (int i = 0; i < vendedorJItems.Count(); i++)
            {
                //Mappeo de EstudianteJ

                //Se obtiene el idEstudiante de VendedorJ
                int idEstudiante = vendedorJItems.ElementAt(i).idEstudiante;

                //Se obtiene el EstudianteJ especifico del VendedorJ
                EstudianteJ estudianteJItem = _estudianteJRepo.GetById(idEstudiante);

                //Se mappea el EstudianteJ al VendedorJ correspondiente
                _mapper.Map(estudianteJItem, vendedorJItems.ElementAt(i));
            }

            return vendedorJItems.ToList();
        }

        /*
         * Retorna un VendedorJ con la informacion de Vendedor y EstudianteJ.
         */
        public VendedorJ GetById(int id)
        {
            //Mappeo de Vendedor

            //Se retorna un Vendedor especifico
            Vendedor vendedorItem = _context.Vendedor.FirstOrDefault(v => v.idVendedor == id);

            //Se mappea la parte de Vendedor al VendedorJ
            VendedorJ vendedorJItem = _mapper.Map<VendedorJ>(vendedorItem);

            //Si el vendedor existe
            if (vendedorJItem != null)
            {
                //Mappeo de EstudianteJ

                //Se obtiene el idEstudiante del VendedorJ
                int idEstudianteJ = vendedorJItem.idEstudiante;

                //Se obtiene el EstudianteJ especifico del idEstudiante
                EstudianteJ estudianteJItem = _estudianteJRepo.GetById(idEstudianteJ);

                //Se mappea la EstudianteJ al VendedorJ
                _mapper.Map(estudianteJItem, vendedorJItem);
            }

            return vendedorJItem;
        }

        public VendedorJ GetByEstudiante(int idEstudiante)
        {
            throw new NotImplementedException();
        }

        public int GetId(int idEstudiante)
        {
            return _vendedorRepo.GetId(idEstudiante);
        }

        public void Create(VendedorJ vendedorJ)
        {
            throw new NotImplementedException();
        }

        public void Update(VendedorJ vendedorJ)
        {
            throw new NotImplementedException();
        }

        public void Delete(VendedorJ vendedorJ)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
