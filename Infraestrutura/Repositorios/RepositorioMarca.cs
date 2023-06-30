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
        return _context.Marcas.Select(x => new { Marca = x, Total = x.Produtos.Count() }).OrderByDescending(x => x.Total).ToDictionary(x => x.Marca, x => x.Total);
    }
    public IDictionary<Marca, double> PricesPerBrands()
    {
        return _context.Marcas.Select(b => new{BrandName = b, TotalPrice = b.Produtos.Sum(p => p.Valor)}).OrderByDescending(x => x.TotalPrice).ToDictionary(x => x.BrandName, x => x.TotalPrice);
    } 
    public IDictionary<Marca, double> TopFiveBrands()
    {
        return _context.Marcas.Select(b => new{BrandName = b, TotalPrice = b.Produtos.Sum(p => p.Valor)}).OrderByDescending(p => p.TotalPrice)
            .Take(5).ToDictionary(x => x.BrandName, x => x.TotalPrice);
        
    }




}

