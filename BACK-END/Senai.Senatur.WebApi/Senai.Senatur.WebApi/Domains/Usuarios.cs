using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Senatur.WebApi.Domains
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        public int? IdTipoUsuario { get; set; }

        public TiposUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
