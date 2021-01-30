using API_MercaditoTEC.Data;
using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ.ProductoJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API_MercaditoTEC.Controllers.ControllersJ
{
    //[Route("api/ofertasLaboralesJ")]
    [ApiController]
    public class OfertasLaboralesJController
    {
        private readonly IOfertaLaboralJRepo _repository;
        private readonly IMapper _mapper;

        public OfertasLaboralesJController(IOfertaLaboralJRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
