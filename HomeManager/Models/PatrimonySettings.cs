using Infraestrutura.Repositorios;
using Apresentacao.Models;

namespace Apresentacao.Models
{
    public class PatrimonySettings
    {

        public List<MarcaModel> ContagemMarcas = new();
        public List<CategoriaModel> ContagemCategorias = new();

        public PatrimonySettings(List<MarcaModel> ContagemMarcas, List<CategoriaModel> ContagemCategorias)
        {
            
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
