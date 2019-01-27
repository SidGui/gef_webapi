using System;
using System.Collections.Generic;
using System.Text;
using static Gef.Model.Enum.eTransacao;

namespace Gef.Model.Model
{
    public class Transacao
    {
        public int idReceita { get; set; }
        public Medicamento medicamento { get; set; }
        public Estoque estoque { get; set; }
        public DateTime dataTransacao { get; set; }
        public int quantidade { get; set; }
        public eTipoTransacao eTipoTransacao { get; set; }
    }
}
