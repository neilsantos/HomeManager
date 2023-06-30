using System.ComponentModel.DataAnnotations;

namespace Apresentacao.Models.Patrimony.Settings
{
    public class MarcaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Percentual { get; set; }
    }
}
