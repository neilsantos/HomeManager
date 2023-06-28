using Dominio.Entidades;
namespace Apresentacao.Models.Patrimony.General;

public class Products
{
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public double Price { get; set; }

    public Products(string name, string brand, string model, double price)
    {
        Name = name;
        Brand = brand;
        Model = model;
        Price = price;
    }
}
