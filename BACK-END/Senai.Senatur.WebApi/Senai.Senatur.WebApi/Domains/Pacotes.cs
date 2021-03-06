﻿using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Senatur.WebApi.Domains
{
    public partial class Pacotes
    {
        public int IdPacote { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9áéíóúàèìòùâêîôûãõç''-'\s]{1,40}$", ErrorMessage =
           "Caracteres especiais não permitidos no nome do pacote.")]
        [Required]
        public string NomePacote { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9áéíóúàèìòùâêîôûãõç''-'\s]{1,40}$", ErrorMessage =
           "Caracteres especiais não permitidos na descrição.")]
        [Required]
        public string Descricao { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataIda { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataVolta { get; set; }

        [Required]
        public decimal Valor { get; set; }

        public bool? Ativo { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9áéíóúàèìòùâêîôûãõç''-'\s]{1,40}$", ErrorMessage =
           "Caracteres especiais não permitidos no nome da cidade.")]
        public string NomeCidade { get; set; }
    }
}
