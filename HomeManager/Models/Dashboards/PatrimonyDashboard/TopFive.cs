using Dominio.Entidades;
using System.Globalization;

namespace Apresentacao.Models.Dashboards.PatrimonyDashboard
{
    public class TopFive
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Percent { get; set; }

        public TopFive(string name, double price, double total)
        {
            Name = name;
            var calc = total != 0 ? Math.Round((price * 100 / total),2) : 0;
            Percent = calc.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"));
            Price = price.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"));
        }
    }
}
