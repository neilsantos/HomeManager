using Dominio.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;

namespace Infraestrutura.Repositorios;

    class RepositorioCategoria
    {

        public RepositorioCategoria()
        {
            PopularCategoria();
        }

        private readonly List<Categoria> Categorias = new List<Categoria>();

        private void PopularCategoria()
        {   
            Categorias.Add(new Categoria("Eletrônico"));
            Categorias.Add(new Categoria("Móveis"));
            Categorias.Add(new Categoria("Eletrodoméstico"));
            Categorias.Add(new Categoria("Colecionaveis"));

            for (int i = 0; i < Categorias.Count; i++)
            {
                var Categoria = Categorias[i];
                Categoria.Id = i+1;
            }
        }

        public IEnumerable<Categoria> Ler()
        {
            var json = JsonConvert.SerializeObject(Categorias);
            List<Categoria> listaSemReferencia = JsonConvert.DeserializeObject<List<Categoria>>(json);

            return listaSemReferencia.OrderBy(x => x.Id);
        }

        public Categoria Adicionar(Categoria categoria)
        {
            
            Categorias.Add(categoria);
            int maiorId = Categorias.Max(X => X.Id);
            categoria.Id = ++maiorId;
            return categoria;
        }

        public void Atualizar(Categoria categoria)
        {
            var item = Categorias.FirstOrDefault(x => x.Id == categoria.Id);
            if (item==null)
            {
                throw new Exception("Item Não Encontrado");
            }
            Categorias.Remove(item);
            Categorias.Add(categoria);
        }

        public void Remover(Categoria categoria)
        {
            var item = Categorias.FirstOrDefault(x => x.Id == categoria.Id);
            Categorias.Remove(item);
        }
    }

