using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Infraestrutura;
using Dominio.Entidades;
using Infraestrutura.Repositorios;

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
           

            return View(marcas);
        }

        public IActionResult NewProduct()
        {
            return View();
        }

    }
}
