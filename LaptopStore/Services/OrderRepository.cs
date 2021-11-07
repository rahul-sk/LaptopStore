using LaptopStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStore.Services
{
    public class OrderRepository : ICrud<Orders>
    {
        ApplicationDBContext cxt;
        public OrderRepository()
        {
            cxt = new ApplicationDBContext();
        }

        public bool Add(Orders item)
        {
            try
            {
                var ords = cxt.Orders.ToList();
                Orders b1 = item;
                b1.Id = ords.Max(x => x.Id) + 1;
                cxt.Orders.Add(b1);
                cxt.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(Orders item)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Orders item)
        {
            throw new NotImplementedException();
        }

        public Orders Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Orders> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Orders> GetByCustId(int id)
        {
            var orders = cxt.Orders.Where(x => x.CustomerId == id).ToList();
            return orders;
        }

        
    }
}
