using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades;

    public class Marca:EntidadeBase
    {
    public string Nome { get; set; } 

        public virtual List<Produto> Produtos { get; set; }

        public Marca(string nome)
        {
            Nome = nome;
        }

    }

