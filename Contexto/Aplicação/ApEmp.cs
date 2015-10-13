using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Contexto.Models;

namespace RepositorioEF
{
    public class ApEmp
    {
        private readonly IRepositorio<EMP> _repositorio;

        public ApEmp(IRepositorio<EMP> repo )
        {
            _repositorio = repo;
        }

        public void Salvar(EMP emp)
        {
            _repositorio.Salvar(emp);
        }

        public void Excluir(EMP emp)
        {
            _repositorio.Excluir(emp);
        }

        public IEnumerable<EMP> ListarTodos()
        {
            return _repositorio.ListarTodos();
        }

        public EMP ListaPorId(string id)
        {
            return _repositorio.ListarPorId(id);
        }
    }
}
