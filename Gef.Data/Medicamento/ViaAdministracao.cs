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
    public class ViaAdministracao : Banco, IGet<Model.Model.ViaAdministracao>, ISave<Model.Model.ViaAdministracao>
    {
        public IEnumerable<Model.Model.ViaAdministracao> Get(int id)
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

        public IEnumerable<Model.Model.ViaAdministracao> GetAll()
        {
            using (IDbConnection conn = base.connect())
            {
                return conn.Query<Model.Model.ViaAdministracao>
                    (sql: "getViaAdministracao"
                      , commandType: CommandType.StoredProcedure
                    );
            }
        }

        public bool Save(Model.Model.ViaAdministracao item)
        {//via_administracao
            try
            {
                using (IDbConnection conn = base.connect())
                {
                    DynamicParameters bParams = new DynamicParameters();
                    bParams.Add(name: "descricaoViaAdministracao", value: item.descricaoViaAdministracao, dbType: DbType.String);

                    conn.Execute(sql: "setViaAdministracao", param: bParams, commandType: CommandType.StoredProcedure);

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
