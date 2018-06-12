using ProjetoTcs.Models;
using ProjetoTcs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ProjetoTcs.Controllers
{
    public class DestinoController : Controller
    {
        // GET: Destino
        public ActionResult Index()
        {
            DestinoRepository destino = new DestinoRepository();
            FuncionarioEnderecoRepository funcionario = new FuncionarioEnderecoRepository();
            FuncionarioEndereco func = funcionario.GetById(1);
            ViewBag.Nome = func.NomeFuncionario;
            ViewBag.Cidade = func.Cidade;
            ViewBag.Rua = func.Rua;
            return View(destino.GetAll());
        }

        // GET: Destino/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Destino/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Destino/Create
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

        // GET: Destino/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Destino/Edit/5
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

        // GET: Destino/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Destino/Delete/5
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
