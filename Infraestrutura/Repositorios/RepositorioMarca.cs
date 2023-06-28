using Dominio.Entidades;
using Dominio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infraestrutura.Repositorios;

public class RepositorioMarca : Repositorio<Marca>, IRepositorioMarca
{
    readonly Context _context;

    public RepositorioMarca()
    {
        _context = new();
    }
    public IDictionary<Marca, int> ContagemProdutoPorMarca()
    {
        return _context.Marcas.Select(x => new { Marca = x, Total = x.Produtos.Count() }).ToDictionary(x => x.Marca, x => x.Total);
    }
    public IDictionary<Marca, double> PricesPerBrands()
    {
        return _context.Marcas.Select(b => new{BrandName = b, TotalPrice = b.Produtos.Sum(p => p.Valor)}).ToDictionary(x => x.BrandName, x => x.TotalPrice);
    }
}

