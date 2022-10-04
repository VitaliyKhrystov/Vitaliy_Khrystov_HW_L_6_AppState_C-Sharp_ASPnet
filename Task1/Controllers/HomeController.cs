using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;
using Task1.Models;

namespace Task1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string cookieKey = "name";
        public static int Count { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
          
        }

        public IActionResult Index(string data)
        {
            if (data!= null && HttpContext.Session.GetString(cookieKey) == null)
            {
                Count++;
                HttpContext.Session.SetString(cookieKey, data);
            }
            ViewBag.Count = Count;
            return View((object)HttpContext.Session.GetString(cookieKey));
        }

        [HttpPost]
        public IActionResult GetName(string name)
        {
          
            return RedirectToAction("Index", "Home", new {data = name});
        }

        ~HomeController(){
            if (HttpContext.Session.GetString(cookieKey) == null)
            {
                HttpContext.Session.Clear();
                Count--;
            } 
        }
    }
}