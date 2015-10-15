using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositorioEF;

namespace Contexto
{
    public class empCon
    {
        public static ApEmp ApEmpCon()
        {
            return new ApEmp(new EmpRepositorio());
        } 
    }
}
