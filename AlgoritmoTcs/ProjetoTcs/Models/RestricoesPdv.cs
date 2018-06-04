using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoTcs.Models
{
    public class RestricoesPdv
    {
        public int IdPdvFuncionario { get; set; }
        public string NomeEmpresa { get; set; }
        public TimeSpan InicioAtendimento { get; set; }
        public TimeSpan FimAtendimento { get; set; }
        public TimeSpan TempoVisitacao { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
    }
}