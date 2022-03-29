using LCMTLCB1.WebAPI.Configuration;
using LCMTLCB1WebApplication.Models;
using LCMTLCB1WebApplication.Repositories;
using LCMTLCB1WebApplication.Services.DataModels;
using LCMTLCB1WebApplication.Utility;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LCMTLCB1WebApplication.Controllers
{
    public class ETerminalController : Controller
    {
        private readonly ILogger<ETerminalController> _logger;
        private readonly BookingRepository bookingRepository;
        private readonly BerthScheduleRepository berthScheduleRepository;
        private readonly ContainerRepository containerRepository;
        private readonly LoginRepository loginRepository;
        private readonly ApplicationSetting _applicationSetting;
        public ETerminalController(ILogger<ETerminalController> logger,
            BookingRepository bookingRepository,
            BerthScheduleRepository berthScheduleRepository,
            ContainerRepository containerRepository,
            LoginRepository loginRepository, 
            ApplicationSetting  applicationSetting)
        {
            _logger = logger;
            this.bookingRepository = bookingRepository;
            this.berthScheduleRepository = berthScheduleRepository;
            this.containerRepository = containerRepository;
            this.loginRepository = loginRepository;
            _applicationSetting = applicationSetting;
        }
        public IActionResult Index()
        {
            if (GetCurrentUser() == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {

                ViewData["UserName"] = GetCurrentUser().ssoUser.UserName;
            }
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;
            ViewData["Lang"] = culture;
            ViewData["Menu"] = "OnlineService";
            return View();
        }
        #region BerthSchedule
        public async Task<IActionResult> BerthSchedule()
        {
            if (GetCurrentUser() == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {

                ViewData["UserName"] = GetCurrentUser().ssoUser.UserName;
            }
             
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;
            var arrPageSize = _applicationSetting.PageSize.Split(',').ToArray();
            ViewData["Lang"] = culture;
            ViewData["Menu"] = "OnlineService";            
            ViewData["InitPageSize"] = arrPageSize[0];
            return View("~/Views/ETerminal/BerthSchedule/Index.cshtml");
        }
        public async Task<IActionResult> BerthScheduleDetail(int pageSize, int? page)
        {
            if (GetCurrentUser() == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {

                ViewData["UserName"] = GetCurrentUser().ssoUser.UserName;
            }
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;
            BerthScheduleViewModel _model = await berthScheduleRepository.GetBerthScheduleEterminal(GetCurrentUser().ssoUser.usermap[0].refUserID, culture.ToString(), pageSize,page);
            ViewData["Lang"] = culture;
            ViewData["Menu"] = "OnlineService";             
            ViewData["PageSize"] = new SelectList(_applicationSetting.PageSize.Split(',').ToArray());
            return PartialView("~/Views/ETerminal/BerthSchedule/Detail.cshtml", _model);
        }
      
        #endregion
        #region Booking
        public async Task<IActionResult> Booking(string bookingNumber)
        {
            if (GetCurrentUser() == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {

                ViewData["UserName"] = GetCurrentUser().ssoUser.UserName;
            }
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;
            var arrPageSize = _applicationSetting.PageSize.Split(',').ToArray();
            ViewData["Lang"] = culture;
            ViewData["Menu"] = "OnlineService";
            ViewData["bookingNumber"] = bookingNumber;
            ViewData["InitPageSize"] = arrPageSize[0];
            return View("~/Views/ETerminal/Booking/Index.cshtml");
        }

        public async Task<IActionResult> BookingDetail(string bookingNumber, int pageSize, int? page)
        {
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;
            ViewData["Lang"] = culture;
            ViewData["Menu"] = "OnlineService";
            ViewData["PageSize"] = new SelectList(_applicationSetting.PageSize.Split(',').ToArray());
            BookingViewModel _model = await bookingRepository.GetBookingByBookingEterminal(GetCurrentUser().ssoUser.usermap[0].refUserID, bookingNumber, culture.ToString(), pageSize, page);
            return PartialView("~/Views/ETerminal/Booking/Detail.cshtml", _model);
        }
        #endregion
        #region Container
        public async Task<IActionResult> Container(string containerNumber, string bookingNumber, string p)
        {
            if (GetCurrentUser() == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["ContainerNumber"] = containerNumber;
                ViewData["bookingNumber"] = bookingNumber;
                ViewData["UserName"] = GetCurrentUser().ssoUser.UserName;
            }
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;

            ViewData["Lang"] = culture;
            ViewData["Menu"] = "OnlineService";
            ViewData["p"] = p;
            
            return View("~/Views/ETerminal/Container/Index.cshtml");
        }

        public async Task<IActionResult> ContainerDetail(string containerNumber, string bookingNumber, string p)
        {
            if (GetCurrentUser() == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["ContainerNumber"] = containerNumber;
                ViewData["UserName"] = GetCurrentUser().ssoUser.UserName;
                ViewData["bookingNumber"] = bookingNumber;
            }
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;
            ViewData["Lang"] = culture;
            ViewData["Menu"] = "OnlineService";
            ViewData["ContainerNumber"] = containerNumber;
            ViewData["p"] = p;
            ContainerViewModel _model = await containerRepository.GetContainnerNumberEterminal(GetCurrentUser().ssoUser.usermap[0].refUserID, containerNumber, culture.ToString());
             
            return PartialView("~/Views/ETerminal/Container/Detail.cshtml", _model);
        }
        
        public async Task<IActionResult> ContainerDetailData(string containerNumber,string handlingidOut, string bookingNumber, string p)
        {
            if (GetCurrentUser() == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["ContainerNumber"] = containerNumber;
                ViewData["bookingNumber"] = bookingNumber;
                ViewData["UserName"] = GetCurrentUser().ssoUser.UserName;
            }
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;
            ViewData["Lang"] = culture;
            ViewData["Menu"] = "OnlineService";
            ViewData["ContainerNumber"] = containerNumber;
            ViewData["p"] = p;
            ContainerViewModel _model = await containerRepository.GetContainnerNumberByHanderingEterminal(GetCurrentUser().ssoUser.usermap[0].refUserID, containerNumber, culture.ToString());
          
            //ContainerViewModel _modelOut = await containerRepository.GetContainnerNumberByHanderingEterminal(GetCurrentUser().ssoUser.usermap[0].refUserID, handlingidOut, culture.ToString());
            //if (_modelOut.status == "OK")
            //{
            //    ViewData["Vessel"] = _modelOut.unit.vesselname;
            //    ViewData["Voyage"] = _modelOut.unit.idnumber;
            //    ViewData["Portofdischarge"] = _modelOut.unit.portofdischarge;
               


            //}
            return View("~/Views/ETerminal/Container/DetailData.cshtml", _model);
        }
        #endregion
        public async Task<IActionResult> LoginAsync([FromBody] User ssoUser)
        {
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;
            UserViewModel _model = await loginRepository.Login(ssoUser.UserName, Cyptor.CipherEncrypt(ssoUser.Password.Trim()), culture.ToString());
            if (_model.status == "OK")
            {
                try
                {
                    var user = _model.ssoUser.usermap.Where(x => x.appName == "COSMOS").ToList();
                    if (user.Count > 0)
                    {
                        _model.ssoUser.usermap = _model.ssoUser.usermap.Where(x => x.appName == "COSMOS").ToList();
                        SetCurrentUser(_model);
                    }
                    else
                    {
                        _model.status = "ER";
                        _model.msg = "No permission in COSMOS";
                    }
                }
                catch
                {
                    _model.status = "ER";
                    _model.msg = "No permission in COSMOS";
                }
            }
            return Json(_model);

        }


        public IActionResult Logout()
        {
            SetCurrentUser(null);
            return RedirectToAction("Index", "Home");
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

        public ActionResult GetUserlogin(User user)
        {
            try
            {
                return Json(new { username = new CurrentUser(this.HttpContext).User.ssoUser.usermap.Where(a => a.appName== "COSMOS").FirstOrDefault().refUserID });
            }
            catch
            {
                return Json(new { username = "" });
            }
        }
    }
}
