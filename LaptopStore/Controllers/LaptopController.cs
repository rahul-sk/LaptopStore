using LaptopStore.Models;
using LaptopStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStore.Controllers
{
    public class LaptopController : Controller
    {
        ApplicationDBContext context;

        CustomerRepository customerRepo;
        ICrud<Laptop> laptopRepo;
        OrderRepository orderRepo;
        public LaptopController(CustomerRepository customers,ICrud<Laptop> laptops,OrderRepository orders)
        {
            customerRepo = customers;
            laptopRepo = laptops;
            orderRepo = orders;
            context = new ApplicationDBContext();
        }
        public IActionResult Index()
        {
            var curUser = HttpContext.Session.GetString("email");
            ViewBag.usr = curUser;
            var laptops = laptopRepo.GetAll();
            return View(laptops);
        }
        public IActionResult AddShippingDetails()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddShippingDetails(Customer c)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                context.Customers.Add(c);
                HttpContext.Session.SetString("email", c.Email);

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            var laptop = laptopRepo.Get(id);
            return View(laptop);
        }

        public IActionResult Payment(int id)
        {
            bool isLoggedIn = ((User != null) && User.Identity.IsAuthenticated) ? true : false;
            if (isLoggedIn)
            {

                var laptop = laptopRepo.Get(id);
                string lid = laptop.Id.ToString();
                HttpContext.Session.SetString("laptopId", lid);
                return View();
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
        }
        [HttpPost]
        public IActionResult Payment(Payment p)
        {
            if (ModelState.IsValid)
            {
                string email = HttpContext.Session.GetString("email");
                int cid = customerRepo.GetCustIdByEmail(email);
                Customer cust = customerRepo.GetCustByEmail(email);
                int lid = int.Parse(HttpContext.Session.GetString("laptopId"));
                var laptop = laptopRepo.Get(lid);

                context.Database.ExecuteSqlRaw($"insert into Orders values ({cid},{lid})");
                //Orders ord = new Orders() { Laptops=laptop,Customers=cust,CustomerId=cid,LaptopId=lid };
                //orderRepo.Add(ord);
                return RedirectToAction("Confirmation");
            }
            else
            {
                HttpContext.Session.Clear();
            }
            return View();
        }

        public IActionResult Confirmation()
        {
            int lid = int.Parse(HttpContext.Session.GetString("laptopId"));
            var laptop = laptopRepo.Get(lid);
            return View(laptop);
        }

        public IActionResult CurrentOrders()
        {

            string email = HttpContext.Session.GetString("email");

            int id = customerRepo.GetCustIdByEmail(email);
            List<Orders> orders = orderRepo.GetByCustId(id);
            ViewBag.cnt = orders.Count;
            
            List<Laptop> laptops=new List<Laptop>();
            if (orders.Count == 0)
            {
                return View(laptops);
            }
            foreach (var item in orders)
            {
                int lid = item.LaptopId;
                Laptop lap = laptopRepo.Get(lid);
                laptops.Add(lap);
            }


            return View(laptops);
        }


    }
}
