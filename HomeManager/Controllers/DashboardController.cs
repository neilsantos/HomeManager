using Apresentacao.Models.Dashboards.PatrimonyDashboard;
using Infraestrutura.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HomeManager.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult GeneralDashboard()
        {
            return View();
        }
        public IActionResult PatrimonyDashboard()
        {   
            RepositorioProduto repositorioProduto = new();
            var top5 = repositorioProduto.TopFiveProducts();
            
            List<ProductDashModel> products = new ();
            
            foreach (var p in top5)
            {
                products.Add(new(p.Nome, p.Modelo, p.Valor, p.NumeroDeSerie, p.Marca, p.Categoria));
            }
            return View(products);
        }
        public IActionResult FinancialDashboard()
        {
            ViewData["PageName"] = "Financial Dashboard";
            return View("~/views/shared/UnderConstruction.cshtml");
        }


        //-_---_--_-____-_--_---_---[CHARTS]____--__--_-_--_-____--__-_--___--_
        
        // # CATEGORY
        public IActionResult CountPerCategory()
        {
            RepositorioCategoria repositorioCategoria = new();

            var ContagemPorCategoria = repositorioCategoria.ContagemProdutoPorCategoria();

            List<string> labels = new();
            List<double> data = new();
            foreach (var categoria in ContagemPorCategoria)
            {
                if (categoria.Value == 0)
                    continue;
                labels.Add(categoria.Key.Nome.ToString());
                data.Add(categoria.Value);
            }

            var grafic = new Graphics(labels.Count, labels, data);

            //return JsonConvert.SerializeObject(grafic);
            return Ok(grafic);
        }
        public IActionResult TotalPricePerCategory()
        {
            RepositorioCategoria repositorioCategoria = new();

            var pricesPerCategory = repositorioCategoria.PricePerCategory();

            List<string> labels = new();
            List<double> data = new();
            foreach (var category in pricesPerCategory)
            {
                if (category.Value == 0)
                    continue;
                labels.Add(category.Key.Nome.ToString());
                data.Add(Math.Round(category.Value,2));
            }

            var grafic = new Graphics(labels.Count, labels, data);

            //return JsonConvert.SerializeObject(grafic);
            return Ok(grafic);
        }
        public IActionResult TopFiveCategories()
        {
            RepositorioCategoria repositorioCategoria = new();

            var topFive = repositorioCategoria.TopFiveCategories();

            var total = topFive.Values.Sum();

            List<TopFive> topfive = new();
            foreach (var item in topFive)
            {
                topfive.Add(new(item.Key.Nome, item.Value, total));
            }

            return Ok(topfive);
        }

        // # BRANDS
        public IActionResult CountPerBrand()
        {
            RepositorioMarca repositorioMarca = new();

            var CountPerBrand = repositorioMarca.ContagemProdutoPorMarca();

            List<string> labels = new();
            List<double> data = new();
            foreach (var brand in CountPerBrand)
            {
                if (brand.Value == 0)
                    continue;
                labels.Add(brand.Key.Nome.ToString());
                data.Add(brand.Value);
            }

            var grafic = new Graphics(labels.Count, labels, data);

            //return JsonConvert.SerializeObject(grafic);
            return Ok(grafic);
        }
        public IActionResult TotalPricePerBrand()
        {
            RepositorioMarca repositorioMarca = new();

            var pricePerBrand = repositorioMarca.PricesPerBrands();

            List<string> labels = new();
            List<double> data = new();
            foreach (var brand in pricePerBrand)
            {
                if (brand.Value == 0)
                    continue;
                labels.Add(brand.Key.Nome.ToString());
                data.Add(Math.Round(brand.Value, 2));
            }

            var grafic = new Graphics(labels.Count, labels, data);

            //return JsonConvert.SerializeObject(grafic);
            return Ok(grafic);
        }
        public IActionResult TopFiveBrands()
        {
            RepositorioMarca repositorioMarca = new();

            var topFive = repositorioMarca.TopFiveBrands();

            var total = topFive.Values.Sum();

            List<TopFive> topfive = new();
            foreach (var item in topFive)
            {
                topfive.Add(new(item.Key.Nome, Math.Round(item.Value, 2), Math.Round(total)));
            }

            return Ok(topfive);
        }
        
    }
}
