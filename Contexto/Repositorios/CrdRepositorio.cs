using Contexto.Models;
using RepositorioEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contexto.Repositorios
{
    class CrdRepositorio : IRepositorio<CRD>
    {
         private readonly SISEMPContext contexto;

         public CrdRepositorio()
        {
            contexto = new SISEMPContext();
        }

        public void Salvar(CRD crd)
        {
            if (crd.CODIGO > 0)
                {
                    var crdAlterar = contexto.CRDs.First(x => x.CODIGO == crd.CODIGO);
                    crdAlterar.CODIGO_PAI = crd.CODIGO_PAI;
                    crdAlterar.NOME = crd.NOME;
                }
                else
                {

                    contexto.CRDs.Add(crd);
                }
                contexto.SaveChanges();

        }

        public void Excluir(CRD crd)
        {
            var crdExcluir = contexto.CRDs.First(x => x.CODIGO == crd.CODIGO);
            contexto.Set<CRD>().Remove(crdExcluir);
            contexto.SaveChanges();
        }

        public IEnumerable<CRD> ListarTodos()
        {
            return contexto.CRDs;
        }

        public CRD ListarPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return contexto.CRDs.First(x => x.CODIGO == idInt);
        }

    }
}
