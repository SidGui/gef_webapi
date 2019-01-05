using Gef.Data.Abstract;
using Gef.Model.Model;
using Gef.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
using Gef.Model.Interface.Operation;

namespace Gef.Data.Medicamento
{
    public class TipoMedicamento : Banco, IGet<Model.Model.TipoMedicamento>, ISave<Model.Model.TipoMedicamento>, IAlter<Model.Model.TipoMedicamento>, IDelete
    {
        public bool Alter(int id, Model.Model.TipoMedicamento item)
        {
             using (IDbConnection conn = base.connect())
            {
                
                return true;
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection conn = base.connect())
            {
             
            }

        }

        public IEnumerable<Model.Model.TipoMedicamento> Get(int id)
        {
            using (IDbConnection conn = base.connect())
            {
                throw new NotImplementedException("");
            }
        }

        public IEnumerable<Model.Model.TipoMedicamento> GetAll()
        {
            using (IDbConnection conn = base.connect())
            {
                return conn.Query<Model.Model.TipoMedicamento>
                    (sql: "getTipoMedicamento"
                      , commandType: CommandType.StoredProcedure
                    );
            }
        }

        public bool Save(Model.Model.TipoMedicamento item)
        {
            using (IDbConnection conn = base.connect())
            {
            
                return true;
            }
        }
    }
}
