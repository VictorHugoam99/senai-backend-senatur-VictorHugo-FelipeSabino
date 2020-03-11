using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class PacotesRepository : IPacotesRepository
    {
        SenaturContext ctx = new SenaturContext();

        public List<Pacotes> ListarPacotes()
        {
            return ctx.Pacotes.ToList();
        }

        public Pacotes BuscarPorId(int id)
        {
            return ctx.Pacotes.FirstOrDefault(p => p.IdPacote == id);
        }

        public void Cadastrar (Pacotes novoPacote)
        {
            ctx.Pacotes.Add(novoPacote);
            ctx.SaveChanges();
        }

        public void Atualizar(int id, Pacotes pacoteAtualizado)
        {
            Pacotes pacoteBuscado = ctx.Pacotes.Find(id);

            if (pacoteAtualizado.NomePacote != null)
            {
                pacoteBuscado.NomePacote = pacoteAtualizado.NomePacote;
            }
            if (pacoteAtualizado.NomeCidade != null)
            {
                pacoteBuscado.NomeCidade = pacoteAtualizado.NomeCidade;
            }
            if (pacoteAtualizado.Valor != pacoteBuscado.Valor)
            {
                pacoteBuscado.Valor = pacoteAtualizado.Valor;
            }
            if (pacoteAtualizado.Descricao != null)
            {
                pacoteBuscado.Descricao = pacoteAtualizado.Descricao;
            }
            if (pacoteAtualizado.DataVolta != null)
            {
                pacoteBuscado.DataVolta = pacoteAtualizado.DataVolta;
            }
            if (pacoteAtualizado.DataIda != null)
            {
                pacoteBuscado.DataIda = pacoteAtualizado.DataIda;
            }
            if (pacoteAtualizado.Ativo != null)
            {
                pacoteBuscado.Ativo = pacoteAtualizado.Ativo;
            }
            ctx.Pacotes.Update(pacoteBuscado);
            ctx.SaveChanges();
        }

        public List<Pacotes> ListarAtivos()
        {
            return ctx.Pacotes.ToList().FindAll(p => p.Ativo == true);
        }

        public List<Pacotes> ListarInativos()
        {
            return ctx.Pacotes.ToList().FindAll(p => p.Ativo == false);
        }

       public IEnumerable<Pacotes> ListarPorCidade(string cidade)
        {
            return ctx.Pacotes.ToList().Where(e => e.NomeCidade == cidade);
        }

        public List<Pacotes> ListarValorDesc()
        {
            return ctx.Pacotes.OrderByDescending(p => p.Valor).ToList();
        }

        public List<Pacotes> ListarvalorAsc()
        {
            return ctx.Pacotes.OrderBy(p => p.Valor).ToList();
        }

    }
}
