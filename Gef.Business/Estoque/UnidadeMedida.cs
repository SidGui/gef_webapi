using System;
using System.Collections.Generic;
using System.Text;
using Gef.Model.Interface;
using Gef.Model.Interface.Operation;

namespace Gef.Business.Estoque
{
    public class UnidadeMedida : IGet<Model.Model.UnidadeMedida>
    {
        protected Data.Estoque.UnidadeMedida _unidadeMedida = null;

        public IEnumerable<Model.Model.UnidadeMedida> Get(int id)
        {
          throw new NotImplementedException();
        }

        public IEnumerable<Model.Model.UnidadeMedida> GetAll()
        {
            try
            {
                _unidadeMedida = new Data.Estoque.UnidadeMedida();
                return _unidadeMedida.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _unidadeMedida = null;
            }
            
        }
    }
}
