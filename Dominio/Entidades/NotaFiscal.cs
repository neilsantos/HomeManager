using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    internal class NotaFiscal
    {
        public string Local { get; set; } = "Url não informado";
        public string Numero { get; set; } = "Número não informado";
        public int IdProduto { get; set; }
    }
}
