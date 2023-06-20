using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Interfaces;
using Dominio.Entidades;

namespace Infraestrutura.Repositorios;

public class Repositorio<T> : IRepositorio<T> where T : EntidadeBase
{
    Context contexto;

    public Repositorio()
    {
        contexto = new Context();
    }

    public IEnumerable<T> Ler()
    {
        
        //List<T> Lista = (from T item in contexto.Set<T>()
        //                 select item).ToList<T>();
        return contexto.Set<T>().ToList();


    }

    public T Adicionar(T item)
    {
        contexto.Set<T>().Add(item);
        
        return item;

    }

    public void Atualizar(T item)
    {
        T resultado = contexto.Set<T>().Find(typeof(T),item.Id);

        if (resultado == null)
        {
            throw new Exception("This Was Not Found");
        }
        contexto.Set<T>().Update(item);
    }

    public void Remover(T item)
    {
        contexto.Set<T>().Remove(item);
    }
}

