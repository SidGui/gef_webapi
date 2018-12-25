using System;
using System.Collections.Generic;
using System.Text;

namespace Gef.Model.Model
{
    public class Medicamento
    {
        public int id { get; set; }
        public string nomeMedicamento { get; set; }
        public TipoMedicamento tipoMedicamento { get; set; }
        public DateTime dataCadastro { get; set; }
        public string observacao { get; set; }
        public bool cadastroCompleto { get; set; }
        public bool ativo { get; set; }
        public double quantidadeEstoqueCritico { get; set; }
        public string nomeAnvisa { get; set; }
        public PrincipioAtivo principioAtivo { get; set; }
 public ViaAdministracao viaAdministracao { get; set; }
        public UnidadeMedida unidadeMedida { get; set; }
    }
}
