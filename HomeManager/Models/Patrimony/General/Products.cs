using Dominio.Entidades;
namespace Apresentacao.Models.Patrimony.General;

public class Products
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public string Category { get; set; }
    public string Price { get; set; }
    public string SerialNumber { get; set; }

    public Products(int id, string name, string model, string brand, string category, string price, string serialNumber)
    {
        Id = id;
        Name = name;
        Model = model;
        Brand = brand;
        Category = category;
        Price = price;
        SerialNumber = serialNumber;
    }

}
