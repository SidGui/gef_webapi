using System;
using System.Collections.Generic;
using System.Text;

namespace Gef.Model.Model
{
   public class Estoque
    {
        public int id { get; set; }
        public Medicamento medicamento { get; set; }
        public double quantidade { get; set; }
        public DateTime vencimento { get; set; }

    }
}
