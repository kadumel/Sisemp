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
    class RotRepositorio : IRepositorio<ROT>
    {

     private readonly SISEMPContext contexto;

     public RotRepositorio()
        {
            contexto = new SISEMPContext();
        }

        public void Salvar(ROT rot)
        {
                if (rot.CODIGO > 0)
                {
                    var Alterar = contexto.ROTs.First(x => x.CODIGO == rot.CODIGO);
                    Alterar.NOME = rot.NOME.ToUpper().Trim();
                    Alterar.OBS = rot.OBS.ToUpper().Trim(); 
  
                }
                else
                {
                    rot.NOME = rot.NOME.ToUpper().Trim();
                    rot.OBS = rot.OBS.ToUpper().Trim();
                    contexto.ROTs.Add(rot);
                }
                contexto.SaveChanges();

        }

        public void Excluir(ROT rot)
        {
            var Excluir = contexto.ROTs.First(x => x.CODIGO == rot.CODIGO);
            contexto.Set<ROT>().Remove(Excluir);
            contexto.SaveChanges();
        }

        public IEnumerable<ROT> ListarTodos()
        {
            return contexto.ROTs;
        }

        public ROT ListarPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return contexto.ROTs.First(x => x.CODIGO == idInt);
        }
    }
    
}
