using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contexto;
using Contexto.Aplicação;
using Contexto.Conexao;
using Contexto.Models;
using RepositorioEF;

namespace Sisemp.Controllers
{
    public class CliController : Controller
    {

        private readonly ApRot appRot;
        private readonly ApCli appCli;
       
        public CliController()
        {
            appCli = CliCon.ApCliCon();
            appRot = RotCon.ApRotCon();
        }

        public ActionResult ListCli()
        {
            var listaCli = appCli.ListarTodos();
            return View(listaCli); 
        }
        [HttpPost, ActionName("ListCli")]
        public ActionResult ListCliBuscar()
        {
            if (Request["pesquisa"].Equals(""))
            {
                var listaCli = appCli.ListarTodos();
                return View(listaCli);
            }
            else
            {
                var listaCli = appCli.ListarTodos().Where(x => x.RAZAOSOCIAL.Contains(Request["pesquisa"].ToUpper()));
                return View(listaCli);
            }

        }


        public ActionResult CriarCLi()
        {
            
            ViewBag.RotaId = new SelectList(appRot.ListarTodos(), "CODIGO", "NOME");
            return View();
        }

        [HttpPost]       
        public ActionResult CriarCli(CLI cli)
        {
            if (ModelState.IsValid)
            {
                if (!Request["RotaId"].Equals(""))
                {
                    cli.ROTA = Convert.ToInt32(Request["RotaId"]);
                }
                
                appCli.Salvar(cli);
                return RedirectToAction("ListCli");
            }
            return View(cli);
        }

        public ActionResult EditarCli(string id)
        {
            var cli = appCli.ListaPorId(id);

            if (cli == null)
                return HttpNotFound();

            ViewBag.RotaId = new SelectList(appRot.ListarTodos(), "CODIGO", "NOME", cli.ROTA);
            return View(cli);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarCli(CLI cli)
        {
            if (ModelState.IsValid)
            {
                appCli.Salvar(cli);
                return RedirectToAction("ListCli");
            }
            
            return View(cli);
        }
       

        public ActionResult ExcluirCli(string id)
        {
            var cli = appCli.ListaPorId(id);

            if (cli == null)
                return HttpNotFound();
            return View(cli);
        }

        [HttpPost, ActionName("ExcluirCli")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirCliConfirmado(string id)
        {
            var cli = appCli.ListaPorId(id);
            appCli.Excluir(cli);
            return RedirectToAction("ListCli");
        }

        public ActionResult Detalhe(string id)
        {
            var cli = appCli.ListaPorId(id);

            if (cli == null)
                return HttpNotFound();

            return View(cli);
        }
    }
}