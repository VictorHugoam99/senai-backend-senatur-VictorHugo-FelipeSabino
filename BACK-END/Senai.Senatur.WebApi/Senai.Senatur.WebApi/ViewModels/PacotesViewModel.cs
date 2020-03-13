using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.ViewModels
{
    public class PacotesViewModel
    {
        public int IdPacote { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9áéíóúàèìòùâêîôûãõç''-'\s]{1,40}$", ErrorMessage =
           "Caracteres especiais não permitidos no nome do pacote.")]
        public string NomePacote { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9áéíóúàèìòùâêîôûãõç''-'\s]{1,40}$", ErrorMessage =
           "Caracteres especiais não permitidos na descrição.")]
        public string Descricao { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataIda { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataVolta { get; set; }

        public decimal Valor { get; set; }

        public bool? Ativo { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9áéíóúàèìòùâêîôûãõç''-'\s]{1,40}$", ErrorMessage =
           "Caracteres especiais não permitidos no nome da cidade.")]
        public string NomeCidade { get; set; }
    }
}
