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
        public bool Alter(Model.Model.Estoque item)
        {
            throw new NotImplementedException();
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
                    , splitOn: "id, id"
                    , map: (estoque, medicamento) => {
                        estoque.medicamento = medicamento;
                        return estoque;
                    }
                    );
            }
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
                    , splitOn: "id, id"
                    , map: (estoque, medicamento) => {
                        estoque.medicamento = medicamento;
                        return estoque;
                    }
                    );
            }
        }

        public bool Save(Model.Model.Estoque item)
        {
            throw new NotImplementedException();
        }
    }
}
