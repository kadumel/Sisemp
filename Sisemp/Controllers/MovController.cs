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
    public class MovController : Controller
    {
        private readonly ApApl appApl;
        private readonly ApRot appRot;
        private readonly ApMov appMov;

        public MovController()
        {
            appApl = AplCon.ApAplCon();
            appRot = RotCon.ApRotCon();
            appMov = MovCon.ApMovCon();
        }

        public ActionResult Lista()
        {

            var lista = appMov.ListarTodos();

            return View(lista); 
        }

        [HttpPost, ActionName("Lista")]
        public ActionResult ListaBuscar()
        {
            if (Request["pesquisa"].Equals(""))
            {
                var lista = appMov.ListarTodos();
                return View(lista);
            }
            else
            {
                var lista = appMov.ListaPorId(Request["pesquisa"]);
                return View(lista);
            }

        }


        public ActionResult Criar()
        {
            ViewBag.AplId = new SelectList(appApl.ListarTodos(), "CODIGO", "CODIGO");
            ViewBag.RotId = new SelectList(appRot.ListarTodos(), "CODIGO", "NOME");
            return View();
        }

        [HttpPost]
        public ActionResult Criar(MOV obj)
        { 
            if (ModelState.IsValid)
            {
                if (!Request["AplId"].Equals("") && !Request["RotId"].Equals(""))
                {
                    obj.APL_CODIGO = Convert.ToInt32(Request["AplId"]);
                    obj.ROT_CODIGO = Convert.ToInt32(Request["RotId"]);
                }
                appMov.Salvar(obj);
                return RedirectToAction("Lista");
            }
            return View(obj);
        }

        public ActionResult Editar(string id)
        {
            var obj = appMov.ListaPorId(id);


            if (obj == null)
                return HttpNotFound();

            ViewBag.AplId = new SelectList(appApl.ListarTodos(), "CODIGO", "NOME", obj.APL_CODIGO);
            ViewBag.RotId = new SelectList(appRot.ListarTodos(), "CODIGO", "NOME", obj.ROT_CODIGO);

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(MOV obj)
        {
            if (ModelState.IsValid)
            {
                appMov.Salvar(obj);
                return RedirectToAction("Lista");
            }
            
            return View(obj);
        }
       

        public ActionResult Excluir(string id)
        {
            var obj = appMov.ListaPorId(id);

            if (obj == null)
                return HttpNotFound();
            return View(obj);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(string id)
        {
            var obj = appMov.ListaPorId(id);
            appMov.Excluir(obj);
            return RedirectToAction("Lista");
        }
    }
}