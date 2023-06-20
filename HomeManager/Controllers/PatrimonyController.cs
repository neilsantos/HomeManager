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
            Repositorio<Marca> marcaRepositorio = new Repositorio<Marca>();
            List<Marca>? marcas = marcaRepositorio.Ler().ToList<Marca>();

            Repositorio<Marca> categoriaRepositorio = new Repositorio<Marca>();
            List<Marca>? categorias = categoriaRepositorio.Ler().ToList();

            ViewData["Brands"] = marcas;
            ViewData["Categories"] = categorias;


            return View();
        }

        public IActionResult NewProduct()
        {
            return View();
        }

    }
}
