using Gef.Model.Interface.Operation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gef.Business.Configuracao
{
    public class Parametro : IGet<Model.Model.Parametro>, IAlter<Model.Model.Parametro>, ISave<Model.Model.Parametro>, IDelete
    {
        private Data.Configuracao.Parametro _parametro = null;
        public bool Alter(int id, Model.Model.Parametro item)
        {
            try
            {
                _parametro = new Data.Configuracao.Parametro();
                _parametro.Alter(id, item);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _parametro = null;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Model.Parametro> Get(int id)
        {
            try
            {
                _parametro = new Data.Configuracao.Parametro();
                return _parametro.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _parametro = null;
            }
        }

        public IEnumerable<bool> Get(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Model.Parametro> GetAll()
        {
            try
            {
                _parametro = new Data.Configuracao.Parametro();
                return _parametro.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _parametro = null;
            }
        }

        public bool Save(Model.Model.Parametro item)
        {
            try
            {
                _parametro = new Data.Configuracao.Parametro();
                if (string.IsNullOrEmpty(item.valor))
                    throw new Exception("PLEASE SET A VALUE FOR THE PARAMETER");
                _parametro.Save(item);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _parametro = null;
            }

        }


    }
}
