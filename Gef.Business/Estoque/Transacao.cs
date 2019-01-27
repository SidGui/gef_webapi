using Gef.Model.Interface.Operation;
using Gef.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gef.Business.Estoque
{
    public class Transacao : IGet<Model.Model.Transacao>, ISave<Model.Model.Transacao>
    {
        private Data.Estoque.Transacao _transacao = null;
        public IEnumerable<Model.Model.Transacao> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<bool> Get(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Model.Transacao> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save(Model.Model.Transacao item)
        {
            try
            {
                _transacao = new Data.Estoque.Transacao();
                if (item.quantidade == 0)
                    throw new Exception("QUANTIDADE DEVE SER MAIOR QUE 0");

                IEnumerable<Model.Model.Estoque> estoque = new Data.Estoque.Estoque().Get(item.medicamento.id);

                if (estoque.FirstOrDefault() == null)
                    throw new Exception("NÃO FOI ENCONTRADO O MEDICAMENTO EM ESTOQUE.");

                if (estoque.Count(c => c.idEstoque == item.estoque.idEstoque) == 0)
                    throw new Exception("ID DO ESTOQUE INVALIDO");

                if (item.eTipoTransacao == Model.Enum.eTransacao.eTipoTransacao.Saida)
                {
                    item.quantidade = item.quantidade * -1;
                    _transacao.Save(item);
                }
                else
                    throw new Exception("OPERAÇÃO NÃO IMPLEMENTADA");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _transacao = null;
            }

        }
    }
}
