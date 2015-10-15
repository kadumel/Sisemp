using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepositorioEF;
using Contexto;
using Contexto.Models;
using WebGrease.Css.Extensions;

namespace Sisemp.Controllers
{
    public class EmpController : Controller
    {

        private readonly ApEmp appEmp;

        public EmpController()
        {
            appEmp = empCon.ApEmpCon();
        }

        public ActionResult ListEmp()
        {
            var listaEmp = appEmp.ListarTodos();
            return View(listaEmp); 
        }
        
        //public ActionResult ListEmp(string nome)
        //{
        //    var listaEmp = appEmp.ListarTodos();
        //    listaEmp.Where(x => x.NOME.Contains(nome));
        //    return View(listaEmp);
        //}

        public ActionResult CriarEmp()
        {

            return View();
        }

        [HttpPost]       
        public ActionResult CriarEmp(EMP emp)
        {
            if (ModelState.IsValid)
            {
                appEmp.Salvar(emp);
                return RedirectToAction("ListEmp");
            }
            return View(emp);
        }

        public ActionResult EditarEmp(string id)
        {
            var emp = appEmp.ListaPorId(id);

            if (emp == null)
                return HttpNotFound();

            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarEmp(EMP emp)
        {
            if (ModelState.IsValid)
            {

                emp.NOME = emp.NOME.ToUpper();
                emp.RAZAOSOCIAL = emp.RAZAOSOCIAL.ToUpper();
                appEmp.Salvar(emp);
                return RedirectToAction("ListEmp");
            }
            
            return View(emp);
        }
       

        public ActionResult ExcluirEmp(string id)
        {
            var emp = appEmp.ListaPorId(id);

            if (emp == null)
                return HttpNotFound();
            return View(emp);
        }

        [HttpPost, ActionName("ExcluirEmp")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirEmpConfirmado(string id)
        {
            var emp = appEmp.ListaPorId(id);
            appEmp.Excluir(emp);
            return RedirectToAction("ListEmp");
        }
    }
}