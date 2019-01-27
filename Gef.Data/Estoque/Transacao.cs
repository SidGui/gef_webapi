using Dapper;
using Gef.Model.Interface.Operation;
using Gef.Model.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Gef.Data.Estoque
{
    public class Transacao : Abstract.Banco, IGet<Model.Model.Transacao>, ISave<Model.Model.Transacao>
    {
        public IEnumerable<Model.Model.Transacao> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<bool> Get(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Model.Transacao> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save(Model.Model.Transacao item)
        {
            try
            {
                using (IDbConnection conn = base.connect())
                {
                    DynamicParameters bParams = new DynamicParameters();
                    bParams.Add(name: "idMedicamento", value: item.medicamento.id, dbType: DbType.Int32);
                    bParams.Add(name: "idEstoque", value: item.estoque.idEstoque, dbType: DbType.Int32);
                    bParams.Add(name: "idTipoTransacao", value: item.eTipoTransacao.GetHashCode(), dbType: DbType.Int32);
                    bParams.Add(name: "idReceita", value: item.idReceita, dbType: DbType.Int32);
                    bParams.Add(name: "quantidadeTransacao", value: item.quantidade, dbType: DbType.Int32);
                    bParams.Add(name: "dataTransacao", value: item.dataTransacao, dbType: DbType.Date);

                    conn.Execute(sql: "setTransacao"
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
                var a = "oi";
            }
        }
    }
}
