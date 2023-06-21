using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entidades;

namespace Dominio.Interfaces;

public interface IRepositorioCategoria : IRepositorio<Categoria>
{
    IEnumerable<Categoria> Ler();
}

