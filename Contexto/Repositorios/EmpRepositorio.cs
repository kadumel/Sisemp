using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RepositorioEF;
using Contexto.Models;


namespace Contexto
{
    class EmpRepositorio : IRepositorio<EMP>
    {
        private readonly SISEMPContext contexto;

        public EmpRepositorio()
        {
            contexto = new SISEMPContext();
        }

        public void Salvar(EMP emp)
        {
                if (emp.CODIGO > 0)
                {
                    var empAlterar = contexto.EMPs.First(x => x.CODIGO == emp.CODIGO);
                    empAlterar.NOME = emp.NOME.ToUpper().Trim();
                    empAlterar.RAZAOSOCIAL = emp.RAZAOSOCIAL.ToUpper().Trim();
                }
                else
                {
                    emp.NOME = emp.NOME.ToUpper().Trim();
                    emp.RAZAOSOCIAL = emp.RAZAOSOCIAL.ToUpper().Trim();
                    contexto.EMPs.Add(emp);
                }
                contexto.SaveChanges();

        }

        public void Excluir(EMP emp)
        {
            var empExcluir = contexto.EMPs.First(x => x.CODIGO == emp.CODIGO);
            contexto.Set<EMP>().Remove(empExcluir);
            contexto.SaveChanges();
        }

        public IEnumerable<EMP> ListarTodos()
        {
            return contexto.EMPs;
        }

        public EMP ListarPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return contexto.EMPs.First(x => x.CODIGO == idInt);
        }
    }
    
}
