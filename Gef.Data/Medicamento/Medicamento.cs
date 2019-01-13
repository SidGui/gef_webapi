using Gef.Data.Abstract;
using Gef.Model.Model;
using Gef.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
using Gef.Model.Interface.Operation;
using System.Linq;

namespace Gef.Data.Medicamento
{
    public class Medicamento : Banco, IGet<Model.Model.Medicamento>, ISave<Model.Model.Medicamento>, IAlter<Model.Model.Medicamento>, IDelete
    {
        public bool Alter(int id, Model.Model.Medicamento item)
        {
            try {
                using (IDbConnection conn = base.connect()) {
                    DynamicParameters bParams = new DynamicParameters();
                    bParams.Add(name: "ativo", value: item.ativo, dbType: DbType.Boolean);
                    bParams.Add(name: "idMedicamento", value: id, dbType: DbType.Int32);
                    bParams.Add(name: "cadastroCompleto", value: item.cadastroCompleto, dbType: DbType.Boolean);
                    //bParams.Add(name: "", value: item.cadastroCompleto, dbType: DbType.Boolean); 
                    bParams.Add(name: "nomeMedicamento", value: item.nomeMedicamento, dbType: DbType.String);
                    bParams.Add(name: "estoqueCritico", value: item.quantidadeEstoqueCritico, dbType: DbType.Double);

                    conn.Execute(sql: "alterMedicamento", param: bParams, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch(MySql.Data.MySqlClient.MySqlException ex){
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try {
                using (IDbConnection conn = base.connect()) {
                    DynamicParameters bParams = new DynamicParameters();
                    bParams.Add(name: "idMedicamento", value: id, dbType: DbType.Boolean); 

                    conn.Execute(sql: "deleteMedicamento", param: bParams, commandType: CommandType.StoredProcedure);

                }
            }
            catch(MySql.Data.MySqlClient.MySqlException ex){
                throw ex;
            }
        }

        public IEnumerable<Model.Model.Medicamento> Get(int id)
        {
            using (IDbConnection conn = base.connect())
            {
                //Dapper.SqlMapper.AddTypeMap(typeof(DateTime), System.Data.DbType.DateTime);
                DynamicParameters bParams = new DynamicParameters();
                bParams.Add(name: "idMedicamento", value: id, dbType: DbType.Int32);
                return conn.Query<Model.Model.Medicamento
                    , Model.Model.TipoMedicamento
                    , Model.Model.PrincipioAtivo
                    , Model.Model.UnidadeMedida
                    , Model.Model.ViaAdministracao
                    , Model.Model.Medicamento>(sql: "getMedicamento"
                    , commandType: CommandType.StoredProcedure
                    , param: bParams
                    , splitOn: "id, idTipoMedicamento, idPrincipioAtivo, idUnidadeMedida, idViaAdministracao"
                   , map: (medicamento, tipoMedicamento, principioAtivo, unidadeMedida, viaAdministracao) => {
                        medicamento.tipoMedicamento = tipoMedicamento;
                        medicamento.principioAtivo = principioAtivo;
                          medicamento.unidadeMedida = unidadeMedida;
                        medicamento.viaAdministracao = viaAdministracao;
                        return medicamento;
                    }
                    );
            }
        }
// public IEnumerable<Model.Model.Medicamento> GetAll(){
    
//     IEnumerable<Model.Model.Medicamento> medicamento = Enumerable.Empty<Model.Model.Medicamento>();
//     try{
//         using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection("Server=gef-app-mysqldbserver.mysql.database.azure.com;Database=gef_db;Uid=gefadmin@gef-app-mysqldbserver;Pwd=Fib1235813@;")) 
//         {
//                     conn.Open();
//                     MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                     myCommand.CommandText = "getMedicamento";
//                     myCommand.Connection = conn;
//                     myCommand.CommandType = CommandType.StoredProcedure;
//                     MySql.Data.MySqlClient.MySqlParameter param = new MySql.Data.MySqlClient.MySqlParameter();
//                     param.DbType =DbType.Int32;
//                     param.ParameterName = "idMedicamento";
//                     param.Value = null;
//                     myCommand.Parameters.Add(param);
//                     MySql.Data.MySqlClient.MySqlDataReader dr = myCommand.ExecuteReader();
//                     List<Model.Model.Medicamento> lmedicamento = new List<Model.Model.Medicamento>();
//                     if(dr.HasRows)
//                     while(dr.Read()){
//                         Model.Model.Medicamento mMedicamento = new Model.Model.Medicamento();
//                         mMedicamento.data_cadastro = dr.GetDateTime("data_cadastro");
//                         // lmedicamento.Add( new Model.Model.Medicamento{
//                         //     nomeMedicamento = dr.GetString("nomeMedicamento"),
//                         //     nomeAnvisa = dr.GetString("nomeAnvisa"),
//                         //  observacao = dr.GetString("observacao"),
//                         //  data_cadastro = dr.GetDateTime("data_cadastro")
//                         // });
//                     }
//                     conn.Close();
//         }
//     }catch(MySql.Data.MySqlClient.MySqlException ex) {
//         //throw ex;
//     }
//     return medicamento;
// }
        public IEnumerable<Model.Model.Medicamento> GetAll()
        {
            try {
                using (IDbConnection conn = base.connect()) {
                    DynamicParameters bParams = new DynamicParameters();
                    bParams.Add(name: "idMedicamento", value: null, dbType: DbType.Int32); 
                    return conn.Query<Model.Model.Medicamento
                          , Model.Model.TipoMedicamento
                        , Model.Model.PrincipioAtivo
                        , Model.Model.UnidadeMedida
                        , Model.Model.ViaAdministracao
                        , Model.Model.Medicamento>(sql: "getMedicamento"
                        , commandType: CommandType.StoredProcedure
                        , param: bParams
                        , splitOn: "id, idTipoMedicamento, idPrincipioAtivo, idUnidadeMedida, idViaAdministracao"
                        , map: (medicamento, tipoMedicamento, principioAtivo, unidadeMedida, viaAdministracao) => {
                            medicamento.tipoMedicamento = tipoMedicamento;
                            medicamento.principioAtivo = principioAtivo;
                            medicamento.unidadeMedida = unidadeMedida;
                            medicamento.viaAdministracao = viaAdministracao;
                            return medicamento;
                          }
                        );
                }
            }
            catch(MySql.Data.MySqlClient.MySqlException ex) {
                throw ex;
            }
        }

        public bool Save(Model.Model.Medicamento item)
        {
            try {
                using (IDbConnection conn = base.connect()) {
                    DynamicParameters bParams = new DynamicParameters();
                    bParams.Add(name: "guid", value: item.guid, dbType: DbType.String);
                    bParams.Add(name: "nomeMedicamento", value: item.nomeMedicamento, dbType: DbType.String);
                    bParams.Add(name: "idTipoMedicamento", value: item.tipoMedicamento.idTipoMedicamento, dbType: DbType.Int32);
                    bParams.Add(name: "dataCadastro", value: item.dataCadastro, dbType: DbType.DateTime); 
                    bParams.Add(name: "observacao", value: item.observacao, dbType: DbType.String);
                    bParams.Add(name: "cadastroCompleto", value: item.cadastroCompleto, dbType: DbType.Boolean); 
                    bParams.Add(name: "ativo", value: item.ativo, dbType: DbType.Boolean); 
                    bParams.Add(name: "estoqueCritico", value: item.quantidadeEstoqueCritico, dbType: DbType.Double);
                    bParams.Add(name: "nomeAnvisa", value: item.nomeAnvisa, dbType: DbType.String);
                    bParams.Add(name: "idPrincipioAtivo", value: item.principioAtivo.idPrincipioAtivo, dbType: DbType.Int32);
                    bParams.Add(name: "idUnidadeMedida", value: item.unidadeMedida.idUnidadeMedida, dbType: DbType.Int32);
                    bParams.Add(name: "idViaAdministracao", value: item.viaAdministracao.idViaAdministracao, dbType: DbType.Int32);

                    conn.Execute(sql: "setMedicamento", param: bParams, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch(MySql.Data.MySqlClient.MySqlException ex){
                throw ex;
            }
        }
    }
}
