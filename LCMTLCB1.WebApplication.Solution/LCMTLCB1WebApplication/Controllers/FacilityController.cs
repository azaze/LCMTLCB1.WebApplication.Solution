using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace LCMTLCB1WebApplication.Controllers
{
    public class FacilityController : Controller
    {
        private readonly ILogger<FacilityController> _logger;

        public FacilityController(ILogger<FacilityController> logger)
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
