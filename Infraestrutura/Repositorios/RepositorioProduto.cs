using Dominio.Entidades;
using Dominio.Interfaces;

namespace Infraestrutura.Repositorios;

public class RepositorioProduto : Repositorio<Produto>, IRepositorioProduto
{   
    readonly Context _context;

}

