using LaptopStore.Models;
using LaptopStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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
            string val1 = ((User != null) && User.Identity.IsAuthenticated )? "Logged In" : "Logged out";
            ViewBag.msg = val1+" "+HttpContext.Session.GetString("email");
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
                int id = customerRepo.GetCustIdByEmail(email);
                Customer cust = customerRepo.GetCustByEmail(email);
                int lid = int.Parse(HttpContext.Session.GetString("laptopId"));
                var laptop = laptopRepo.Get(lid);
                Orders ord = new Orders() { LaptopEnt=laptop,CustomerEnt=cust };
                orderRepo.Add(ord);
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


            return View();
        }


    }
}
