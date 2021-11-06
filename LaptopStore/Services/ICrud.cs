using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStore.Services
{
    public interface ICrud<T>
    {
        T Get(int id);
        List<T> GetAll();
        bool Add(T item);
        bool Delete(T item);
        bool Edit(T item);
    }
}
