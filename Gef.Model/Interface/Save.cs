using System;
using System.Collections.Generic;
using System.Text;

namespace Gef.Model.Interface
{
    public interface Save<T>
    {
        bool Save(T item);
    }
}
