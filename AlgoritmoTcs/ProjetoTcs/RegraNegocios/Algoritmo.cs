using ProjetoTcs.Models;
using ProjetoTcs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoTcs.RegraNegocios
{
    public class Algoritmo
    {
        private List<Destino> destinos = new List<Destino>();
        private TimeSpan TempoMaroto;
        private Destino mUltimoEndereco;
        private DateTime data = DateTime.Today;

        public void VerificarDestino()
        {

            RotaRepository repositorioRota = new RotaRepository();
            Funcionario funcionario = new Funcionario();
            PdvFuncionarioRepository pdvFuncionarioRepository = new PdvFuncionarioRepository();
            FuncionarioRepository funcRepositorio = new FuncionarioRepository();

            var listaFuncionario = funcRepositorio.GetAll();

            foreach (var item in listaFuncionario)
            {
                var lista = pdvFuncionarioRepository.GetPdvsId(item.IDFuncionario);
                if (lista.Count > 0)
                {
                    funcionario = Destino(item.IDFuncionario);
                    PopularDestino(pdvFuncionarioRepository.GetPdvsId(funcionario.IDFuncionario), funcionario);
                }
            }

        }


        public TimeSpan TempoVisita(string endereco)
        {

            if (endereco.Equals("R. Benjamin Constant, 2597 - Vila Nova"))
            {
                TimeSpan tempo = new TimeSpan(02, 00, 00);
                return tempo;
            }

            if (endereco.Equals("R. Sete de Setembro, 2883 - Velha"))
            {
                TimeSpan tempo = new TimeSpan(01, 30, 00);
                return tempo;
            }

            if (endereco.Equals("R. Humberto de Campos, 77 - Velha"))
            {
                TimeSpan tempo = new TimeSpan(02, 00, 00);
                return tempo;
            }

            if (endereco.Equals("R. Amazonas, 466 - Garcia"))
            {
                TimeSpan tempo = new TimeSpan(02, 00, 00);
                return tempo;
            }

            return TimeSpan.Zero;
        }


        public Funcionario Destino(int idFuncionario)
        {
            FuncionarioRepository repositorioFuncionario = new FuncionarioRepository();
            var funcionario = repositorioFuncionario.GetById(idFuncionario);
            TempoMaroto = funcionario.JornadaTrabalho;
            return funcionario;

        }

        public void PopularDestino(List<PdvFuncionario> pdvFuncionarios, Funcionario funcionario)
        {
            List<Rota> rotas = new List<Rota>();

            if (funcionario != null)
            {
                var idfuncionario = funcionario.IDEndereco;

                foreach (var t in pdvFuncionarios)
                {
                    Destino d = new Destino();
                    d.PdvFuncionario = t;
                    d.Tempo = Distance(DePara(idfuncionario), DePara(t.IdEndereco)) + TempoVisita(DePara(t.IdEndereco));
                    d.Data = data;
                    var jornada = ExisteTempoJornadaFuncionario(d.Tempo);
                    if (jornada)
                    {
                        var pdvPossivel = VerificarHorarioAtendimentoPdv(t, funcionario);
                        if (pdvPossivel != null)
                        {
                            destinos.Add(d);
                        }
                    }
                }
            }

            var lista = OrdenaRemoveLista(pdvFuncionarios, funcionario);

            if (lista == null || lista.Count <= 0)
            {
                return;
            }
            else
            {
                while (lista.FirstOrDefault() != null)
                {
                    VerificarEndereco(mUltimoEndereco, pdvFuncionarios, funcionario, data);
                    lista = OrdenaRemoveLista(lista, funcionario);
                }
                data = data.AddDays(1);
                PopularDestino(pdvFuncionarios, funcionario);
            }

        }

        public List<PdvFuncionario> OrdenaRemoveLista(List<PdvFuncionario> lista, Funcionario funcionario)
        {

            var a = destinos.OrderBy(x => x.Tempo).ToList();
            if (a.FirstOrDefault() != null)
            {
                mUltimoEndereco = a[0];
                AdicionarRota(funcionario.IDFuncionario, mUltimoEndereco.PdvFuncionario.IdPdvFuncionario, mUltimoEndereco.Data);
                lista.Remove(mUltimoEndereco.PdvFuncionario);
                destinos.Clear();
                return lista;
            }

            return null;
        }

        public List<Destino> VerificarEndereco(Destino pdvDestinoMelhor, List<PdvFuncionario> listaPdvFuncionario, Funcionario funcionario, DateTime data)
        {

            foreach (var t in listaPdvFuncionario)
            {
                Destino d = new Destino();
                d.PdvFuncionario = t;
                d.Tempo = Distance(DePara(pdvDestinoMelhor.PdvFuncionario.IdEndereco), DePara(t.IdEndereco)) + TempoVisita(DePara(t.IdEndereco));
                d.Data = data;
                var pdvPossivel = VerificarHorarioAtendimentoPdv(t, funcionario);
                if (pdvPossivel != null)
                {
                    destinos.Add(d);
                }

            }
            return destinos;
        }


        public Boolean ExisteTempoJornadaFuncionario(TimeSpan tempo)
        {

            if (tempo <= TempoMaroto)
            {
                TempoMaroto -= tempo;
                return true;
            }

            return false;
        }

        public void AdicionarRota(int IdFuncionario, int IdPdvFuncionario, DateTime data)
        {
            Rota rota = new Rota();
            RotaRepository rotaRepository = new RotaRepository();
            rota.IDFuncionario = IdFuncionario;
            rota.IDPdvFuncionario = IdPdvFuncionario;
            rota.DataAtendimento = data;
            rotaRepository.Save(rota);
        }


        public PdvFuncionario VerificarHorarioAtendimentoPdv(PdvFuncionario destino, Funcionario funcionario)
        {
            if (destino.InicioAtendimento <= funcionario.InicioJornada)
            {
                return destino;
            }
            return null;
        }

        public String DePara(int IdEndereco)
        {
            if (IdEndereco == 1)
            {
                return "R.Taquari,100 - Garcia";
            }

            if (IdEndereco == 2)
            {
                return "R. Benjamin Constant, 2597 - Vila Nova";
            }

            if (IdEndereco == 3)
            {
                return "R. Sete de Setembro, 2883 - Velha";
            }

            if (IdEndereco == 4)
            {
                return "R. Humberto de Campos, 77 - Velha";
            }

            if (IdEndereco == 5)
            {
                return "R. Amazonas, 466 - Garcia";
            }

            if (IdEndereco == 6)
            {
                return "R.Catharina Braun, 99 -Água Verde";
            }

            return null;
        }


        public TimeSpan Distance(string StartAddress, string EndAddress)
        {
            if (StartAddress.Equals("R.Catharina Braun, 99 -Água Verde") && EndAddress.Equals("R. Benjamin Constant, 2597 - Vila Nova"))
            {
                TimeSpan tempo = new TimeSpan(0, 04, 00);
                return tempo;
            }

            if (StartAddress.Equals("R.Catharina Braun, 99 -Água Verde") && EndAddress.Equals("R. Sete de Setembro, 2883 - Velha"))
            {
                TimeSpan tempo = new TimeSpan(0, 07, 00);
                return tempo;
            }
            if (StartAddress.Equals("R.Catharina Braun, 99 -Água Verde") && EndAddress.Equals("R. Humberto de Campos, 77 - Velha"))
            {
                TimeSpan tempo = new TimeSpan(0, 07, 00);
                return tempo;
            }
            if (StartAddress.Equals("R.Catharina Braun, 99 -Água Verde") && EndAddress.Equals("R. Amazonas, 466 - Garcia"))
            {
                TimeSpan tempo = new TimeSpan(0, 12, 00);
                return tempo;
            }
            if (StartAddress.Equals("R. Benjamin Constant, 2597 - Vila Nova") && EndAddress.Equals("R. Sete de Setembro, 2883 - Velha"))
            {
                TimeSpan tempo = new TimeSpan(0, 05, 00);
                return tempo;
            }
            if (StartAddress.Equals("R. Benjamin Constant, 2597 - Vila Nova") && EndAddress.Equals("R. Humberto de Campos, 77 - Velha"))
            {
                TimeSpan tempo = new TimeSpan(0, 07, 00);
                return tempo;
            }
            if (StartAddress.Equals("R. Benjamin Constant, 2597 - Vila Nova") && EndAddress.Equals("R. Amazonas, 466 - Garcia"))
            {
                TimeSpan tempo = new TimeSpan(0, 11, 00);
                return tempo;
            }
            if (StartAddress.Equals("R. Sete de Setembro, 2883 - Velha") && EndAddress.Equals("R. Humberto de Campos, 77 - Velha"))
            {
                TimeSpan tempo = new TimeSpan(0, 01, 00);
                return tempo;
            }
            if (StartAddress.Equals("R. Sete de Setembro, 2883 - Velha") && EndAddress.Equals("R. Amazonas, 466 - Garcia"))
            {
                TimeSpan tempo = new TimeSpan(0, 07, 00);
                return tempo;
            }

            TimeSpan t = new TimeSpan(0, 00, 00);
            return t;
        }



    }


}