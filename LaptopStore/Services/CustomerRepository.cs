using LaptopStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStore.Services
{
    public class CustomerRepository : ICrud<Customer>
    {
        ApplicationDBContext context;
        public CustomerRepository()
        {
            context = new ApplicationDBContext();
        }
        public bool Add(Customer item)
        {
            try
            {
                var customers = context.Customers.ToList();
                Customer b1 = item;
                b1.Id = customers.Max(x => x.Id) + 1;
                context.Customers.Add(b1);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(Customer item)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Customer item)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            Customer customer = context.Customers.Where(x => x.Id == id).FirstOrDefault();
            return customer;
        }

        public Customer GetCustByEmail(string email)
        {
            Customer customer = context.Customers.Where(x => x.Email==email).FirstOrDefault();
            return customer;
        }

        public int GetCustIdByEmail(string email)
        {
            Customer customer = context.Customers.Where(x => x.Email == email).FirstOrDefault();
            return customer.Id;
        }

        public List<Customer> GetAll()
        {
            return context.Customers.ToList();
        }
    }
}
