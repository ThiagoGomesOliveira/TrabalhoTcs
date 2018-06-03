using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoTcs.Models
{
    public class RotaDosFuncionarios
    {
        public int IdRota { get; set; }
        public string PdvFuncionario { get; set; }
        public string Funcionario { get; set; }
        public string Cidade{ get; set; }
        public string Rua { get; set; }
        public DateTime DataAtendimento { get; set; }


    }
}