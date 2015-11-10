using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contexto.Models;
using RepositorioEF;

namespace Contexto.Repositorios
{
    class MovRepositorio : IRepositorio<MOV>
    {
    private readonly SISEMPContext contexto;

    public MovRepositorio()
        {
            contexto = new SISEMPContext();
        }

        public void Salvar(MOV mod)
        {
            if (mod.CODIGO > 0)
                {
                    var Alterar = contexto.MOVs.First(x => x.CODIGO == mod.CODIGO);
                }
                else
                {

                    contexto.MOVs.Add(mod);
                }
                contexto.SaveChanges();

        }

        public void Excluir(MOV mod)
        {
            var Excluir = contexto.MOVs.First(x => x.CODIGO == mod.CODIGO);
            contexto.Set<MOV>().Remove(Excluir);
            contexto.SaveChanges();
        }

        public IEnumerable<MOV> ListarTodos()
        {
            return contexto.MOVs;
        }

        public MOV ListarPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return contexto.MOVs.First(x => x.CODIGO == idInt);
        }
    }
    
}
