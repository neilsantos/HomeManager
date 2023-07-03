using Dominio.Entidades;
using System.Globalization;

namespace Apresentacao.Models.Dashboards.PatrimonyDashboard
{
    public class ProductDashModel
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }
        public string SerialNumber { get; set; }
        public Marca Brand{ get; set; }
        public Categoria Category{ get; set; }

        public ProductDashModel(string name, string model, double price, string serialNumber, Marca brand, Categoria category)
        {
            Name = name;
            Model = model;
            Price = price.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"));
            SerialNumber = serialNumber;
            Brand = brand;
            Category = category;
        }
    }
}
