using System;
using System.Collections.Generic;
using System.Text;

namespace Gef.Model.Interface
{
    public interface Alter<T>
    {
        bool Alter(T item);
    }
}
