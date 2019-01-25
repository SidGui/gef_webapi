using System;
using System.Collections.Generic;
using System.Text;
using Gef.Model.Interface;
using Gef.Model.Interface.Operation;
using Gef.Model.Model;

namespace Gef.Business.Medicamento
{
    public class ViaAdministracao : IGet<Model.Model.ViaAdministracao> , ISave<Model.Model.ViaAdministracao>
    {
        protected Data.Medicamento.ViaAdministracao _viaAdministracao = null;

        public IEnumerable<Model.Model.ViaAdministracao> Get(int id)
        {
          throw new NotImplementedException();
        }

        public IEnumerable<bool> Get(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Model.ViaAdministracao> GetAll()
        {
            try
            {
                _viaAdministracao = new Data.Medicamento.ViaAdministracao();
                return _viaAdministracao.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _viaAdministracao = null;
            }
            
        }

        public bool Save(Model.Model.ViaAdministracao item)
        {
            try
            {
                _viaAdministracao = new Data.Medicamento.ViaAdministracao();
                return _viaAdministracao.Save(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _viaAdministracao = null;
            }
        }
    }
}
