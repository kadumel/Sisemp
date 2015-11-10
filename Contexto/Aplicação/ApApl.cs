using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Contexto.Models;
using RepositorioEF;


namespace Contexto.Aplicação
{
    public class ApApl
    {
        private readonly IRepositorio<APL> _repositorio;

        public ApApl(IRepositorio<APL> repo)
        {
            _repositorio = repo;
        }

        public void Salvar(APL obj)
        {
            _repositorio.Salvar(obj);
        }

        public void Excluir(APL obj)
        {
            _repositorio.Excluir(obj);
        }

        public IEnumerable<APL> ListarTodos()
        {
            return _repositorio.ListarTodos();
        }

        public APL ListaPorId(string id)
        {
            return _repositorio.ListarPorId(id);
        }
    }
}
