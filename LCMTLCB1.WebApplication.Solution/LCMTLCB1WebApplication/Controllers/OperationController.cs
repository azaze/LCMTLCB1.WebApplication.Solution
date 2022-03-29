using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace LCMTLCB1WebApplication.Controllers
{
    public class OperationController : Controller
    {
        private readonly ILogger<OperationController> _logger;

        public OperationController(ILogger<OperationController> logger)
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
