using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MultiLangDemo.Models;
using System.Diagnostics;

namespace MultiLangDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            ViewBag.ControllerMessage =
                _localizer["ControllerMessage"];

            return View();
        }
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Email == "abc@gmail.com"
       && model.Password == "admin@123")
            {
                ViewBag.LoginMessage =
                    _localizer["LoginSuccess"];

                ViewBag.IsSuccess = true;
            }
            else
            {
                ViewBag.LoginMessage =
                    _localizer["LoginFailed"];

                ViewBag.IsSuccess = false;
            }

            return View(model);
        }
        public IActionResult ContactSupport()
        {
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
