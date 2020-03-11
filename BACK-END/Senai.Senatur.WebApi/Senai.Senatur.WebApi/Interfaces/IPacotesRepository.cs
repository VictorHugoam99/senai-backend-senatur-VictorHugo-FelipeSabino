using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IPacotesRepository
    {
        List<Pacotes> ListarPacotes();

        Pacotes BuscarPorId(int id);

        void Cadastrar(Pacotes novoPacote);

        void Atualizar(int id, Pacotes pacoteAtualizado);

        List<Pacotes> ListarAtivos();

        List<Pacotes> ListarInativos();

        IEnumerable<Pacotes> ListarPorCidade(string cidade);

        List<Pacotes> ListarValorDesc();

        List<Pacotes> ListarvalorAsc();


    }
}
