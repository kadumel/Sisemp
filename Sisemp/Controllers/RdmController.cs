using Contexto.Aplicação;
using Contexto.Models;
using Contexto.Conexao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sisemp.Controllers
{
    public class RdmController : Controller
    {
         private readonly ApRdm appRdm;
         private readonly ApRot appRot;
         private readonly ApCrd appCrd;

         public RdmController()
        {
            appRdm = RdmCon.ApRdmCon();
            appCrd = CrdCon.ApCrdCon();
            appRot = RotCon.ApRotCon();
        }

        public ActionResult Lista()
        {

            var lista = appRdm.ListarTodos();

            return View(lista); 
        }

        [HttpPost, ActionName("Lista")]
        public ActionResult ListaBuscar()
        {
            if (Request["pesquisa"].Equals(""))
            {
                var lista = appRdm.ListarTodos();
                return View(lista);
            }
            else
            {
                var lista = appRdm.ListaPorId(Request["pesquisa"]);
                return View(lista);
            }

        }


        public ActionResult Criar()
        {
            ViewBag.RotaId = new SelectList(appRot.ListarTodos(), "CODIGO", "NOME");
            ViewBag.CrdId = new SelectList(appCrd.ListarTodos(), "CODIGO", "NOME");
         
            return View();
        }

        [HttpPost]
        public ActionResult Criar(RDM obj)
        { 
            if (ModelState.IsValid)
            {
                if (!Request["RotaId"].Equals("") && !Request["CrdId"].Equals(""))
                {
                    obj.ROT_CODIGO = Convert.ToInt32(Request["RotaId"]);
                    obj.CRD_CODIGO = Convert.ToInt32(Request["CrdId"]);
                }
                appRdm.Salvar(obj);
                return RedirectToAction("Lista");
            }
            return View(obj);
        }

        public ActionResult Editar(string id)
        {
            var obj = appRdm.ListaPorId(id);

            if (obj == null)
                return HttpNotFound();

            ViewBag.RotaId = new SelectList(appRot.ListarTodos(), "CODIGO", "NOME", obj.ROT_CODIGO);
            ViewBag.CrdId = new SelectList(appCrd.ListarTodos(), "CODIGO", "NOME", obj.CRD_CODIGO);

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(RDM obj)
        {
            if (ModelState.IsValid)
            {
                appRdm.Salvar(obj);
                return RedirectToAction("Lista");
            }
            
            return View(obj);
        }
       

        public ActionResult Excluir(string id)
        {
            var obj = appRdm.ListaPorId(id);

            if (obj == null)
                return HttpNotFound();
            return View(obj);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(string id)
        {
            var obj = appRdm.ListaPorId(id);
            appRdm.Excluir(obj);
            return RedirectToAction("Lista");
        }
    }
}