using System;
using System.Collections.Generic;
using System.Text;
using Gef.Model.Interface;
using Gef.Model.Interface.Operation;

namespace Gef.Business.Medicamento
{
    public class Medicamento : IGet<Model.Model.Medicamento>, IAlter<Model.Model.Medicamento>, ISave<Model.Model.Medicamento>, IDelete
    {
        protected Data.Medicamento.Medicamento _medicamento = null;

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Model.Medicamento> Get(int id)
        {
            try
            {
                _medicamento = new Data.Medicamento.Medicamento();
                return _medicamento.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _medicamento = null;
            }
        }

        public IEnumerable<Model.Model.Medicamento> GetAll()
        {
            try
            {
                _medicamento = new Data.Medicamento.Medicamento();
                return _medicamento.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _medicamento = null;
            }
            
        }

        public bool Save(Model.Model.Medicamento item)
        {
            throw new NotImplementedException();
        }

        public bool Alter(Model.Model.Medicamento item)
        {
            throw new NotImplementedException();
        }
    }
}
