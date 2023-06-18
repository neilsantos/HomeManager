using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.ViewEngines;

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

        public int[] Grafico()
        {
            int[] valores = new int[]{ 10, };
            return valores;
        }



    }
}
