using LCMTLCB1.WebAPI.Configuration;
using LCMTLCB1WebApplication.Models;
using LCMTLCB1WebApplication.Repositories;
using LCMTLCB1WebApplication.Services.DataModels;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace LCMTLCB1WebApplication.Controllers
{
    public class BerthScheduleController : Controller
    {
        private readonly ILogger<BerthScheduleController> _logger;
        private readonly BerthScheduleRepository _berthScheduleRepository;
        private readonly ApplicationSetting _applicationSetting;
        public BerthScheduleController(ILogger<BerthScheduleController> logger,
            BerthScheduleRepository berthScheduleRepository,
            ApplicationSetting  applicationSetting)
        {
            _logger = logger;
            _berthScheduleRepository = berthScheduleRepository;
            _applicationSetting =  applicationSetting;
        }

        public async Task<IActionResult> Index(string vesselName, string voyageIn, string voyageOut)
        {
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;
            ViewData["vesselName"] = vesselName;
            ViewData["voyageIn"] = voyageIn;
            ViewData["voyageOut"] = voyageOut;
            BerthScheduleViewModel dataVessel = await _berthScheduleRepository.GetVessel();
            dataVessel.vesellist.Insert(0, new Vesellist() { vesselcode = "", vesselname = "Select" });
            var arrPageSize = _applicationSetting.PageSize.Split(',').ToArray();
            ViewData["Vessel"] = new SelectList(dataVessel.vesellist.ToList(), "vesselcode", "vesselname", vesselName);
            ViewData["Lang"] = culture;
            ViewData["Menu"] = "OnlineService";
            ViewData["InitPageSize"] = arrPageSize[0];
            return View();
        }
        public async Task<IActionResult> DetailAsync(string vesselName, string voyageIn, string voyageOut, int pageSize, int? page)
        {
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;
            ViewData["vesselName"] = vesselName;
            ViewData["voyageIn"] = voyageIn;
            ViewData["voyageOut"] = voyageOut; 
            ViewData["Lang"] = culture;
            ViewData["Menu"] = "OnlineService";
            ViewData["PageSize"] = new SelectList(_applicationSetting.PageSize.Split(',').ToArray());  
            BerthScheduleViewModel _model = await _berthScheduleRepository.GetBerthSchedule(vesselName, voyageIn, voyageOut, culture.ToString(), pageSize, page);    
            return PartialView(_model); 
        }

    }
}