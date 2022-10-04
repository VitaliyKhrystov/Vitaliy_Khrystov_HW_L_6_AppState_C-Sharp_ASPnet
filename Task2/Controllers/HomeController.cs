using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;
using Task2.Models;

namespace Task2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string cookieKey = "CookiesData";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string value;
            bool isCookie = Request.Cookies.TryGetValue(cookieKey, out value);

            if (isCookie)
            {
                ViewBag.CookieValue = value;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(CookieData model)
        {
            if (model.Date < DateTime.Now)
            {
                ModelState.AddModelError(nameof(model.Date), "Incorrect date!");
            }
            if (ModelState.IsValid)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = model.Date.AddHours(3);
                Response.Cookies.Append("CookiesData", model.Value, options);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}