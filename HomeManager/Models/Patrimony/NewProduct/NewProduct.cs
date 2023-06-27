using Dominio.Entidades;

namespace Apresentacao.Models.Patrimony.NewProduct
{
    public class NewProduct
    {
        public List<Marca> Marcas { get; set; } = new();
        public List<Categoria> Categorias { get; set; } = new();

        public NewProduct(List<Marca> marcas, List<Categoria> categorias)
        {
            this.Marcas = marcas;
            this.Categorias = categorias;
        }
    }
}
