using ProjetoTcs.Models;
using ProjetoTcs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoTcs.Controllers
{
    public class RotaController : Controller
    {
        // GET: Rota
        public ActionResult Index()
        {
            RotaDosFunionariosRepository rotaFunc = new RotaDosFunionariosRepository();
            
            return View(rotaFunc.GetAll());
        }
        [HttpPost]
        public  ActionResult Post(FormCollection form)
            {
            
            var dataInicio = form["dataInicio"];
            var dataFim = form["dataFim"];
            
            
            RotaDosFunionariosRepository rotaFunc = new RotaDosFunionariosRepository();
            var teste = rotaFunc.BuscarRotas(Convert.ToDateTime(dataInicio),Convert.ToDateTime(dataFim));

         
            return View(teste);

        }


            // GET: Rota/Details/5
            public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rota/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rota/Create
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

        // GET: Rota/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rota/Edit/5
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

        // GET: Rota/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rota/Delete/5
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
