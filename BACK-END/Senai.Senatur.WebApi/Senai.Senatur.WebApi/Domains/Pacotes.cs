using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Senatur.WebApi.Domains
{
    public partial class Pacotes
    {
        public int IdPacote { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9áéíóúàèìòùâêîôûãõç''-'\s]{1,40}$", ErrorMessage =
           "Números e caracteres especiais não são permitidos no nome do pacote.")]
        public string NomePacote { get; set; }

        public string Descricao { get; set; }

        [Required]
        public DateTime DataIda { get; set; }

        [Required]
        public DateTime DataVolta { get; set; }

        [Required]
        public decimal Valor { get; set; }

        public bool? Ativo { get; set; }

        public string NomeCidade { get; set; }
    }
}
