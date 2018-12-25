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
    public class PrincipioAtivo : Banco, IGet<Model.Model.PrincipioAtivo>
    {
        public IEnumerable<Model.Model.PrincipioAtivo> Get(int id)
        {
            using (IDbConnection conn = base.connect())
            {
                throw new NotImplementedException("");
            }
        }

        public IEnumerable<Model.Model.PrincipioAtivo> GetAll()
        {
            using (IDbConnection conn = base.connect())
            {
                return conn.Query<Model.Model.PrincipioAtivo>
                    (sql: "getPrincipioAtivo"
                      , commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
