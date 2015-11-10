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
    public class ApMov
    {
        private readonly IRepositorio<MOV> _repositorio;

        public ApMov(IRepositorio<MOV> repo)
        {
            _repositorio = repo;
        }

        public void Salvar(MOV obj)
        {
            _repositorio.Salvar(obj);
        }

        public void Excluir(MOV obj)
        {
            _repositorio.Excluir(obj);
        }

        public IEnumerable<MOV> ListarTodos()
        {
            return _repositorio.ListarTodos();
        }

        public MOV ListaPorId(string id)
        {
            return _repositorio.ListarPorId(id);
        }
    }
}
