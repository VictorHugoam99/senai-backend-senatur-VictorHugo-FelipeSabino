using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class PacotesController : ControllerBase
    {
        private IPacotesRepository _pacotesRepository;

        public PacotesController()
        {
            _pacotesRepository = new PacotesRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pacotesRepository.ListarPacotes());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_pacotesRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post (Pacotes novoPacote)
        {
            _pacotesRepository.Cadastrar(novoPacote);
            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Put (int id, Pacotes pacoteAtualizado)
        {
            _pacotesRepository.Atualizar(id, pacoteAtualizado);
            return StatusCode(204);
        }

        
    }
}