using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data;

namespace ToDoList.Data.Repositories
{
    internal interface IToDoCollectionRepositories
    {
        List<ToDoCollection> GetAll();
        ToDoCollection Get(int id);
        void Insert(ToDoCollection collection);
        void Update(ToDoCollection collection);
        void Delete(int id);
    }
}
