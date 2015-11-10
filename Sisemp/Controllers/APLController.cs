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
    public class APLController : Controller
    {
        private readonly ApApl appApl;
        private readonly ApCli appCli;
        private readonly ApEmp appEmp;

        public APLController()
        {
            appApl = AplCon.ApAplCon();
            appCli = CliCon.ApCliCon();
            appEmp = empCon.ApEmpCon();
        }

        public ActionResult Lista()
        {

            var lista = appApl.ListarTodos();

            return View(lista); 
        }

        [HttpPost, ActionName("Lista")]
        public ActionResult ListaBuscar()
        {
            if (Request["pesquisa"].Equals(""))
            {
                var lista = appApl.ListarTodos();
                return View(lista);
            }
            else
            {
                var lista = appApl.ListaPorId(Request["pesquisa"]);
                return View(lista);
            }

        }


        public ActionResult Criar()
        {
            ViewBag.CliId = new SelectList(appCli.ListarTodos(), "CODIGO", "NOME");
            ViewBag.EmpId = new SelectList(appEmp.ListarTodos(), "CODIGO", "NOME");
            return View();
        }

        [HttpPost]
        public ActionResult Criar(APL obj)
        { 
            if (ModelState.IsValid)
            {
                if (!Request["CliId"].Equals("") && !Request["EmpId"].Equals(""))
                {
                    obj.CLI_CODIGO = Convert.ToInt32(Request["CliId"]);
                    obj.EMP_CODIGO = Convert.ToInt32(Request["EmpId"]);
                }
                appApl.Salvar(obj);
                return RedirectToAction("Lista");
            }
            return View(obj);
        }

        public ActionResult Editar(string id)
        {
            var obj = appApl.ListaPorId(id);

            if (obj == null)
                return HttpNotFound();

            ViewBag.CliId = new SelectList(appCli.ListarTodos(), "CODIGO", "NOME", obj.CLI_CODIGO);
            ViewBag.EmpId = new SelectList(appEmp.ListarTodos(), "CODIGO", "NOME", obj.EMP_CODIGO);

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(APL obj)
        {
            if (ModelState.IsValid)
            {
                appApl.Salvar(obj);
                return RedirectToAction("Lista");
            }
            
            return View(obj);
        }
       

        public ActionResult Excluir(string id)
        {
            var obj = appApl.ListaPorId(id);

            if (obj == null)
                return HttpNotFound();
            return View(obj);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(string id)
        {
            var obj = appApl.ListaPorId(id);
            appApl.Excluir(obj);
            return RedirectToAction("Lista");
        }
    }
}