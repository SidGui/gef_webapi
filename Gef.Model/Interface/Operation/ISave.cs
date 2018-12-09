using System;
using System.Collections.Generic;
using System.Text;

namespace Gef.Model.Interface.Operation
{
    public interface ISave<T>
    {
        bool Save(T item);
    }
}
