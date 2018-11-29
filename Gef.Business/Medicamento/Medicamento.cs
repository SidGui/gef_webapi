using System;
using System.Collections.Generic;
using System.Text;
using Gef.Model.Interface;

namespace Gef.Business.Medicamento
{
    public class Medicamento : Get<Medicamento>, Alter<Medicamento>, Save<Medicamento>, Delete
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Medicamento Get(int id)
        {
            throw new NotImplementedException();
        }

        public Medicamento GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save(Medicamento item)
        {
            throw new NotImplementedException();
        }

        public bool Alter(Medicamento item)
        {
            throw new NotImplementedException();
        }
    }
}
