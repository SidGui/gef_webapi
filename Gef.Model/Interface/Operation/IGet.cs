using System;
using System.Collections.Generic;
using System.Text;

namespace Gef.Model.Interface.Operation
{
    public interface IGet<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(int id);
        IEnumerable<bool> Get(string nome);
    }
}
