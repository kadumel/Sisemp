using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contexto.Models;
using RepositorioEF;

namespace Contexto.Aplicação
{
    public class ApCli
    {
         private readonly IRepositorio<CLI> _repositorio;

         public ApCli(IRepositorio<CLI> repo)
        {
            _repositorio = repo;
        }

         public void Salvar(CLI cli)
        {
            _repositorio.Salvar(cli);
        }

         public void Excluir(CLI emp)
        {
            _repositorio.Excluir(emp);
        }

         public IEnumerable<CLI> ListarTodos()
        {
            return _repositorio.ListarTodos();
        }

         public CLI ListaPorId(string id)
        {
            return _repositorio.ListarPorId(id);
        }
    }
}
