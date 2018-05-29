using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoTcs.Models
{
    public class Rota
    {
        public int IDRota { get; set; }
        public int IDPdvFuncionario { get; set; }
        public int IDFuncionario { get; set; }
        public DateTime DataAtendimento { get; set; }


    }
}