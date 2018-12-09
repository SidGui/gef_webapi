using Gef.Model.Interface;
using Gef.Model.Interface.Operation;
using Gef.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gef.Business.Estoque
{
    public class Estoque : IGet<Model.Model.Estoque>, IAlter<Model.Model.Estoque>, ISave<Model.Model.Estoque>, IDelete
    {
        private Data.Estoque.Estoque _estoque = null;
        public bool Alter(Model.Model.Estoque item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Model.Estoque> Get(int id)
        {
            try
            {
                _estoque = new Data.Estoque.Estoque();
                return _estoque.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _estoque = null;
            }
        }

        public IEnumerable<Model.Model.Estoque> GetAll()
        {
            try
            {
                _estoque = new Data.Estoque.Estoque();
                return _estoque.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _estoque = null;
            }
        }

        public bool Save(Model.Model.Estoque item)
        {
            throw new NotImplementedException();
        }
    }
}
