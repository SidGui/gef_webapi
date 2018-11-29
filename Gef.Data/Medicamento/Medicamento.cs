using Gef.Data.Abstract;
using Gef.Model.Model;
using Gef.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gef.Data.Medicamento
{
    public class Medicamento : Banco, Get<Model.Model.Medicamento>, Save<Model.Model.Medicamento>, Alter<Model.Model.Medicamento>, Delete
    {
        public Medicamento()
        {
            
        }

        public bool Alter(Model.Model.Medicamento item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Model.Model.Medicamento Get(int id)
        {
            throw new NotImplementedException();
        }

        public Model.Model.Medicamento GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save(Model.Model.Medicamento item)
        {
            throw new NotImplementedException();
        }
    }
}
