using Apresentacao.Models.PatrimonyDashboard;
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
            List<string> labels = new() { "Eletrônicos", "Móveis", "Eetrodomésticos", "Colecionáveis","Extra","Extra2", "Extra3" };
            List<int> data = new() { 50, 5, 5, 15,25,15,30 };
            var grafic = new Graphics(labels.Count, labels, data);

            //return JsonConvert.SerializeObject(grafic);
            return Ok(grafic);
        }

        public IActionResult PricePerCategory()
        {
            List<string> labels = new() { "Eletrônicos", "Móveis", "Eetrodomésticos", "Colecionáveis" };
            List<int> data = new() { 15207, 4270, 6470, 15000, 900 };
            var grafic = new Graphics(labels.Count, labels, data);

            //return JsonConvert.SerializeObject(grafic);
            return Ok(grafic);
        }



    }
}
