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
        return _context.Categorias.Select(x => new { Categoria = x, Total = x.Produtos.Count() }).ToDictionary(x => x.Categoria, x => x.Total);
    }
}





