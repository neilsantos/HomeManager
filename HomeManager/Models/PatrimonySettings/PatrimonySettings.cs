using Dominio.Entidades;

namespace Apresentacao.Models.PatrimonySettings
{
    public class PatrimonySettings
    {

        public List<MarcaModel> ContagemMarcas { get; set; } = new();
        public List<CategoriaModel> ContagemCategorias { get; set; } = new();

        public PatrimonySettings(IDictionary<Marca, int> contagemMarcas, IDictionary<Categoria, int> contagemCategorias, int totalProdutos)
        {
            foreach (var marca in contagemMarcas)
            {
                ContagemMarcas.Add(new MarcaModel
                {
                    Nome = marca.Key.Nome,
                    Percentual = totalProdutos != 0 ? marca.Value * 100 / totalProdutos : 52
                });
            }
            foreach (var categoria in contagemCategorias)
            {
                ContagemCategorias.Add(new CategoriaModel
                {
                    Nome = categoria.Key.Nome,
                    Percentual = totalProdutos != 0 ? categoria.Value * 100 / totalProdutos : 52
                });
            }
        }

        private void PopularLista()
        {
            //    RepositorioMarca repositorioMarca = new();
            //    RepositorioCategoria repositorioCategoria = new();

            //    var TotaldeProdutos = repositorioProduto.Count();

            //    var marcas = repositorioMarca.Ler();

            //    foreach (var marca in marcas)
            //    {
            //        int total = repositorioProduto.CountProductsByMarca(marca.Nome);
            //        ContagemMarcas.Add(new MarcaModel
            //        {
            //            Nome = marca.Nome,
            //            Percentual = TotaldeProdutos != 0?((total * 100)/ TotaldeProdutos) :52
            //        });
            //    }

            //    var categorias = repositorioCategoria.Ler();

            //    foreach (var categoria in categorias)
            //    {
            //        int total = repositorioProduto.CountProductsByCategoria(categoria.Nome);
            //        ContagemCategorias.Add(new CategoriaModel
            //        {
            //            Nome = categoria.Nome,
            //            Percentual = TotaldeProdutos != 0 ? ((total * 100) / TotaldeProdutos) : 52
            //        });
            //    }
        }

    }

}
