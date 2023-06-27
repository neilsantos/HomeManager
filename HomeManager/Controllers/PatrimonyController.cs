using Apresentacao.Models.Patrimony.NewProduct;
using Apresentacao.Models.Patrimony.Settings;
using Dominio.Entidades;
using Infraestrutura;
using Infraestrutura.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Apresentacao.Controllers
{
    public class PatrimonyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Settings()
        {
            RepositorioMarca repositorioMarca = new();
            RepositorioProduto repositorioProduto = new();
            RepositorioCategoria repositorioCategoria = new();

            var ContagemPorMarca = repositorioMarca.ContagemProdutoPorMarca();
            var ContagemPorCategoria = repositorioCategoria.ContagemProdutoPorCategoria();
            var ContagemProdutos = repositorioProduto.Count();

            PatrimonySettings patrimonySettings = new(ContagemPorMarca, ContagemPorCategoria, ContagemProdutos);

            return View(patrimonySettings);
        }

        public IActionResult NewProduct()
        {   
            RepositorioCategoria categoryRepository = new();
            RepositorioMarca brandRepository = new();

            var categories = categoryRepository.Ler().ToList();
            var brands = brandRepository.Ler().ToList();

            NewProduct product = new(brands,categories);
            return View(product);
        }

        public IActionResult ViewProduct()
        {
            return View();
        }


        //CRUD
        [HttpPost]
        public async Task<IActionResult> NewBrand([FromServices] Context contexto, [FromBody] Marca marca)
        {
            try
            {
                await contexto.Marcas.AddAsync(marca);
                await contexto.SaveChangesAsync();
                return Ok();

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> NewCategory([FromServices] Context contexto, [FromBody] Categoria categoria)
        {
            try
            {
                await contexto.Categorias.AddAsync(categoria);
                await contexto.SaveChangesAsync();
                return Ok();

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> NewProduct([FromServices] Context contexto, [FromBody] Produto produto)
        {
            try
            {
                await contexto.Produtos.AddAsync(produto);
                await contexto.SaveChangesAsync();
                return Ok();

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }


    }
}
