using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepositorioEF;
using Contexto;
using Contexto.Models;
using WebGrease.Css.Extensions;
using Contexto.Aplicação;
using Contexto.Conexao;

namespace Sisemp.Controllers
{
    public class RotController : Controller
    {
        private readonly ApRot appRot;

        public RotController()
        {
            appRot = RotCon.ApRotCon();
        }

        public ActionResult Lista()
        {

            var lista = appRot.ListarTodos();

            return View(lista); 
        }

        [HttpPost, ActionName("Lista")]
        public ActionResult ListaBuscar()
        {
            if (Request["pesquisa"].Equals(""))
            {
                var lista = appRot.ListarTodos();
                return View(lista);
            }
            else
            {
                var lista = appRot.ListarTodos().Where(x => x.NOME.Contains(Request["pesquisa"].ToUpper()));
                return View(lista);
            }

        }


        public ActionResult Criar()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Criar(ROT rot)
        { 
            if (ModelState.IsValid)
            {
                appRot.Salvar(rot);
                return RedirectToAction("Lista");
            }
            return View(rot);
        }

        public ActionResult Editar(string id)
        {
            var rot = appRot.ListaPorId(id);

            if (rot == null)
                return HttpNotFound();

            return View(rot);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ROT rot)
        {
            if (ModelState.IsValid)
            {
                appRot.Salvar(rot);
                return RedirectToAction("Lista");
            }
            
            return View(rot);
        }
       

        public ActionResult Excluir(string id)
        {
            var rot = appRot.ListaPorId(id);

            if (rot == null)
                return HttpNotFound();
            return View(rot);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirCrdConfirmado(string id)
        {
            var rot = appRot.ListaPorId(id);
            appRot.Excluir(rot);
            return RedirectToAction("Lista");
        }
    }
}