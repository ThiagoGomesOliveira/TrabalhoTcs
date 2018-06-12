using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoTcs.Models
{
    public class Destino
    {
        public PdvFuncionario PdvFuncionario { get; set; }
        public TimeSpan Tempo { get; set; }
        public DateTime Data { get; set; }
        public Funcionario Funcionario { get; set; }
        public Endereco Endereco { get; set; }

        public Destino()
        {
            this.PdvFuncionario = new PdvFuncionario();
            this.Funcionario = new Funcionario();
            this.Endereco = new Endereco();
        }
    }
}