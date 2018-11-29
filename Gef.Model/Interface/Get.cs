using System;
using System.Collections.Generic;
using System.Text;

namespace Gef.Model.Interface
{
    public interface Get<T>
    {
        T GetAll();
        T Get(int id);
    }
}
