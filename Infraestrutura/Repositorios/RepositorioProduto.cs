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
      var produto =  _context.Produtos.Include(p => p.Categoria)
                                      .Include(p => p.Marca)
                                      .ToList();

        return produto;
    }

}

