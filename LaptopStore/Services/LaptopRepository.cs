using LaptopStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStore.Services
{
    public class LaptopRepository : ICrud<Laptop>
    {
        ApplicationDBContext context;
        public LaptopRepository()
        {
            context = new ApplicationDBContext();
        }
        public bool Add(Laptop item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Laptop item)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Laptop item)
        {
            throw new NotImplementedException();
        }

        public Laptop Get(int id)
        {
            Laptop lap = context.Laptops.Where(x => x.Id == id).FirstOrDefault();
            return lap;
        }

        public List<Laptop> GetAll()
        {
            var laptops = context.Laptops.ToList();
            return laptops;
        }
    }
}
