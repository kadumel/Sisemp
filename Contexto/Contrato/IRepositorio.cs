﻿using System.Collections.Generic;
using System.Globalization;

namespace RepositorioEF
{
    public interface IRepositorio<T> where T : class
    {
        void Salvar(T entidade);
        void Excluir(T entidade);
        IEnumerable<T> ListarTodos();
        T ListarPorId(string id);
    }
}