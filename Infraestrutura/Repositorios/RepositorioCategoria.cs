using Dominio.Entidades;
using Dominio.Interfaces;

namespace Infraestrutura.Repositorios;

public class RepositorioCategoria : Repositorio<Categoria>, IRepositorioCategoria
{
    readonly Context _context;
    public RepositorioCategoria()
    {
        _context = new();
    }
    public IDictionary<Categoria, int> ContagemProdutoPorCategoria()
    {
        return _context.Categorias.Select(x => new { Categoria = x, Total = x.Produtos.Count() }).OrderByDescending(x => x.Total).ToDictionary(x => x.Categoria, x => x.Total);
    }
    public IDictionary<Categoria, double> PricePerCategory()
    {
        return _context.Categorias.Select(c => new { CategoryName = c, TotalPrice = c.Produtos.Sum(p => p.Valor) }).OrderByDescending(x => x.TotalPrice).ToDictionary(x => x.CategoryName, x => x.TotalPrice);
    }
    public IDictionary<Categoria, double> TopFiveCategories()
    {
        return _context.Categorias.Select(b => new { CategoryName = b, TotalPrice = b.Produtos.Sum(p => p.Valor) }).OrderByDescending(p => p.TotalPrice)
            .Take(5).ToDictionary(x => x.CategoryName, x => x.TotalPrice);

    }

}





