using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contexto.Aplicação;
using Contexto.Repositorios;
using RepositorioEF;

namespace Contexto.Conexao
{
    public class CliCon
    {
        public static ApCli ApCliCon()
        {
            return new ApCli(new CliRepositorio());
        } 
    }
}
