using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades;

   public class Categoria:EntidadeBase
    {
        public string Nome { get; set; }

        public Categoria(string nome)
        {
            Nome = nome;
        }
    }
    

