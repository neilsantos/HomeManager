using Dominio.Entidades;
using Dominio.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;

namespace Infraestrutura.Repositorios;

class RepositorioCategoria : Repositorio<Categoria>, IRepositorioCategoria
{
    //private readonly List<Categoria> Categorias = new List<Categoria>();
    Context context;
    public RepositorioCategoria() 
    {
        context = new();
    }

   
}





