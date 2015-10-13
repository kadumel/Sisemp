using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contexto.Models;
using RepositorioEF;

namespace Contexto.Repositorios
{
    class CliRepositorio : IRepositorio<CLI>
    {
        private readonly SISEMPContext contexto;

        public CliRepositorio()
        {
            contexto = new SISEMPContext();
        }

        public void Salvar(CLI cli)
        {
            if (cli.CODIGO > 0)
                {
                    var cliAlterar = contexto.CLIs.First(x => x.CODIGO == cli.CODIGO);
                    cliAlterar.EMP_CODIGO = cli.EMP_CODIGO;
                    cliAlterar.NOME = cli.NOME.Trim();
                    cliAlterar.RAZAOSOCIAL = cli.RAZAOSOCIAL.Trim();
                    cliAlterar.CPF_CNPJ = cli.CPF_CNPJ.Trim();
                    cliAlterar.END = cli.END.Trim();
                    cliAlterar.COMP = cli.COMP.Trim();
                    cliAlterar.CEP = cli.CEP.Trim();
                    cliAlterar.BAIRRO = cli.BAIRRO.Trim();
                    cliAlterar.CIDADE = cli.CIDADE.Trim();
                    cliAlterar.UF = cli.UF.Trim();
                    cliAlterar.TEL = cli.TEL.Trim();
                    cliAlterar.CEL = cli.CEL.Trim();
                    cliAlterar.OBS = cli.OBS.Trim();
                }
                else
                {
                    //cli.EMP_CODIGO =    cli.EMP_CODIGO;
                    //cli.NOME = cli.NOME.Equals(null) ? cli.NOME : cli.NOME.Trim();
                    //if (!cli.RAZAOSOCIAL.Equals(null))
                    //{
                    //    cli.RAZAOSOCIAL.Trim();
                    //}
                    //cli.CPF_CNPJ = cli.CPF_CNPJ.Equals(null) ? cli.CPF_CNPJ : cli.CPF_CNPJ.Trim();
                    //cli.END = cli.END.Equals(null) ? cli.END : cli.END.Trim();
                    //cli.COMP = cli.COMP.Equals(null) ? cli.COMP : cli.COMP.Trim();
                    //cli.CEP = cli.CEP.Equals(null) ? cli.CEP : cli.CEP.Trim();
                    //cli.BAIRRO = cli.BAIRRO.Equals(null) ? cli.BAIRRO : cli.BAIRRO.Trim();
                    //cli.CIDADE = cli.CIDADE.Equals(null) ? cli.CIDADE : cli.CIDADE.Trim();
                    //cli.UF = cli.UF.Equals(null) ? cli.UF : cli.UF.Trim();
                    //cli.TEL = cli.TEL.Equals(null) ? cli.TEL : cli.TEL.Trim();
                    //cli.CEL = cli.CEL.Equals(null) ? cli.CEL : cli.CEL.Trim();
                    //cli.OBS = cli.OBS.Equals(null) ? cli.OBS : cli.OBS.Trim();
                    contexto.CLIs.Add(cli);
                }
                contexto.SaveChanges();

        }

        public void Excluir(CLI cli)
        {
            var cliExcluir = contexto.CLIs.First(x => x.CODIGO == cli.CODIGO);
            contexto.Set<CLI>().Remove(cliExcluir);
            contexto.SaveChanges();
        }

        public IEnumerable<CLI> ListarTodos()
        {
            return contexto.CLIs;
        }

        public CLI ListarPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return contexto.CLIs.First(x => x.CODIGO == idInt);
        }
    }
    
}

