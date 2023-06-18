using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class NotaFiscal:EntidadeBase
    {
        public string Url { get; set; } = "Url não informado";
        public string RefNumber { get; set; } = "Número não informado";
        //public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }


        public NotaFiscal()
        {
            
        }

    }

}
