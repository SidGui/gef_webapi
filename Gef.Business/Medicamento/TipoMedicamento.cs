using System;
using System.Collections.Generic;
using System.Text;
using Gef.Model.Interface;
using Gef.Model.Interface.Operation;

namespace Gef.Business.Medicamento
{
    public class TipoMedicamento : IGet<Model.Model.TipoMedicamento>
    {
        protected Data.Medicamento.TipoMedicamento _tipoMedicamento = null;

        public IEnumerable<Model.Model.TipoMedicamento> Get(int id)
        {
            try
            {
                _tipoMedicamento = new Data.Medicamento.TipoMedicamento();
                return _tipoMedicamento.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _tipoMedicamento = null;
            }
        }

        public IEnumerable<Model.Model.TipoMedicamento> GetAll()
        {
            try
            {
                _tipoMedicamento = new Data.Medicamento.TipoMedicamento();
                return _tipoMedicamento.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _tipoMedicamento = null;
            }
            
        }

    }
}
