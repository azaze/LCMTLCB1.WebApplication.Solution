using LCMTLCB1WebApplication.Models;
using LCMTLCB1WebApplication.Services.DataModels;
using LCMTLCB1WebApplication.Utility;
using LCMTLCB1WebApplication.Repositories;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace LCMTLCB1WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BerthScheduleRepository berthScheduleRepository;
        public HomeController(ILogger<HomeController> logger,
            BerthScheduleRepository berthScheduleRepository)
        {
            _logger = logger;
            this.berthScheduleRepository = berthScheduleRepository;
        }

        public async Task<IActionResult> Index()
        {
            var cookieValue = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("en-US"));
            var option = new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) };

            Response.Cookies.Append("LCB1Web.Language", cookieValue, option);

            //SetCurrentUser(new() { UserName = "Adminm" });
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;
            BerthScheduleViewModel dataVessel = await berthScheduleRepository.GetVessel();
            dataVessel.vesellist.Insert(0, new Vesellist() { vesselcode = "", vesselname = "Select" });
            ViewData["Vessel"] = new SelectList(dataVessel.vesellist, "vesselcode", "vesselname");
            ViewData["Lang"] = culture;
            ViewData["Menu"] = "Home";
            if(GetCurrentUser() != null)
            {     
                ViewData["UserName"] = GetCurrentUser().ssoUser.UserName;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            var cookieValue = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("en-US"));
            var option = new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) };

            Response.Cookies.Append("LCB1Web.Language", cookieValue, option);

            //SetCurrentUser(new() { UserName = "Adminm" });
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;
             
            ViewData["Lang"] = culture;
            ViewData["Menu"] = "Home";
           
            return View();
        }
        public IActionResult Terms()
        {
            var cookieValue = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("en-US"));
            var option = new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) };

            Response.Cookies.Append("LCB1Web.Language", cookieValue, option);

            //SetCurrentUser(new() { UserName = "Adminm" });
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;

            ViewData["Lang"] = culture;
            ViewData["Menu"] = "Home";

            return View();
        }
        public IActionResult Cookie()
        {
            var cookieValue = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("en-US"));
            var option = new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) };

            Response.Cookies.Append("LCB1Web.Language", cookieValue, option);

            //SetCurrentUser(new() { UserName = "Adminm" });
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;

            ViewData["Lang"] = culture;
            ViewData["Menu"] = "Home";

            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SetThai()
        {
            var cookieValue = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("th-TH"));
            var option = new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) };

            Response.Cookies.Append("LCB1Web.Language", cookieValue, option);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult SetEnglish()
        {
            var cookieValue = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("en-US"));
            var option = new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) };

            Response.Cookies.Append("LCB1Web.Language", cookieValue, option);
            return RedirectToAction(nameof(Index));
        }

        private bool SetCurrentUser(UserViewModel user)
        {
            try
            {
                new CurrentUser(this.HttpContext).User = user;
                return true;
            }
            catch
            {
                return false;
            }
        }


        private UserViewModel GetCurrentUser()
        {
            try
            {
                return new CurrentUser(this.HttpContext).User;
            }
            catch
            {
                return null;
            }
        }
    }
}