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
        private readonly IEstudianteJRepo _estudianteJRepo;
        private readonly IMapper _mapper;

        public SqlVendedorJRepo(MercaditoTECContext context, IVendedorRepo vendedorRepo, IEstudianteJRepo estudianteJRepo,
            IMapper mapper)
        {
            _context = context;
            _vendedorRepo = vendedorRepo;
            _estudianteJRepo = estudianteJRepo;
            _mapper = mapper;
        }

        /*
         * Retorna todos los VendedorJ con la informacion de Vendedor y EstudianteJ.
         * 
         * ESTO PODRIA FALLAR SI NO ESTAN TODOS SEGUIDOS :(
         */
        public IEnumerable<VendedorJ> GetAll()
        {
            //Crea una lista de VendedorJ
            List<VendedorJ> vendedoresJ = new List<VendedorJ>();

            //Asigna el primer valor de la lista con el primer vendedor
            vendedoresJ.Add(GetById(1));

            //Se usara esta variable para eliminar el ultimo valor de la lista
            int n = 1;

            //Se iran agregando los vendedores hasta que no se encuentren mas en la base de datos
            for (int i = 0; vendedoresJ[i] != null; i++)
            {
                //Se asigna el siguiente espacio de la lsita con el siguiente VendedorJ
                vendedoresJ.Add(GetById(n+1));

                //Se actualiza la variable n
                n = n + 1;
            }

            //Se elimina el ultimo VendedorJ, que es null
            vendedoresJ.RemoveAt(n-1);

            //Se retorna la lista de VendedoresJ
            return vendedoresJ;
        }

        /*
         * Retorna un VendedorJ con la informacion de Vendedor y EstudianteJ.
         */
        public VendedorJ GetById(int id)
        {
            //Mappeo de Vendedor

            //Se retorna un Estudiante especifico
            Vendedor vendedorItem = _context.Vendedor.FirstOrDefault(v => v.idVendedor == id);

            //Se mappea la parte de Vendedor al VendedorJ
            VendedorJ vendedorJItem = _mapper.Map<VendedorJ>(vendedorItem);

            //Si el vendedor existe
            if (vendedorJItem != null)
            {
                //Mappeo de EstudianteJ

                //Se obtiene el idEstudiante del EstudianteJ
                int idEstudianteJ = vendedorJItem.idEstudiante;

                //Se obtiene el EstudianteJ especifico del idEstudiante
                EstudianteJ estudianteJItem = _estudianteJRepo.GetById(idEstudianteJ);

                //Se mappea la Persona al EstudianteJ
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
