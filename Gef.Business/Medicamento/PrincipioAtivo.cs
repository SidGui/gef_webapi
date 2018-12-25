using System;
using System.Collections.Generic;
using System.Text;
using Gef.Model.Interface;
using Gef.Model.Interface.Operation;

namespace Gef.Business.Medicamento
{
    public class PrincipioAtivo : IGet<Model.Model.PrincipioAtivo>
    {
        protected Data.Medicamento.PrincipioAtivo _principioAtivo = null;

        public IEnumerable<Model.Model.PrincipioAtivo> Get(int id)
        {
          throw new NotImplementedException();
        }

        public IEnumerable<Model.Model.PrincipioAtivo> GetAll()
        {
            try
            {
                _principioAtivo = new Data.Medicamento.PrincipioAtivo();
                return _principioAtivo.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _principioAtivo = null;
            }
            
        }
    }
}
