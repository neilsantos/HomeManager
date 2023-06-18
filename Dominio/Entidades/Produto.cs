using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Dominio.Entidades;

    public class Produto:EntidadeBase
    {
        public string Nome { get; set; }
       
        private Categoria _categoria;

        public string NumeroDeSerie;

        public String Modelo { get; set; }

        public Categoria Categoria 
        { 
           get => _categoria; 
           set
            {
                if (ProdutoPai != null && value != ProdutoPai.Categoria)
                    throw new Exception("A Categoria Deve Ser " + ProdutoPai.Categoria.Nome);
                _categoria = value;
            }
        
        }
        
        public Marca Marca{ get; set; }
        
        public double Valor { get; set; }
        
        private readonly List<Produto> _acessorios;
      
        public IEnumerable<Produto> Acessorios => _acessorios;

        private Produto ProdutoPai { get; set; }


        public Produto(string nome, Categoria categoria, Marca marca, double valor)
        {
            Nome = nome ?? throw new Exception("É Obrigatório Registrar o Nome");
            Categoria = categoria ?? throw new Exception("É Obrigatório Ter uma Categoria");
            Marca = marca ?? throw new Exception("É Obrigatório Ter uma Marca");
            Valor = valor;
            _acessorios = new List<Produto>();
        }

        public IEnumerable<Produto> LerAcessorios()
        {
            return Acessorios;
        }
        
        public void AdicionarAcessorio(string nome, float valor = 0)
        {
            var acessorio = new Produto(nome, Categoria, Marca, valor);
            acessorio.ProdutoPai = this;
            _acessorios.Add(acessorio);
            var maxId = _acessorios.Max(x => x.Id);
            acessorio.Id = ++maxId;
        }
        
        public void AdicionarAcessorio(string nome, float valor, Marca marca)
        {
            var acessorio = new Produto(nome, Categoria, marca, valor);
            _acessorios.Add(acessorio);
            var maxId = _acessorios.Max(x => x.Id);
            acessorio.Id = ++maxId;
        }
        
        public void AtualizarAcessorio(Produto acessorio)
        {
            var item = _acessorios.FirstOrDefault(x => x.Id == acessorio.Id);
            if (item == null)
            {
                throw new Exception("Item Não Encontrado");
            }
            _acessorios.Remove(item);
            _acessorios.Add(acessorio);
        }
       
        public void RemoverAcessorio(Produto acessorio)
        {
            var item = _acessorios.FirstOrDefault(x => x.Id == acessorio.Id);
            _acessorios.Remove(item);
       
        }

        public double Total => Acessorios.Sum(x => x.Valor) + Valor;

    }


