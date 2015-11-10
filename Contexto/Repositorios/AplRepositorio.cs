using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RepositorioEF;
using Contexto.Models;

namespace Contexto.Repositorios
{
    class AplRepositorio : IRepositorio<APL>
    {
    private readonly SISEMPContext contexto;

    public AplRepositorio()
        {
            contexto = new SISEMPContext();
        }

        public void Salvar(APL mod)
        {
            if (mod.CODIGO > 0)
                {
                    var Alterar = contexto.APLs.First(x => x.CODIGO == mod.CODIGO);
                }
                else
                {

                    contexto.APLs.Add(mod);
                }
                contexto.SaveChanges();

        }

        public void Excluir(APL mod)
        {
            var Excluir = contexto.APLs.First(x => x.CODIGO == mod.CODIGO);
            contexto.Set<APL>().Remove(Excluir);
            contexto.SaveChanges();
        }

        public IEnumerable<APL> ListarTodos()
        {
            return contexto.APLs;
        }

        public APL ListarPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return contexto.APLs.First(x => x.CODIGO == idInt);
        }
    }
    
}
