using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoTcs.Models
{
    public class Funcionario
    {
        public int IDFuncionario { get; set; }
        public string Nome  { get; set; }
        public TimeSpan JornadaTrabalho { get; set; }
        public int IDEndereco { get; set; }
        public TimeSpan InicioJornada { get; set; }
    }
}