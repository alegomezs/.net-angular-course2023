using EFApp.Entities;
using System.Collections.Generic;

namespace EFApp.Logic
{
    public interface ICRUDLogic<T>
    {
        List<T> GetAll();

        void Insert(T newObject);
        
        void Update(Employees newEmployee);
        
        void Delete(int id);
        
        T Get(int id);
    }
}
