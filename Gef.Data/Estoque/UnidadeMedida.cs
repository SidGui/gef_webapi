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
    public class UnidadeMedida : Banco, IGet<Model.Model.UnidadeMedida>, ISave<Model.Model.UnidadeMedida>
    {
        public IEnumerable<Model.Model.UnidadeMedida> Get(int id)
        {
            using (IDbConnection conn = base.connect())
            {
                throw new NotImplementedException("");
            }
        }

        public IEnumerable<bool> Get(string nome)
        {
            throw new NotImplementedException();
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

        public bool Save(Model.Model.UnidadeMedida item)
        {
            try
            {
                using (IDbConnection conn = base.connect())
                {
                    DynamicParameters bParams = new DynamicParameters();
                    bParams.Add(name: "descricaoUnidadeMedida", value: item.descricaoUnidadeMedida, dbType: DbType.String);

                    conn.Execute(sql: "setUnidadeMedida", param: bParams, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }
    }
}
