using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoTcs.Models
{
    public class PdvFuncionario
    {
        public int IdPdvFuncionario { get; set; }
        public string NomeEmpresa { get; set; }
        public TimeSpan InicioAtendimento { get; set; }
        public TimeSpan FimAtendimento { get; set; }
        public TimeSpan TempoVisitacao { get; set; }
        public int IdEndereco { get; set; }
        public int IdFuncionario { get; set; }

    }
}