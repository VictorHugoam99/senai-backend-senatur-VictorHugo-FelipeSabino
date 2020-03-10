using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        SenaturContext ctx = new SenaturContext();

        public Usuarios BuscarPorEmailSenha(string email, string senha)
        {
            Usuarios usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            return usuario;
        }

        public List<Usuarios> Listar()
        {
            return ctx.Usuarios.Include(e => e.IdTipoUsuarioNavigation).ToList();
        }
    }
}
