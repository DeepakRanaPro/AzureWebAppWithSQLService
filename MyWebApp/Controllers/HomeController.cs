using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using System.Diagnostics;

namespace MyWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string fullname, fname, lname;
        public HomeController(IConfiguration configuration, ILogger<HomeController> logger)
        {
            fullname = configuration["FullName"];
            fname = configuration["Name:FirstName"];
            lname = configuration["Name:LastName"];
            _logger = logger;
        }
        public IActionResult Index()
        {
            ViewBag.Name = "FullName=" + fullname + ", FirstName=" + fname + ", LastName=" + lname;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
