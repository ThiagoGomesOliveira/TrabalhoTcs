using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoTcs.Models
{
    public class FuncionarioEndereco
    {
        public string NomeFuncionario { get; set; }
        public TimeSpan JornadaTrabalho { get; set; }
        public TimeSpan InicioJornada { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }

    }
}