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
    public class ApRot
    { 
        private readonly IRepositorio<ROT> _repositorio;

        public ApRot(IRepositorio<ROT> repo)
        {
            _repositorio = repo;
        }

        public void Salvar(ROT rot)
        {
            _repositorio.Salvar(rot);
        }

        public void Excluir(ROT rot)
        {
            _repositorio.Excluir(rot);
        }

        public IEnumerable<ROT> ListarTodos()
        {
            return _repositorio.ListarTodos();
        }

        public ROT ListaPorId(string id)
        {
            return _repositorio.ListarPorId(id);
        }
    }
}