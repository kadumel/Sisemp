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

        private readonly ApCli appCli;
        public CliController()
        {
            appCli = CliCon.ApCliCon();
        }

        public ActionResult ListCli()
        {
            var listaCli = appCli.ListarTodos();
            return View(listaCli); 
        }
        
        //public ActionResult ListEmp(string nome)
        //{
        //    var listaEmp = appEmp.ListarTodos();
        //    listaEmp.Where(x => x.NOME.Contains(nome));
        //    return View(listaEmp);
        //}

        public ActionResult CriarCLi()
        {

            return View();
        }

        [HttpPost]       
        public ActionResult CriarCli(CLI cli)
        {
            if (ModelState.IsValid)
            {
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

            return View(cli);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarCli(CLI cli)
        {
            if (ModelState.IsValid)
            {
                cli.EMP_CODIGO = cli.EMP_CODIGO;
                cli.NOME = cli.NOME.ToUpper();
                cli.RAZAOSOCIAL = cli.RAZAOSOCIAL.ToUpper();
                cli.END = cli.END.ToUpper();
                cli.COMP = cli.COMP.ToUpper();
                cli.BAIRRO = cli.BAIRRO.ToUpper();
                cli.CIDADE = cli.CIDADE.ToUpper();
                cli.UF = cli.UF.ToUpper();
                cli.OBS = cli.OBS.ToUpper();

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