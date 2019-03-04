using Dapper;
using Gef.Data.Abstract;
using Gef.Model.Interface.Operation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Gef.Data.Configuracao
{
    public class Parametro : Banco, IGet<Model.Model.Parametro>, ISave<Model.Model.Parametro>, IAlter<Model.Model.Parametro>, IDelete
    {
        public bool Alter(int id, Model.Model.Parametro item)
        {
            try
            {
                using (IDbConnection conn = base.connect())
                {
                    DynamicParameters bParams = new DynamicParameters();
                    bParams.Add(name: "valor", value: item.valor, dbType: DbType.Boolean);
                    bParams.Add(name: "id", value: id, dbType: DbType.Int32);

                    conn.Execute(sql: "alterParametro", param: bParams, commandType: CommandType.StoredProcedure);
                }
                // using (IDbConnection conn = base.connect()) {
                //     DynamicParameters bParams = new DynamicParameters();
                //     bParams.Add(name: "ativo", value: item.ativo, dbType: DbType.Boolean);
                //     bParams.Add(name: "idMedicamento", value: id, dbType: DbType.Int32);
                //     bParams.Add(name: "cadastroCompleto", value: item.cadastroCompleto, dbType: DbType.Boolean);
                //     //bParams.Add(name: "", value: item.cadastroCompleto, dbType: DbType.Boolean); 
                //     bParams.Add(name: "nomeMedicamento", value: item.nomeMedicamento, dbType: DbType.String);
                //     bParams.Add(name: "estoqueCritico", value: item.quantidadeEstoqueCritico, dbType: DbType.Double);

                //     conn.Execute(sql: "alterMedicamento", param: bParams, commandType: CommandType.StoredProcedure);

                return true;
                //}
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Model.Parametro> Get(int id)
        {
            using (IDbConnection conn = base.connect())
            {
                DynamicParameters bParams = new DynamicParameters();
                bParams.Add(name: "idParametro", value: id, dbType: DbType.Int32);
                return conn.Query<Model.Model.Parametro>(sql: "getParametro"
                    , commandType: CommandType.StoredProcedure
                    , param: bParams
                    );
            }
        }

        public IEnumerable<bool> Get(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Model.Parametro> GetAll()
        {
            using (IDbConnection conn = base.connect())
            {
                DynamicParameters bParams = new DynamicParameters();
                bParams.Add(name: "idParametro", value: null, dbType: DbType.Int32);
                return conn.Query<Model.Model.Parametro>(sql: "getParametro"
                    , commandType: CommandType.StoredProcedure
                    , param: bParams
                    );
            }
        }

        public bool Save(Model.Model.Parametro item)
        {
            try
            {
                using (IDbConnection conn = base.connect())
                {
                    DynamicParameters bParams = new DynamicParameters();
                    bParams.Add(name: "descricaoParametro", value: item.descricao, dbType: DbType.String);
                    bParams.Add(name: "valor", value: item.valor, dbType: DbType.String);
                    bParams.Add(name: "tipo", value: item.tipo, dbType: DbType.String);
                    conn.Execute(sql: "setParametro"
                        , commandType: CommandType.StoredProcedure
                        , param: bParams
                    );
                }
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
    }
}
