using Dominio.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infraestrutura.Repositorios;

public class RepositorioMarca : Repositorio<Marca>, IRepositorioMarca
{
    public RepositorioMarca()
    {
        PopularResitorio();
    }

    private readonly List<Marca> Marcas = new List<Marca>();

    private void PopularResitorio()
    {
        Marcas.Add(new Marca("Demo-Generico"));
        Marcas.Add(new Marca("Microsoft"));
        Marcas.Add(new Marca("Nintendo"));
        Marcas.Add(new Marca("LG"));
        Marcas.Add(new Marca("Sony"));

        for (int i = 0; i < Marcas.Count; i++)
        {
            var marca = Marcas[i];
            marca.Id = i + 1;
        }
    }



}

