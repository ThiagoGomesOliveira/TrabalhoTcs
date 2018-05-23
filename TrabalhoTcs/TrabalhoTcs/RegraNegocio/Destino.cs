using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using TrabalhoTcs.Dao;

namespace TrabalhoTcs.RegraNegocio
{
    public class Destino
    {
        public string EnderecoInicial { get; set; }
        public string EnderecoFinal { get; set; }
        public TimeSpan Tempo { get; set; }
        public List<Destino> Destinos { get; set; }

        public Destino()
        {
            FuncionarioDao funcionario = new FuncionarioDao();
            EmpresaDao empresa = new EmpresaDao();
            Destinos = new List<Destino>();
        }

        public void Teste()
        {
            EmpresaDao empresa = new EmpresaDao();
             empresa.BuscarIdPorEndereco(1);
            //DestinoRota("Rua Catharina Braun, 105 - Agua Verde, Blumenau", "R.Benjamin Constant, 2597 - Vila Nova, Blumenau – SC");
            
        }



        public void DestinoRota(string destinoInicial, string destinoFinal)
        {
            Destino destino = new Destino();
            destino.EnderecoInicial = destinoInicial;
            destino.EnderecoFinal = destinoFinal;
            destino.Tempo = Distancia(destinoInicial, destinoFinal) + TempoVisita(destinoFinal);
            Destinos.Add(destino);

        }

        public void PopularRota(string endereco)
        {
            Rota rota = new Rota();
            rota.EnderecoVisita = endereco;
            

        }


        public TimeSpan TempoVisita(string endereco)
        {

            TimeSpan tempo = new TimeSpan(1);

            if (endereco.Equals("R.Benjamin Constant, 2597 - Vila Nova, Blumenau – SC"))
            {
                var tsOneHour = new TimeSpan(2, 0, 0); 
                tempo = tempo.Add(tsOneHour);
                return tempo;
            }

            if (endereco.Equals("R.Sete de Setembro, 2883 - Velha, Blumenau – SC"))
            {
                var tsOneHour = new TimeSpan(1, 3, 0);
                tempo = tempo.Add(tsOneHour);
                return tempo;
            }

            if (endereco.Equals("R.Humberto de Campos, 77 - Velha, Blumenau – SC"))
            {

                var tsOneHour = new TimeSpan(2, 0, 0);
                tempo = tempo.Add(tsOneHour);
                return tempo;
            }

            if (endereco.Equals("R.Amazonas, 466 - Garcia, Blumenau – SC"))
            {
                var tsOneHour = new TimeSpan(2, 0, 0);
                tempo = tempo.Add(tsOneHour);
                return tempo;
            }

            return tempo;




        }



        public TimeSpan Distancia(string EnderecoInicial, string EnderecoFinal)
        {
            TimeSpan tempo = new TimeSpan(1);

            if (EnderecoInicial.Equals("Rua Catharina Braun, 105 - Agua Verde, Blumenau") && EnderecoFinal.Equals("R.Benjamin Constant, 2597 - Vila Nova, Blumenau – SC"))
            {
                var tsOneHour = new TimeSpan(0, 4, 0);
                tempo = tempo.Add(tsOneHour);
                return tempo;
            }

            if (EnderecoInicial.Equals("Rua Catharina Braun, 105 - Agua Verde, Blumenau") && EnderecoFinal.Equals("R.Sete de Setembro, 2883 - Velha, Blumenau – SC"))
            {
                var tsOneHour = new TimeSpan(0, 7, 0);
                tempo = tempo.Add(tsOneHour);
                return tempo;
            }
            if (EnderecoInicial.Equals("Rua Catharina Braun, 105 - Agua Verde, Blumenau") && EnderecoFinal.Equals("R.Humberto de Campos, 77 - Velha, Blumenau – SC"))
            {
                var tsOneHour = new TimeSpan(0, 7, 0);
                tempo = tempo.Add(tsOneHour);
                return tempo;
            }
            if (EnderecoInicial.Equals("Rua Catharina Braun, 105 - Agua Verde, Blumenau") && EnderecoFinal.Equals("R.Amazonas, 466 - Garcia, Blumenau – SC"))
            {
                var tsOneHour = new TimeSpan(0, 12, 0);
                tempo = tempo.Add(tsOneHour);
                return tempo;
            }
            if (EnderecoInicial.Equals("R.Benjamin Constant, 2597 - Vila Nova, Blumenau – SC") && EnderecoFinal.Equals("R.Sete de Setembro, 2883 - Velha, Blumenau – SC"))
            {
                var tsOneHour = new TimeSpan(0, 5, 0);
                tempo = tempo.Add(tsOneHour);
                return tempo;
            }
            if (EnderecoInicial.Equals("R.Benjamin Constant, 2597 - Vila Nova, Blumenau – SC") && EnderecoFinal.Equals("R.Humberto de Campos, 77 - Velha, Blumenau – SC"))
            {
                var tsOneHour = new TimeSpan(0, 5, 0);
                tempo = tempo.Add(tsOneHour);
                return tempo;
            }
            if (EnderecoInicial.Equals("R.Benjamin Constant, 2597 - Vila Nova, Blumenau – SC") && EnderecoFinal.Equals("R.Amazonas, 466 - Garcia, Blumenau – SC"))
            {
                var tsOneHour = new TimeSpan(0, 11, 0);
                tempo = tempo.Add(tsOneHour);
                return tempo;
            }
            if (EnderecoInicial.Equals("R.Sete de Setembro, 2883 - Velha, Blumenau – SC") && EnderecoFinal.Equals("R.Humberto de Campos, 77 - Velha, Blumenau – SC"))
            {
                var tsOneHour = new TimeSpan(0, 1, 0);
                tempo = tempo.Add(tsOneHour);
                return tempo;
            }
            if (EnderecoInicial.Equals("R.Sete de Setembro, 2883 - Velha, Blumenau – SC") && EnderecoFinal.Equals("R.Amazonas, 466 - Garcia, Blumenau – SC"))
            {
                var tsOneHour = new TimeSpan(0, 7, 0);
                tempo = tempo.Add(tsOneHour);
                return tempo;
            }
            var tempos = new TimeSpan(0, 0, 0);
            tempo = tempo.Add(tempos);
            return tempo;

        }


        public void PegarMenorTempo(List<Destino> destinos)
        {
            var destino = destinos.OrderBy(x => x.Tempo).ToList();
            string enderecoVisita = destino[0].EnderecoFinal.ToString();

           
        }



    }
}