using Apresentacao.Models.Patrimony.NewProduct;
using Apresentacao.Models.Patrimony.General;
using Apresentacao.Models.Patrimony.Settings;
using Dominio.Entidades;
using Infraestrutura;
using Infraestrutura.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apresentacao.Controllers
{
    public class PatrimonyController : Controller
    {
        // -_---_--_-____-_--_---_---[READ]____--__--_-_--_-____--__-_--___--_
        public IActionResult Index([FromServices] Context context)
        {
            RepositorioProduto repositorioProduto = new();
            var allProducts = repositorioProduto.GetFullProducts();

            List<Products> products = new();
            foreach (var p in allProducts)
            {
                products.Add(new(p.Id,p.Nome,p.Modelo, p.Marca.Nome, p.Categoria.Nome, p.Valor,p.NumeroDeSerie));
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
        public IActionResult BrandsNCategories()
        {
            RepositorioCategoria categoryRepository = new();
            RepositorioMarca brandRepository = new();

            var categories = categoryRepository.Ler().ToList();
            var brands = brandRepository.Ler().ToList();

            BrandsAndCategories product = new(brands, categories);
            return Ok(product);
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
        public async Task<IActionResult> NewBrand([FromServices] Context context, [FromBody] Marca marca)
        {
            try
            {
                await context.Marcas.AddAsync(marca);
                await context.SaveChangesAsync();
                return Ok();

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> NewCategory([FromServices] Context context, [FromBody] Categoria categoria)
        {
            try
            {
                await context.Categorias.AddAsync(categoria);
                await context.SaveChangesAsync();
                return Ok();

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> NewProduct([FromServices] Context context, [FromBody] NewProduct product)
        {   
            var category = context.Categorias.Find(product.CategoryId);
            var brand = context.Marcas.Find(product.BrandId);
            var price = double.Parse(product.Price);
            
            Produto produto = new(product.Name, product.Model, category, brand, price);
            
            try
            {
                await context.Produtos.AddAsync(produto);
                await context.SaveChangesAsync();
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

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromServices] Context context, [FromBody] NewProduct product, [FromRoute] int id)
        {
            RepositorioProduto repositorioProduto = new();

            Produto? p = context.Produtos.Find(id);
            
            if(p == null)
                return NotFound();

            var category = context.Categorias.Find(product.CategoryId);
            var brand = context.Marcas.Find(product.BrandId);
            var price = double.Parse(product.Price);

            p.Nome = product.Name;
            p.Modelo = product.Model;
            p.Marca = brand;
            p.Categoria = category;
            p.Valor = price;

            try
            {
                context.Produtos.Update(p);
                await context.SaveChangesAsync();
                return Ok();

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
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
