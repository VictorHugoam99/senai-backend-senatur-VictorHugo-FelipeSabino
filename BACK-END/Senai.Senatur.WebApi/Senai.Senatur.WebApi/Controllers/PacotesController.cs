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

        [HttpGet("Ativos")]
        public IActionResult GetAtivos()
        {
            return Ok(_pacotesRepository.ListarAtivos());
        }

        [HttpGet("Inativos")]
        public IActionResult GetInativos()
        {
            return Ok(_pacotesRepository.ListarInativos());
        }

        [HttpGet("Cidades/{cidade}")]
        public IActionResult GetPorCidade(string cidade)
        {
            return Ok(_pacotesRepository.ListarPorCidade(cidade));
        }

        [HttpGet("Desc")]
        public IActionResult GetDesc()
        {
            return Ok(_pacotesRepository.ListarValorDesc());
        }

        [HttpGet("Asc")]
        public IActionResult GetAsc()
        {
            return Ok(_pacotesRepository.ListarvalorAsc());
        }

    }
}