using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces ("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1")]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository _usuariosRepository;

        public UsuariosController()
        {
            _usuariosRepository = new UsuariosRepository();
        }

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Retorna uma lista de usuários e um status code 200 - Ok</returns>
        /// dominio/api/Usuarios
        /// <response code="200">Lista retornada com sucesso</response>
        /// <response code="400">Erro em alguma parte da requisição</response>
        /// <response code="401">Se o usuário não estiver logado</response>
        /// <response code="403">Se o usuário não tiver permissão para tal ação</response>
        [Authorize(Roles = "1")]    // Somente o tipo de usuário 1 (administrador) pode acessar o endpoint
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public IActionResult Get()
        {
            return Ok(_usuariosRepository.Listar());
        }
            
    }
}