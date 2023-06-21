using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestrutura.Repositorios;

namespace Apresentacao.Models
{
    public class PatrimonySettings
    {
        public List<Marca> GetBrands() 
        {
            Repositorio<Marca> marcaRepositorio = new Repositorio<Marca>();
            List<Marca>? marcas = marcaRepositorio.Ler().ToList<Marca>();

            return marcas;
        }
        public List<Categoria> GetCategories() 
        {
            RepositorioCategoria categoriaRepositorio = new RepositorioCategoria();
            List<Categoria>? categorias = categoriaRepositorio.Ler().ToList();

            return categorias;
        }
    }

}
