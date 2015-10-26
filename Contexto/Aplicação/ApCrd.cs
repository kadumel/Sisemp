using Contexto.Models;
using RepositorioEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contexto.Aplicação
{
        public class ApCrd
        {
            private readonly IRepositorio<CRD> _repositorio;

            public ApCrd(IRepositorio<CRD> repo)
            {
                _repositorio = repo;
            }

            public void Salvar(CRD crd)
            {
                _repositorio.Salvar(crd);
            }

            public void Excluir(CRD crd)
            {
                _repositorio.Excluir(crd);
            }

            public IEnumerable<CRD> ListarTodos()
            {
                return _repositorio.ListarTodos();
            }

            public CRD ListaPorId(string id)
            {
                return _repositorio.ListarPorId(id);
            }
      }
}
