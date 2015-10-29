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

        private readonly ApEmp appEmp;
        private readonly ApCli appCli;
       
        public CliController()
        {
            appCli = CliCon.ApCliCon();
            appEmp = empCon.ApEmpCon();
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
            
            ViewBag.EmpId = new SelectList(appEmp.ListarTodos(), "CODIGO", "NOME");
            return View();
        }

        [HttpPost]       
        public ActionResult CriarCli(CLI cli)
        {
            if (ModelState.IsValid)
            {
                if (!Request["EmpId"].Equals(""))
                {
                    cli.EMP_CODIGO = Convert.ToInt32(Request["EmpId"]);
                }
                cli.NOME = cli.NOME.ToUpper().Trim();
                cli.RAZAOSOCIAL = cli.RAZAOSOCIAL.ToUpper().Trim();
                cli.END = cli.END.ToUpper().Trim();
                cli.COMP = cli.COMP.ToUpper().Trim();
                cli.BAIRRO = cli.BAIRRO.ToUpper().Trim();
                cli.CIDADE = cli.CIDADE.ToUpper().Trim();
                cli.UF = cli.UF.ToUpper().Trim();
                cli.OBS = cli.OBS.ToUpper().Trim();
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

            ViewBag.EmpId = new SelectList(appEmp.ListarTodos(), "CODIGO", "NOME", cli.EMP_CODIGO);
            return View(cli);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarCli(CLI cli)
        {
            if (ModelState.IsValid)
            {
               
                cli.NOME = cli.NOME.ToUpper().Trim();
                cli.RAZAOSOCIAL = cli.RAZAOSOCIAL.ToUpper().Trim();
                cli.END = cli.END.ToUpper().Trim();
                cli.COMP = cli.COMP.ToUpper().Trim();
                cli.BAIRRO = cli.BAIRRO.ToUpper().Trim();
                cli.CIDADE = cli.CIDADE.ToUpper().Trim();
                cli.UF = cli.UF.ToUpper().Trim();
                cli.OBS = cli.OBS.ToUpper().Trim();

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