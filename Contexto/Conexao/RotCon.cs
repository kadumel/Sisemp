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
    public class RotCon
    {
        public static ApRot ApRotCon()
        {
            return new ApRot(new RotRepositorio());
        } 
    }
}
    
