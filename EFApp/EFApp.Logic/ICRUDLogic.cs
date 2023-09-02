using EFApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFApp.Logic
{
    public interface ICRUDLogic<T>
    {
        List<T> GetAll();
        void Insert(T newObject);
        void Update(Employees newEmployee);
        void Delete(int id);

    }
}
