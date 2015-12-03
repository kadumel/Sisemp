using Contexto.Aplicação;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contexto.Conexao
{
    public class RdmCon
    {
        public static ApRdm ApRdmCon()
        {
            return new ApRdm(new RdmRepositorio());
        }
    }
}

