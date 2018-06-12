using ProjetoTcs.Models;
using ProjetoTcs.RegraNegocios;
using ProjetoTcs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoTcs.Controllers
{
    public class PdvFuncionariosController : Controller
    {
      
        public PdvFuncionariosController()
        {
          
        }
      
       

        public ActionResult Log()
        {

            return RedirectToAction("Index","Destino"); 
        }

        // GET: PdvFuncionarios
        public ActionResult Index()
        {
            FuncionarioEnderecoRepository funcionario = new FuncionarioEnderecoRepository();
            FuncionarioEndereco func = funcionario.GetById(1);
            ViewBag.Nome = func.NomeFuncionario;
            ViewBag.Jornada = func.JornadaTrabalho;
            ViewBag.InicioJornada = func.InicioJornada;
            ViewBag.Cidade = func.Cidade;
            ViewBag.Rua = func.Rua;
            RestricoesPdvRepository Listar = new RestricoesPdvRepository();
            return View(Listar.GetAll());
        }
       
        public ActionResult  GerarRota()
        {
            Algoritmo algoritmo = new Algoritmo();
            algoritmo.VerificarDestino();
            return RedirectToAction("Index");
        }

   


        // GET: PdvFuncionarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PdvFuncionarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PdvFuncionarios/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PdvFuncionarios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PdvFuncionarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PdvFuncionarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PdvFuncionarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

      

       
    }
}
