using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace LCMTLCB1WebApplication.Controllers
{
    public class TechnologyController : Controller
    {
        private readonly ILogger<TechnologyController> _logger;

        public TechnologyController(ILogger<TechnologyController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;
            ViewData["Lang"] = culture;
            ViewData["Menu"] = "Service";
            return View();
        }
    }
}
