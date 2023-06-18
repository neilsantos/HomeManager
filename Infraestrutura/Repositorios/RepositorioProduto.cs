using Dominio.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestrutura.Repositorios;

class RepositorioProduto
    {

        public RepositorioProduto()
        {
            
        }

        private readonly List<Produto> Inventario = new List<Produto>();
    
        public IEnumerable<Produto> Ler()
        {
            var json = JsonConvert.SerializeObject(Inventario);
            List<Produto> listaSemReferencia = JsonConvert.DeserializeObject<List<Produto>>(json);

            return listaSemReferencia.OrderBy(x => x.Id);
        }

        public void Adicionar(Produto produto)
        {
            Inventario.Add(produto);
            var maxId = Inventario.Max(x => x.Id);
            produto.Id = ++maxId;
            
        }
    
        public void Atualizar(Produto produto)
        {
            var item = Inventario.FirstOrDefault(x => x.Id == produto.Id);
            if (item == null)
            {
                throw new Exception("Item Não Encontrado");
            }
            Inventario.Remove(item);
            Inventario.Add(produto);
            
        }
    
        public void Remover(Produto produto)
        {
            var item = Inventario.FirstOrDefault(x => x.Id == produto.Id);
            Inventario.Remove(item);
        }

       


    }

