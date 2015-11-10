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

        [HttpPost, ActionName("ListCrd")]
        public ActionResult ListCrdBuscar()
        {
            if (Request["pesquisa"].Equals(""))
            {
                var listaCrd = appCrd.ListarTodos();
                return View(listaCrd);
            }
            else
            {
                var listaCrd = appCrd.ListarTodos().Where(x => x.NOME.Contains(Request["pesquisa"].ToUpper()));
                return View(listaCrd);
            }

        }


        public ActionResult CriarCrd()
        {
            ViewBag.Crdid = new SelectList(appCrd.ListarTodos(), "CODIGO","NOME");

            return View();
        }

        [HttpPost]
        public ActionResult CriarCrd(CRD crd)
        {
              
            if (ModelState.IsValid)
            {
                if (!Request["Crdid"].Equals(""))
                {
                    crd.CODIGO_PAI = Convert.ToInt32(Request["Crdid"]);
                }
               
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
            
            ViewBag.crdEdit = new SelectList(appCrd.ListarTodos(), "CODIGO", "NOME", crd.CODIGO_PAI);

            return View(crd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarCrd(CRD crd)
        {
            if (ModelState.IsValid)
            {
               
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