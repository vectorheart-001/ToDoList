using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Data.Repositories
{
    internal interface IItemRepository
    {
        List<Item> GetAll();
        Item Get(int id);
        void Update(Item item);
        void Insert(Item item);
        void Delete(int id);
    }
}
