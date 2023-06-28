using Dominio.Entidades;

namespace Apresentacao.Models.Patrimony.Settings
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
                    Percentual = totalProdutos != 0 ? marca.Value * 100 / totalProdutos : 0
                });
            }
            foreach (var categoria in contagemCategorias)
            {
                ContagemCategorias.Add(new CategoriaModel
                {
                    Nome = categoria.Key.Nome,
                    Percentual = totalProdutos != 0 ? categoria.Value * 100 / totalProdutos : 0
                });
            }
        }
    }
}


