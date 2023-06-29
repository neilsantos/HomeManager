using Dominio.Entidades;

namespace Apresentacao.Models.Dashboards.PatrimonyDashboard
{
    public class TopFive
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Percent { get; set; }

        public TopFive(string name, double price, double total)
        {
            Name = name;
            Price = price;
            Percent = total != 0 ? Math.Round(price * 100 / total) : 0;
        }
    }
}
