using Contexto.Aplicação;
using Contexto.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contexto.Conexao
{
    public class CrdCon
    {
        public static ApCrd ApCrdCon()
        {
            return new ApCrd(new CrdRepositorio());
        } 
    }
}
