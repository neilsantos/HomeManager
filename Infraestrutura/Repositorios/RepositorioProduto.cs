using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace Infraestrutura.Repositorios;

public class RepositorioProduto : Repositorio<Produto>, IRepositorioProduto
{   
    readonly Context _context;

    public RepositorioProduto()
    {
        _context = new();
    }
    public List<Produto> GetFullProducts()
    {
      return _context.Produtos.Include(p => p.Categoria).Include(p => p.Marca).ToList();
    }
    public List<Produto> GetProductsByCategory(int categoryId)
    {   
        return _context.Produtos.Include(p => p.Categoria).Include(p => p.Marca).Where(p => p.Categoria.Id == categoryId).ToList();
    }
    public List<Produto> GetProductsByBrand(int brandId)
    {
        return _context.Produtos.Include(p => p.Categoria).Include(p => p.Marca).Where(p => p.Marca.Id == brandId).ToList();
    }
    public List<Produto> TopFiveProducts()
    {
        return _context.Produtos.OrderByDescending(x => x.Valor).Include(p => p.Categoria).Include(p => p.Marca).Take(5).ToList();

    }
}

