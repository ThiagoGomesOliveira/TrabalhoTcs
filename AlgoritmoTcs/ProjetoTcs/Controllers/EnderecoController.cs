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
    public class EnderecoController : Controller
    {
        private EnderecoRepository repository = new EnderecoRepository();
        // GET: Endereco
        public ActionResult Index()
        {
            EnderecoRepository e = new EnderecoRepository();
            Algoritmo algoritmo = new Algoritmo();
            
           algoritmo.VerificarDestino();
            return View(repository.GetAll());
        }

        // GET: Endereco/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Endereco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Endereco/Create
        [HttpPost]
        public ActionResult Create(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                repository.Save(endereco);
            }
                    
              return View(endereco);
            
        }

        // GET: Endereco/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Endereco/Edit/5
        [HttpPost]
        public ActionResult Editar(int id)
        {
            var endereco = repository.GetById(id);

            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // GET: Endereco/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repository.DeleteById(id);
            return Json(repository.GetAll());
        }

        // POST: Endereco/Delete/5
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
