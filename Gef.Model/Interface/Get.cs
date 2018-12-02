using System;
using System.Collections.Generic;
using System.Text;

namespace Gef.Model.Interface
{
    public interface Get<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(int id);
    }
}
