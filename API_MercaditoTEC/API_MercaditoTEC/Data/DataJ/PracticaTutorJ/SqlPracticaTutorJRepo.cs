using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data.DataJ
{
    public class SqlPracticaTutorJRepo : IPracticaTutorJRepo
    {
        private readonly MercaditoTECContext _context;
        private readonly IPracticaTutorRepo _practicaTutorRepo;
        private readonly ITemaPracticaTutorRepo _temaPracticaTutorRepo;
        private readonly IMetodoPagoPracticaTutorJRepo _metodoPagoPracticaTutorJRepo;
        private readonly IMapper _mapper;

        public SqlPracticaTutorJRepo(MercaditoTECContext context, IPracticaTutorRepo practicaTutorRepo, ITemaPracticaTutorRepo temaPracticaTutorRepo,
            IMetodoPagoPracticaTutorJRepo metodoPagoPracticaTutorJRepo, IMapper mapper)
        {
            _context = context;
            _practicaTutorRepo = practicaTutorRepo;
            _temaPracticaTutorRepo = temaPracticaTutorRepo;
            _metodoPagoPracticaTutorJRepo = metodoPagoPracticaTutorJRepo;
            _mapper = mapper;
        }

        /*
         * Retorna todos las PracticaTutorJ de la base de datos.
         */
        public IEnumerable<PracticaTutorJ> GetAll()
        {
            //Mappeo de PracticaTutor

            //Se retorna una lista de todas las PracticaTutor
            IEnumerable<PracticaTutor> practicaTutorItems = _practicaTutorRepo.GetAll();

            //Se mappea la parte de PracticaTutor a PracticaTutorJ
            IEnumerable<PracticaTutorJ> practicaTutorJItems = _mapper.Map<IEnumerable<PracticaTutorJ>>(practicaTutorItems);

            //Se itera atraves de todas las PracticaTutor para mapearlos con su respectiva informacion restante de PracticaTutorJ
            for (int i = 0; i < practicaTutorJItems.Count(); i++)
            {
                //Mappeo de TemaPracticaTutor

                //Se obtiene el idPracticaTutor de la PracticaTutorJ
                int idPracticaTutor = practicaTutorJItems.ElementAt(i).idPracticaTutor;

                //Se obtiene la lista de TemaPracticaTutor
                IEnumerable<TemaPracticaTutor> temasI = _temaPracticaTutorRepo.GetByPracticaTutor(idPracticaTutor);

                //Se mappea manualmente los TemaPracticaTutor a la PracticaTutorJ correspondiente
                practicaTutorJItems.ElementAt(i).temas = temasI;

                //Mappeo MetodoPagoPracticaTutor

                //Se obtienen los MetodoPagoPracticaTutorJ
                IEnumerable<MetodoPagoPracticaTutorJ> metodoPagoPracticaTutorJItems = _metodoPagoPracticaTutorJRepo.GetByPracticaTutor(practicaTutorJItems.ElementAt(i).idPracticaTutor);

                //Se mappea manualmente el MetodoPagoPracticaTutorJ a la PracticaTutorJ correspondiente
                practicaTutorJItems.ElementAt(i).metodosPago = metodoPagoPracticaTutorJItems;

            }

            return practicaTutorJItems;
        }

        /*
         * Retorna un solo PracticaTutorJ por su id.
         */
        public PracticaTutorJ GetById(int id)
        {
            //Mappeo de PracticaTutor

            //Se retorna una PracticaTutor con el id indicado
            PracticaTutor practicaTutorItem = _practicaTutorRepo.GetById(id);

            //Se mappea la parte de PracticaTutor a PracticaTutorJ
            PracticaTutorJ practicaTutorJItem = _mapper.Map<PracticaTutorJ>(practicaTutorItem);

            //Si la PracticaTutorJ existe
            if (practicaTutorJItem != null)
            {
                //Mappeo de TemaPracticaTutor

                //Se obtiene el idPracticaTutor de la PracticaTutorJ
                int idPracticaTutor = practicaTutorJItem.idPracticaTutor;

                //Se obtiene la lista de TemaPracticaTutor
                IEnumerable<TemaPracticaTutor> temasI = _temaPracticaTutorRepo.GetByPracticaTutor(idPracticaTutor);

                //Se mappea manualmente los TemaPracticaTutor a la PracticaTutor correspondiente
                practicaTutorJItem.temas = temasI;

                //Mappeo MetodoPagoPracticaTutor

                //Se obtienen los MetodoPagoPracticaTutorJ
                IEnumerable<MetodoPagoPracticaTutorJ> metodoPagoPracticaTutorJItems = _metodoPagoPracticaTutorJRepo.GetByPracticaTutor(practicaTutorJItem.idPracticaTutor);

                //Se mappea manualmente el MetodoPagoPracticaTutorJ a la PracticaTutorJ correspondiente
                practicaTutorJItem.metodosPago = metodoPagoPracticaTutorJItems;
            }

            return practicaTutorJItem;
        }

        public PracticaTutorJ GetByNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        /*
         * Retorna una lista de PracticaTutorJ de un unico CursoTutor indicado.
         */
        public IEnumerable<PracticaTutorJ> GetByCursoTutor(int idCursoTutor)
        {
            //Mappeo de PracticaTutor

            //Se retorna una lista de todas las PracticaTutor
            IEnumerable<PracticaTutor> practicaTutorItems = _practicaTutorRepo.GetByCursoTutor(idCursoTutor);

            //Se mappea la parte de PracticaTutor a PracticaTutorJ
            IEnumerable<PracticaTutorJ> practicaTutorJItems = _mapper.Map<IEnumerable<PracticaTutorJ>>(practicaTutorItems);

            //Se itera atraves de todas las PracticaTutor para mapearlos con su respectiva informacion restante de PracticaTutorJ
            for (int i = 0; i < practicaTutorJItems.Count(); i++)
            {
                //Mappeo de TemaPracticaTutor

                //Se obtiene el idPracticaTutor de la PracticaTutorJ
                int idPracticaTutor = practicaTutorJItems.ElementAt(i).idPracticaTutor;

                //Se obtiene la lista de TemaPracticaTutor
                IEnumerable<TemaPracticaTutor> temasI = _temaPracticaTutorRepo.GetByPracticaTutor(idPracticaTutor);

                //Se mappea manualmente los TemaPracticaTutor a la PracticaTutor correspondiente
                practicaTutorJItems.ElementAt(i).temas = temasI;

                //Mappeo MetodoPagoPracticaTutor

                //Se obtienen los MetodoPagoPracticaTutorJ
                IEnumerable<MetodoPagoPracticaTutorJ> metodoPagoPracticaTutorJItems = _metodoPagoPracticaTutorJRepo.GetByPracticaTutor(practicaTutorJItems.ElementAt(i).idPracticaTutor);

                //Se mappea manualmente el MetodoPagoPracticaTutorJ a la PracticaTutorJ correspondiente
                practicaTutorJItems.ElementAt(i).metodosPago = metodoPagoPracticaTutorJItems;
            }

            return practicaTutorJItems;
        }

        public void Create(PracticaTutorJ practicaTutorJ)
        {
            throw new NotImplementedException();
        }

        public void Update(PracticaTutorJ practicaTutorJ)
        {
            throw new NotImplementedException();
        }

        public void Delete(PracticaTutorJ practicaTutorJ)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
