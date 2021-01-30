using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data.DataJ
{
    public class SqlCompradorJRepo : ICompradorJRepo
    {
        private readonly MercaditoTECContext _context;
        private readonly IEstudianteJRepo _estudianteJRepo;
        private readonly IMapper _mapper;

        public SqlCompradorJRepo(MercaditoTECContext context, IEstudianteJRepo estudianteJRepo, IMapper mapper)
        {
            _context = context;
            _estudianteJRepo = estudianteJRepo;
            _mapper = mapper;
        }

        public IEnumerable<CompradorJ> GetAll()
        {
            throw new NotImplementedException();
        }

        /*
         * Retorna un CompradorJ con la informacion de Comprador y EstudianteJ.
         */
        public CompradorJ GetById(int id)
        {
            //Mappeo de Comprador

            //Se retorna un Comprador especifico
            Comprador compradoritem = _context.Comprador.FirstOrDefault(c => c.idComprador == id);

            //Se mappea la parte de Comprador al CompradorJ
            CompradorJ compradorJItem = _mapper.Map<CompradorJ>(compradoritem);

            //Si el Comprador existe
            if (compradorJItem != null)
            {
                //Mappeo de EstudianteJ

                //Se obtiene el idEstudiante del CompradorJ
                int idEstudianteJ = compradorJItem.idEstudiante;

                //Se obtiene el EstudianteJ especifico del idEstudiante
                EstudianteJ estudianteJItem = _estudianteJRepo.GetById(idEstudianteJ);

                //Se mappea la EstudianteJ al CompradorJ
                _mapper.Map(estudianteJItem, compradorJItem);
            }

            return compradorJItem;
        }

        public CompradorJ GetByEstudiante(int idEstudiante)
        {
            throw new NotImplementedException();
        }

        public int GetId(int idEstudiante)
        {
            throw new NotImplementedException();
        }

        public void Create(CompradorJ compradorJ)
        {
            throw new NotImplementedException();
        }

        public void Update(CompradorJ compradorJ)
        {
            throw new NotImplementedException();
        }

        public void Delete(CompradorJ compradorJ)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

    }
}
