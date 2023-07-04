using Apresentacao.Models.Patrimony.NewProduct;
using Apresentacao.Models.Patrimony.General;
using Apresentacao.Models.Patrimony.Settings;
using Dominio.Entidades;
using Infraestrutura;
using Infraestrutura.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dominio.Interfaces;
using System.Globalization;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Apresentacao.Controllers
{
    public class PatrimonyController : Controller
    {
        // -_---_--_-____-_--_---_---[READ]____--__--_-_--_-____--__-_--___--_
        public IActionResult Index()
        {
            RepositorioProduto repositorioProduto = new();
            var allProducts = repositorioProduto.GetFullProducts();

            List<Products> products = new();

            foreach (var p in allProducts)
            {
                var price = p.Valor.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"));
                products.Add(new(p.Id, p.Nome, p.Modelo, p.Marca.Nome, p.Categoria.Nome, price, p.NumeroDeSerie));
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
        [HttpPut]
        public async Task<IActionResult> UpdateBrand([FromServices] Context context, [FromBody] MarcaModel marca, [FromRoute] int id)
        {

            Marca? m = context.Marcas.Find(id);

            if (m == null)
                return NotFound();

            m.Nome = marca.Nome;

            try
            {
                context.Marcas.Update(m);
                await context.SaveChangesAsync();
                return Ok();

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromServices] Context context, [FromBody] CategoriaModel categoria, [FromRoute] int id)
        {

            Categoria? m = context.Categorias.Find(id);

            if (m == null)
                return NotFound();

            m.Nome = categoria.Nome;

            try
            {
                context.Categorias.Update(m);
                await context.SaveChangesAsync();
                return Ok();

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromServices] Context context, [FromBody] NewProduct product, [FromRoute] int id)
        {
            Produto? p = context.Produtos.Find(id);

            if (p == null)
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
        [HttpDelete]
        public IActionResult DeleteBrand([FromServices] Context context, [FromRoute] int id)
        {
            Marca? m = context.Marcas.Find(id);

            if (m == null)
                return NotFound();

            try
            {
                context.Marcas.Remove(m);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpDelete]
        public IActionResult DeleteCategory([FromServices] Context context, [FromRoute] int id)
        {
            RepositorioProduto repositorioProduto = new();

            Categoria? c = context.Categorias.Find(id);

            if (c == null)
                return NotFound();

            try
            {
                context.Categorias.Remove(c);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpGet]
        public IActionResult ConsultBound(string type, int id)
        {
            if (string.IsNullOrEmpty(type) || id == 0)
            {
                return BadRequest();
            }

            RepositorioProduto repositorioProduto = new();
            List<Produto> products = new();

            if (type == "category")
            {
                products = repositorioProduto.GetProductsByCategory(id);
            }
            if (type == "brand")
            {
                products = repositorioProduto.GetProductsByBrand(id);
            }

            List<Products> productsList = new();
            foreach (var p in products)
            {
                var price = p.Valor.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"));
                productsList.Add(new(p.Id, p.Nome, p.Modelo, p.Marca.Nome, p.Categoria.Nome, price, p.NumeroDeSerie));
            }
            

            return Ok(productsList);
        }
        public IActionResult DeleteProduct([FromServices] Context context, [FromRoute] int id)
        {
            Produto? p = context.Produtos.Find(id);

            if (p == null)
                return NotFound();

            try
            {
                context.Produtos.Remove(p);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

    }
}
