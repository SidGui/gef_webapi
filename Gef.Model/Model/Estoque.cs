using System;
using System.Collections.Generic;
using System.Text;

namespace Gef.Model.Model
{
   public class Estoque
    {
        public int idEstoque { get; set; }
        public Medicamento medicamento { get; set; }
        public int quantidadeEstoque { get; set; }
        public DateTime vencimento { get; set; }
        public string procedencia {get;set;}

    }
}
