using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication_core_lab8.Models;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace WebApplication_core_lab8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult test1()
        {
            int num1 = 5;
            int num2 = 8;
            int sum = num1 + num2;
            ViewBag.n1 = num1;
            ViewBag.n2 = num2;
            ViewBag.ans = sum;
            return View();
        }

        [HttpGet]
        public IActionResult test2( )
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(IFormCollection fc)
        {
            ViewBag.sum = (int.Parse(fc["numb1"]) + int.Parse(fc["numb2"])).ToString();
            return View("test2");
        }

        [HttpGet]
        public IActionResult register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult registerForm(string name, string email, string password,string mob)
        {
            ViewBag.name = name;
            ViewBag.email = email;
            ViewBag.password = password;
            ViewBag.mobile = mob;
            return View("register");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
