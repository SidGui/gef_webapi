using Dapper;
using Gef.Data.Abstract;
using Gef.Model.Interface.Operation;
using Gef.Model.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Gef.Data.Estoque
{
    public class Estoque : Banco, IGet<Model.Model.Estoque>, ISave<Model.Model.Estoque>, IAlter<Model.Model.Estoque>, IDelete
    {
        public bool Alter(int id, Model.Model.Estoque item)
        {
           try {
            //    using (IDbConnection conn = base.connect()) {
            //             DynamicParameters bParams = new DynamicParameters();
            //          bParams.Add(name: "ativo", value: item., dbType: DbType.Boolean);
            //          bParams.Add(name: "idMedicamento", value: id, dbType: DbType.Int32);
            //    }
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
            catch(MySql.Data.MySqlClient.MySqlException ex){
                throw ex;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Model.Estoque> Get(int id)
        {
            using (IDbConnection conn = base.connect())
            {
                DynamicParameters bParams = new DynamicParameters();
                bParams.Add(name: "idMedicamento", value: id, dbType: DbType.Int32);
                return conn.Query<Model.Model.Estoque
                    , Model.Model.Medicamento
                    , Model.Model.Estoque>(sql: "getEstoque"
                    , commandType: CommandType.StoredProcedure
                    , param: bParams
                    , splitOn: "idEstoque, id"
                    , map: (estoque, medicamento) => {
                        estoque.medicamento = medicamento;
                        return estoque;
                    }
                    );
            }
        }

        public IEnumerable<bool> Get(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Model.Estoque> GetAll()
        {
            using (IDbConnection conn = base.connect())
            {
                DynamicParameters bParams = new DynamicParameters();
                bParams.Add(name: "idMedicamento", value: null, dbType: DbType.Int32);
                return conn.Query<Model.Model.Estoque
                    , Model.Model.Medicamento
                    , Model.Model.Estoque>(sql: "getEstoque"
                    , commandType: CommandType.StoredProcedure
                    , param: bParams
                    , splitOn: "idEstoque, id"
                    , map: (estoque, medicamento) => {
                        estoque.medicamento = medicamento;
                        return estoque;
                    }
                    );
            }
        }

        public bool Save(Model.Model.Estoque item)
        {
            try{
                using (IDbConnection conn = base.connect()) {
                    DynamicParameters bParams = new DynamicParameters();
                    bParams.Add(name: "idMedicamento", value: item.medicamento.id, dbType: DbType.Int32);
                    bParams.Add(name: "quantidade", value: item.quantidadeEstoque, dbType: DbType.Int32);
                    bParams.Add(name: "vencimento", value: item.vencimento, dbType: DbType.DateTime);
                    bParams.Add(name: "procedencia", value: item.procedencia, dbType: DbType.String);
                    conn.Execute(sql: "setEstoque"
                        , commandType: CommandType.StoredProcedure
                        , param: bParams
                    );
                }
                return true;
            }
            catch(MySql.Data.MySqlClient.MySqlException ex) {
                throw ex;
            }
            finally {
                var a  = "oi";
            }
        }
    }
}
