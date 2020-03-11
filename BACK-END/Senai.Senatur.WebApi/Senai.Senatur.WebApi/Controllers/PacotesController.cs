 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Lista todos os pacotes
        /// </summary>
        /// <returns> 
        /// Retorna uma lista de pacotes e um status code 200 - Ok
        /// </returns>
        /// <response code="200">Se a lista for acessada com sucesso</response>
        /// <response code="400">Erro em alguma parte da requisição</response>
        /// <response code="401">Se o usuário não estiver logado</response>
        /// <response code="403">Se o usuário não tiver permissão para tal ação</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public IActionResult Get()
        {
            return Ok(_pacotesRepository.ListarPacotes());
        }

        /// <summary>
        /// Busca um pacote através do seu ID
        /// </summary>
        /// <param name="id">ID do pacote que será buscado</param>
        /// <returns>Retorna um pacote buscado ou NotFound caso nenhum seja encontrado</returns>
        /// <response code="200">Se a lista for acessada com sucesso</response>
        /// <response code="400">Erro em alguma parte da requisição</response>
        /// <response code="401">Se o usuário não estiver logado</response>
        /// <response code="403">Se o usuário não tiver permissão para tal ação</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public IActionResult GetById(int id)
        {
            return Ok(_pacotesRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo pacote
        /// </summary>
        /// <param name="novoPacote">Objeto novoPacote que será cadastrado</param>
        /// <response code="201">Se o Pacote for cadastrado com sucesso</response>
        /// <response code="400">Erro em alguma parte da requisição</response>
        /// <response code="401">Se o usuário não estiver logado</response>
        /// <response code="403">Se o usuário não tiver permissão para tal ação</response>
        [HttpPost]
        [Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Post (Pacotes novoPacote)
        {
            _pacotesRepository.Cadastrar(novoPacote);
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um pacote existente
        /// </summary>
        /// <param name="id">ID do pacote que será alterado</param>
        /// <param name="pacoteAtualizado">Objeto PacoteAtualizado que será alterado</param>
        /// <response code="200">Se o Pacote for atualizado com sucesso</response>
        /// <response code="400">Erro em alguma parte da requisição</response>
        /// <response code="401">Se o usuário não estiver logado</response>
        /// <response code="403">Se o usuário não tiver permissão para tal ação</response>
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public IActionResult Put (int id, Pacotes pacoteAtualizado)
        {
            _pacotesRepository.Atualizar(id, pacoteAtualizado);
            return StatusCode(204);
        }

        
    }
}