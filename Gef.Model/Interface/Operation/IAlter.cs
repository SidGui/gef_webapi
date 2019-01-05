using System;
using System.Collections.Generic;
using System.Text;

namespace Gef.Model.Interface.Operation
{
    public interface IAlter<T>
    {
        bool Alter(int id, T item);
    }
}
