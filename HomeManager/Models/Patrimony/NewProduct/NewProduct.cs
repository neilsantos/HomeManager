using Dominio.Entidades;

namespace Apresentacao.Models.Patrimony.NewProduct
{
    public class NewProduct
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }
        public string SerialNumber { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        
    }
}
