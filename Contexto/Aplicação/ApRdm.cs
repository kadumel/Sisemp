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
    public class ApRdm
    {
        private readonly IRepositorio<RDM> _repositorio;

         public ApRdm(IRepositorio<RDM> repo)
        {
            _repositorio = repo;
        }

        public void Salvar(RDM obj)
        {
            _repositorio.Salvar(obj);
        }

        public void Excluir(RDM obj)
        {
            _repositorio.Excluir(obj);
        }

        public IEnumerable<RDM> ListarTodos()
        {
            return _repositorio.ListarTodos();
        }

        public RDM ListaPorId(string id)
        {
            return _repositorio.ListarPorId(id);
        }
    }
}

