using System;
using System.Collections.Generic;
using System.Text;
using Gef.Model.Interface;
using System.Data;
using MySql.Data.MySqlClient;
namespace Gef.Data.Abstract
{
    public abstract class Banco
    {
        protected IDbConnection connect()
        {
            return new MySqlConnection("");
        }
    }
}
