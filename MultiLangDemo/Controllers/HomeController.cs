using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MultiLangDemo.Data;
using MultiLangDemo.Models;
using MultiLangDemo.Services;
using System.Diagnostics;

namespace MultiLangDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseLocalizer _databaseLocalizer;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, DatabaseLocalizer databaseLocalizer, IStringLocalizer<HomeController> localizer, ApplicationDbContext context)
        {
            _logger = logger;
            _databaseLocalizer = databaseLocalizer;
            _localizer = localizer;
            _context = context;
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
        public IActionResult ApiLogin()
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
        public IActionResult JsonLocalization()
        {
            return View();
        }
        public IActionResult DatabaseLocalization()
        {
            ViewBag.Welcome = _databaseLocalizer.Get("Welcome");
            ViewBag.Description = _databaseLocalizer.Get("Description");
            return View();
        }
        public IActionResult ManageTranslations()
        {
            var translations = _context.LocalizationResources.ToList();
            return View(translations);
        }
        [HttpPost]
        public IActionResult UpdateTranslation(LocalizationResource model)
        {
            var translation = _context.LocalizationResources.FirstOrDefault(x => x.Id == model.Id);

            if (translation != null)
            {
                translation.Value = model.Value;
                _context.SaveChanges();
            }

            return RedirectToAction("ManageTranslations");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="culture">This receives selected langauge ex: en , hi from navbar button asp-route-culture= hi </param>
        /// <param name="returnUrl">store the current pages urlinsteda of redirecting home page it stayt jin that pages </param>
        /// <returns></returns>
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            //  Response.Cookies.Append : Create browser cookie
            // CookieRequestCultureProvider.DefaultCookieName : This is the default name for the cookie that stores the user's culture preference.
            // CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)) : This method generates the value for the cookie based on the specified culture. It creates a string that represents the culture information in a format that can be stored in a cookie.
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                // This sets the cookie to expire in one year, ensuring that the user's language preference is remembered for an extended period.
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });
            // LocalRedirect : This method is used to redirect the user to a local URL, which is typically the URL of the page they were on before changing the language. It ensures that the redirection is safe and prevents open redirect vulnerabilities.
            return LocalRedirect(returnUrl);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
