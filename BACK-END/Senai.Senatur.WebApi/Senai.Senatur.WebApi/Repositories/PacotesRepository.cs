using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.ViewModels;
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

        public void Atualizar(int id, PacotesViewModel pacoteAtualizado)
        {
            Pacotes pacoteBuscado = ctx.Pacotes.Find(id);

            if (pacoteAtualizado.NomePacote != null)
            {
                pacoteBuscado.NomePacote = pacoteAtualizado.NomePacote ?? pacoteBuscado.NomePacote;
            }
            if (pacoteAtualizado.NomeCidade != null)
            {
                pacoteBuscado.NomeCidade = pacoteAtualizado.NomeCidade ?? pacoteBuscado.NomeCidade;
            }
            if (pacoteAtualizado.Valor > 0)
            {
                pacoteBuscado.Valor = pacoteAtualizado.Valor;
            }
            else
            {
                ctx.Entry(pacoteAtualizado).Property(p => p.Valor).IsModified = false;
            }
            if (pacoteAtualizado.Descricao != null)
            {
                pacoteBuscado.Descricao = pacoteAtualizado.Descricao;
            }
            if (DateTime.Compare(pacoteAtualizado.DataVolta, DateTime.Now) >= 0)
            {
                pacoteBuscado.DataVolta = pacoteAtualizado.DataVolta;
            }
            else
            {
                ctx.Entry(pacoteAtualizado).Property(p => p.DataVolta).IsModified = false;
            }
            if (DateTime.Compare(pacoteAtualizado.DataIda, DateTime.Now) >= 0 )
            {
                pacoteBuscado.DataIda = pacoteAtualizado.DataIda;
            }
            else
            {
                ctx.Entry(pacoteAtualizado).Property(p => p.DataIda).IsModified = false;
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
