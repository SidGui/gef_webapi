using Gef.Data.Abstract;
using Gef.Model.Model;
using Gef.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
using Gef.Model.Interface.Operation;

namespace Gef.Data.Estoque
{
    public class UnidadeMedida : Banco, IGet<Model.Model.UnidadeMedida>
    {
        public IEnumerable<Model.Model.UnidadeMedida> Get(int id)
        {
            using (IDbConnection conn = base.connect())
            {
                throw new NotImplementedException("");
            }
        }

        public IEnumerable<Model.Model.UnidadeMedida> GetAll()
        {
            using (IDbConnection conn = base.connect())
            {
                return conn.Query<Model.Model.UnidadeMedida>
                    (sql: "getUnidadeMedida"
                      , commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
