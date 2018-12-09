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
    public class Medicamento : Banco, IGet<Model.Model.Medicamento>, ISave<Model.Model.Medicamento>, IAlter<Model.Model.Medicamento>, IDelete
    {
        public bool Alter(Model.Model.Medicamento item)
        {
            using (IDbConnection conn = base.connect())
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection conn = base.connect())
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Model.Model.Medicamento> Get(int id)
        {
            using (IDbConnection conn = base.connect())
            {
                DynamicParameters bParams = new DynamicParameters();
                bParams.Add(name: "idMedicamento", value: id, dbType: DbType.Int32);
                return conn.Query<Model.Model.Medicamento
                    , Model.Model.TipoMedicamento
                    , Model.Model.PrincipioAtivo
                    , Model.Model.Medicamento>(sql: "getMedicamento"
                    , commandType: CommandType.StoredProcedure
                    , param: bParams
                    , splitOn: "id, id, id"
                    , map: (medicamento, tipoMedicamento, principioAtivo) => {
                        medicamento.tipoMedicamento = tipoMedicamento;
                        medicamento.principioAtivo = principioAtivo;
                        return medicamento;
                    }
                    );
            }
        }

        public IEnumerable<Model.Model.Medicamento> GetAll()
        {
            using (IDbConnection conn = base.connect())
            {
                DynamicParameters bParams = new DynamicParameters();
                bParams.Add(name: "idMedicamento", value: null, dbType: DbType.Int32); 
                return conn.Query<Model.Model.Medicamento
                    , Model.Model.TipoMedicamento
                    , Model.Model.PrincipioAtivo
                    , Model.Model.Medicamento>(sql: "getMedicamento"
                    , commandType: CommandType.StoredProcedure
                    , param: bParams
                    , splitOn: "id, id, id"
                    , map: (medicamento, tipoMedicamento, principioAtivo) => {
                       medicamento.tipoMedicamento = tipoMedicamento;
                        medicamento.principioAtivo = principioAtivo;
                        return medicamento;
                     }
                    );
            }
        }

        public bool Save(Model.Model.Medicamento item)
        {
            using (IDbConnection conn = base.connect())
            {
                throw new NotImplementedException();
            }
        }
    }
}
