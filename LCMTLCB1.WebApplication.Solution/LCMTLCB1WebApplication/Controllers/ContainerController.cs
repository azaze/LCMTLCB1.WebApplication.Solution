using LCMTLCB1WebApplication.Models;
using LCMTLCB1WebApplication.Repositories;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LCMTLCB1WebApplication.Controllers
{
    public class ContainerController : Controller
    {
        private readonly ILogger<ContainerController> _logger;
        private readonly ContainerRepository containerRepository;

        public ContainerController(ILogger<ContainerController> logger,
            ContainerRepository containerRepository)
        {
            _logger = logger;
           this.containerRepository = containerRepository;
        }

        public IActionResult Index(string containerNumber)
        {
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;
            ViewData["containerNumber"] = containerNumber;           
            ViewData["Lang"] = culture;
            ViewData["Menu"] = "OnlineService";
            
            return View();
        }
        public async Task<IActionResult> DetailAsync(string containerNumber)
        {
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;
            ViewData["containerNumber"] = containerNumber;
            ViewData["Lang"] = culture;
            ViewData["Menu"] = "OnlineService";
            
            ContainerViewModel _model = await containerRepository.GetContainnerNumber(containerNumber, culture.ToString());    
            return PartialView(_model);
        }

    }
}