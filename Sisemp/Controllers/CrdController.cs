using Contexto.Aplicação;
using Contexto.Conexao;
using Contexto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Sisemp.Controllers
{
    public class CrdController : Controller
    {

        private readonly ApCrd appCrd;

        public CrdController()
        {
            appCrd = CrdCon.ApCrdCon();
        }

        public ActionResult ListCrd()
        {
            var listaCrd = appCrd.ListarTodos();
            return View(listaCrd); 
        }
        
        //public ActionResult ListEmp(string nome)
        //{
        //    var listaEmp = appEmp.ListarTodos();
        //    listaEmp.Where(x => x.NOME.Contains(nome));
        //    return View(listaEmp);
        //}

        public ActionResult CriarCrd()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            var List = appCrd.ListarTodos();
            Console.WriteLine("Teste!!!");
            foreach (var c in List)
            {
                Console.WriteLine(c.NOME);
                lista.Add(new SelectListItem
                {
                    Text = c.NOME,
                    Value = c.CODIGO.ToString()
                    
                });
            }
            ViewBag.CODIGO = lista;
            return View();
        }

        [HttpPost]
        public ActionResult CriarCrd(CRD crd)
        {
            Console.WriteLine("Teste2!!!");
            if (ModelState.IsValid)
            {
                appCrd.Salvar(crd);
                return RedirectToAction("ListCrd");
            }
            return View(crd);
        }

        public ActionResult EditarCrd(string id)
        {
            var crd = appCrd.ListaPorId(id);

            if (crd == null)
                return HttpNotFound();

            return View(crd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarCrd(CRD crd)
        {
            if (ModelState.IsValid)
            {
               
                crd.NOME = crd.NOME.ToUpper();
          
                appCrd.Salvar(crd);
                return RedirectToAction("ListCrd");
            }
            
            return View(crd);
        }
       

        public ActionResult ExcluirCrd(string id)
        {
            var crd = appCrd.ListaPorId(id);

            if (crd == null)
                return HttpNotFound();
            return View(crd);
        }

        [HttpPost, ActionName("ExcluirCrd")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirCrdConfirmado(string id)
        {
            var crd = appCrd.ListaPorId(id);
            appCrd.Excluir(crd);
            return RedirectToAction("ListCrd");
        }
    }
}