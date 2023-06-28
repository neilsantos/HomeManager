using Apresentacao.Models.Patrimony.NewProduct;
using Apresentacao.Models.Patrimony.Products;
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
            RepositorioProduto repositorioProduto = new();
            var allProducts = repositorioProduto.Ler().ToList();

            List<Products> products = new();
            foreach (var product in allProducts)
            {
                products.Add(new(product.Nome, product.Marca.Nome, product.Categoria.Nome,product.Valor.ToString()));
            }

            return View(products);
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

            BrandsAndCategories product = new(brands, categories);
            return View(product);
        }

        public IActionResult ViewProduct()
        {
            return View();
        }


        //C-UD
        // -_---_--_-____-_--_---_---[CREATE]____--__--_-_--_-____--__-_--___--_
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
        public async Task<IActionResult> NewProduct([FromServices] Context contexto, [FromBody] NewProduct product)
        {
            var category = contexto.Categorias.Find(product.CategoryId);
            var brand = contexto.Marcas.Find(product.BrandId);
            var price = double.Parse(product.Price);
            Produto produto = new(product.Name, product.Model, category, brand, price);
            try
            {
                await contexto.Produtos.AddAsync(produto);
                await contexto.SaveChangesAsync();
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // -_---_--_-____-_--_---_---[UPDATE]____--__--_-_--_-____--__-_--___--_
        public IActionResult UpdateBrand()
        {
            return View();
        }
        public IActionResult UpdateCategory()
        {
            return View();
        }
        public IActionResult UpdateProduct()
        {
            return View();
        }


        // -_---_--_-____-_--_---_---[DELETE]____--__--_-_--_-____--__-_--___--_
        public IActionResult DeleteBrand()
        {
            return View();
        }
        public IActionResult DeleteCategory()
        {
            return View();
        }
        public IActionResult DeleteProduct()
        {
            return View();
        }

    }
}
