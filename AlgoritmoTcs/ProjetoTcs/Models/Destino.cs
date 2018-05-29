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


    }
}