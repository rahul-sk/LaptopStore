using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStore.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer CustomerEnt { get; set; }
        public int LaptopId { get; set; }
        public Laptop LaptopEnt { get; set; }
    }
}
