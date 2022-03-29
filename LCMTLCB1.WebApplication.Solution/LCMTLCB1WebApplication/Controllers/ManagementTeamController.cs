using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace LCMTLCB1WebApplication.Controllers
{
    public class ManagementTeamController : Controller
    {
        private readonly ILogger<ManagementTeamController> _logger;

        public ManagementTeamController(ILogger<ManagementTeamController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;
            ViewData["Lang"] = culture;
            ViewData["Menu"] = "About";
            return View();
        }
    }
}
