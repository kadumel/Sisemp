using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RepositorioEF;
using Contexto.Models;

namespace Contexto.Conexao
{
   
    class RdmRepositorio : IRepositorio<RDM>
    {
        private readonly SISEMPContext contexto;

        public RdmRepositorio()
        {
            contexto = new SISEMPContext();
        }

        public void Salvar(RDM mod)
        {
            if (mod.CODIGO > 0)
            {
                var Alterar = contexto.RDMs.First(x => x.CODIGO == mod.CODIGO);
                Alterar.ROT_CODIGO = mod.ROT_CODIGO;
                Alterar.CRD_CODIGO = mod.CRD_CODIGO;
                Alterar.VALOR = mod.VALOR;
                Alterar.DATA = mod.DATA;

            }
            else
            {
                contexto.RDMs.Add(mod);
            }
            contexto.SaveChanges();

        }

        public void Excluir(RDM mod)
        {
            var Excluir = contexto.RDMs.First(x => x.CODIGO == mod.CODIGO);
            contexto.Set<RDM>().Remove(Excluir);
            contexto.SaveChanges();
        }

        public IEnumerable<RDM> ListarTodos()
        {
            return contexto.RDMs;
        }

        public RDM ListarPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return contexto.RDMs.First(x => x.CODIGO == idInt);
        }
    }

}
