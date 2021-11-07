using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStore.Models
{
    public class Laptop
    {

        public int Id { get; set; }

        public string ItemTitle { get; set; }

        public string Price { get; set; }
        public string Image { get; set; }
        public string ModelName { get; set; }
        public string RamSize { get; set; }
        public string ProcessorBrand { get; set; }
        public string ProcessorSpeed { get; set; }
        public string ProcessorType { get; set; }
        public string HardDiskSize { get; set; }
        public string HardDiskType { get; set; }
        public string Display { get; set; }
        public string Color { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string Battery { get; set; }
        public string Weight { get; set; }
        public List<Orders> Orders { get; set; }


    }
}
