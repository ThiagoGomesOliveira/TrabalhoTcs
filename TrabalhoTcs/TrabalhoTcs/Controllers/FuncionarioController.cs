using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoTcs.Dao;
using TrabalhoTcs.RegraNegocio;

namespace TrabalhoTcs.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {

            FuncionarioDao funcionario = new FuncionarioDao();
            Destino destino = new Destino();
            destino.Teste();

            //var teste = funcionario.GetEnderecoFuncionario();

            var lista = funcionario.Listar();
            


            return View(lista);
        }
    }
}