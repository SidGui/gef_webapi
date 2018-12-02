using System;
using System.Collections.Generic;
using System.Text;
using Gef.Model.Interface;

namespace Gef.Business.Medicamento
{
    public class Medicamento : Get<Model.Model.Medicamento>, Alter<Model.Model.Medicamento>, Save<Model.Model.Medicamento>, Delete
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
