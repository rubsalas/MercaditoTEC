using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data.DataJ
{
    public class SqlAdministradorJRepo : IAdministradorJRepo
    {
        private readonly MercaditoTECContext _context;
        private readonly IPersonaRepo _personaRepository;
        private readonly IAdministradorRepo _administradorRepo;
        private readonly IMapper _mapper;

        public SqlAdministradorJRepo(MercaditoTECContext context, IPersonaRepo personaRepository, IAdministradorRepo administradorRepo, IMapper mapper)
        {
            _context = context;
            _personaRepository = personaRepository;
            _administradorRepo = administradorRepo;
            _mapper = mapper;
        }

        public IEnumerable<AdministradorJ> GetAll()
        {
            //Mappeo de Administradores

            //Se retorna una lista de todos los Administradores
            var administradorItems = _administradorRepo.GetAll();

            //Se mappea la parte de Administrador al AdministradorJ
            IEnumerable<AdministradorJ> administradorJitems = _mapper.Map<IEnumerable<AdministradorJ>>(administradorItems);

            //Se itera atraves de todos los Administradores para mapearlos con su respectiva informacion de la Persona
            for (int i = 0; i < administradorItems.Count(); i++)
            {
                //Mappeo de Persona

                //Se obtiene el idPersona del Administrador
                int idPersonaI = administradorItems.ElementAt(i).idPersona;

                //Se obtiene la Persona especifica del Administrador
                Persona personaItem = _personaRepository.GetById(idPersonaI);

                //Se mappea la Persona al AdministradorJ correspondiente
                _mapper.Map(personaItem, administradorJitems.ElementAt(i));
            }

            return administradorJitems.ToList();
        }

        /*
         * Retorna el idAdministrador de un AdministradorJ especifico.
         */
        public AdministradorJ GetById(int id)
        {
            //Mappeo de Administradores

            //Se retorna un Administrador especifico
            var administradorItem = _administradorRepo.GetById(id);

            //Se mappea la parte de Administrador al AdministradorJ
            AdministradorJ administradorJitem = _mapper.Map<AdministradorJ>(administradorItem);

            //Si el Administrador existe
            if (administradorJitem != null)
            {
                //Mappeo de Persona

                //Se obtiene el idPersona del Administrador
                int idPersonaI = administradorItem.idPersona;

                //Se obtiene la Persona especifica del Administrador
                Persona personaItem = _personaRepository.GetById(idPersonaI);

                //Se mappea la Persona al AdministradorJ correspondiente
                _mapper.Map(personaItem, administradorJitem);
            }

            return administradorJitem;
        }

        /*
         * Retorna un solo AdministradorJ por su usuario.
         */
        public AdministradorJ GetByUsuario(string usuario)
        {
            //Mappeo de Administradores

            //Se retorna un Administrador especifico por su usuario
            var administradorItem = _administradorRepo.GetByUsuario(usuario);

            //Se mappea la parte de Administrador al AdministradorJ
            AdministradorJ administradorJitem = _mapper.Map<AdministradorJ>(administradorItem);

            //Si el Administrador existe
            if (administradorJitem != null)
            {
                //Mappeo de Persona

                //Se obtiene el idPersona del Administrador
                int idPersonaI = administradorItem.idPersona;

                //Se obtiene la Persona especifica del Administrador
                Persona personaItem = _personaRepository.GetById(idPersonaI);

                //Se mappea la Persona al AdministradorJ correspondiente
                _mapper.Map(personaItem, administradorJitem);
            }

            return administradorJitem;
        }

        /*
         * Retorna el idAdministrador de un Administrador especifico.
         */
        public int GetId(string usuario)
        {
            return _administradorRepo.GetId(usuario);
        }

        public void Create(AdministradorJ administradorJ)
        {
            throw new NotImplementedException();
        }

        public void Update(AdministradorJ administradorJ)
        {
            throw new NotImplementedException();
        }

        public void Delete(AdministradorJ administradorJ)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return true;
        }

    }
}
