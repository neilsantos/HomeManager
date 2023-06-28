using Dominio.Entidades;
using Dominio.Interfaces;
using System.Linq;

namespace Infraestrutura.Repositorios;

public class Repositorio<T> : IRepositorio<T> where T : EntidadeBase
{
    readonly Context _context;

    public Repositorio()
    {
        _context = new();
    }

    public IEnumerable<T> Ler()
    {   
        return _context.Set<T>().ToList();
    }

    public T Adicionar(T item)
    {
        try
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {

            throw ex;
        }
        
        return item;
    }
    public void Atualizar(T item)
    {
        T resultado = _context.Set<T>().Find(typeof(T),item.Id);

        if (resultado == null)
            throw new Exception("This Was Not Found");
       
        _context.Set<T>().Update(item);
    }

    public void Remover(T item)
    {
        _context.Set<T>().Remove(item);
    }
     public int Count()
    {
        return _context.Set<T>().Count();
    }
}

