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
                cliAlterar.NOME = cli.NOME != null ? cli.NOME.ToUpper().Trim() : cli.NOME;
                cliAlterar.RAZAOSOCIAL = cli.RAZAOSOCIAL != null ? cli.RAZAOSOCIAL.ToUpper().Trim() : cli.RAZAOSOCIAL;
                cliAlterar.CPF_CNPJ = cli.CPF_CNPJ.ToUpper().Trim();
                cliAlterar.END = cli.END != null ? cli.END.ToUpper().Trim() : cli.END;
                cliAlterar.COMP = cli.COMP != null ? cli.COMP.ToUpper().Trim() : cli.COMP;
                cliAlterar.BAIRRO = cli.BAIRRO != null ? cli.BAIRRO.ToUpper().Trim() : cli.BAIRRO;
                cliAlterar.ROTA = cli.ROTA;
                cliAlterar.CIDADE = cli.CIDADE != null ? cli.CIDADE.ToUpper().Trim() : cli.CIDADE;
                cliAlterar.UF = cli.UF != null ? cli.UF.ToUpper().Trim() : cli.UF;
                cliAlterar.TEL = cli.TEL != null ? cli.TEL.ToUpper().Trim() : cli.TEL;
                cliAlterar.CEL = cli.CEL != null ? cli.CEL.ToUpper().Trim() : cli.CEL;
                cliAlterar.OBS = cli.OBS != null ? cli.OBS.ToUpper().Trim() : cli.OBS;
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

                    if (cli.NOME != null)
                        cli.NOME = cli.NOME.ToUpper().Trim();
                    cli.CPF_CNPJ = cli.CPF_CNPJ.Replace(".","").Replace("-","").Replace("/","");
                    if (cli.RAZAOSOCIAL != null)
                        cli.RAZAOSOCIAL = cli.RAZAOSOCIAL.ToUpper().Trim();
                    if (cli.END != null)
                        cli.END = cli.END.ToUpper().Trim();
                    if (cli.COMP != null)
                        cli.COMP.ToUpper().Trim();
                    if (cli.BAIRRO != null)
                        cli.BAIRRO = cli.BAIRRO.ToUpper().Trim();
                    if (cli.CIDADE != null)
                        cli.CIDADE = cli.CIDADE.ToUpper().Trim();
                    if (cli.UF != null)
                        cli.UF = cli.UF.ToUpper().Trim();
                    if (cli.OBS != null)
                        cli.OBS = cli.OBS.ToUpper().Trim();
                if (cli.TEL != null)
                    cli.TEL = cli.TEL.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                cli.CEL = cli.CEL.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                    contexto.CLIs.Add(cli);
                }
                contexto.SaveChanges();

        }

        private void IF(bool p)
        {
            throw new NotImplementedException();
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

