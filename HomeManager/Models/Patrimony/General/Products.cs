using Dominio.Entidades;
using Microsoft.Extensions.ObjectPool;

namespace Apresentacao.Models.Patrimony.Products
{
    public class Products
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }
        
        public Products(string name, string brand,string model, string price)
        {   
            Name = name;
            Brand = brand;
            Model = model;
            Price = price;
        }
    }
}
