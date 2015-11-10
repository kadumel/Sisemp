using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositorioEF;
using Contexto.Aplicação;
using Contexto.Repositorios;

namespace Contexto.Conexao
{
    public class MovCon
    {
        public static ApMov ApMovCon()
        {
            return new ApMov(new MovRepositorio());
        }
    }
}
