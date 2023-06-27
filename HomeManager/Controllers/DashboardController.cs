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

            return View();
        }
        public IActionResult FinancialDashboard()
        {
            ViewData["PageName"] = "Financial Dashboard";
            return View("~/views/shared/UnderConstruction.cshtml");
        }

        public IActionResult CountPerCategory()
        {
            RepositorioProduto repositorioProduto = new();
            RepositorioCategoria repositorioCategoria = new();

            var ContagemPorCategoria = repositorioCategoria.ContagemProdutoPorCategoria();
            var ContagemProdutos = repositorioProduto.Count();

            List<string> labels = new();
            List<int> data = new();
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

        public IActionResult PricePerCategory()
        {
            List<string> labels = new() { "Eletrônicos", "Móveis", "Eletrodomésticos", "Colecionáveis" };
            List<int> data = new() { 15207, 4270, 6470, 15000, 900 };
            var grafic = new Graphics(labels.Count, labels, data);

            //return JsonConvert.SerializeObject(grafic);
            return Ok(grafic);
        }
    }
}
