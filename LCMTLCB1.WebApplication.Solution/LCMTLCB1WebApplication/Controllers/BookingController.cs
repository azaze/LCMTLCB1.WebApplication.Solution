using LCMTLCB1.WebAPI.Configuration;
using LCMTLCB1WebApplication.Models;
using LCMTLCB1WebApplication.Repositories;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace LCMTLCB1WebApplication.Controllers
{
    public class BookingController : Controller
    {
        private readonly ILogger<BookingController> _logger;
        private readonly BookingRepository bookingRepository;
        private readonly ApplicationSetting _applicationSetting;
        public BookingController(ILogger<BookingController> logger,           
            BookingRepository bookingRepository,
            ApplicationSetting  applicationSetting)
        {
            _logger = logger;
           this.bookingRepository = bookingRepository;
            _applicationSetting = applicationSetting;
        }

        public IActionResult Index(string bookingNumber)
        {
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;
            var arrPageSize = _applicationSetting.PageSize.Split(',').ToArray();
            ViewData["bookingNumber"] = bookingNumber;           
            ViewData["Lang"] = culture;
            ViewData["Menu"] = "OnlineService";
            ViewData["InitPageSize"] = arrPageSize[0];
            return View();
        }
        public async Task<IActionResult> DetailAsync(string bookingNumber, int pageSize, int? page)
        {
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;
            ViewData["bookingNumber"] = bookingNumber;
            ViewData["Lang"] = culture;
            ViewData["Menu"] = "OnlineService";
            ViewData["PageSize"] = new SelectList(_applicationSetting.PageSize.Split(',').ToArray());
            BookingViewModel _model = await bookingRepository.GetBookingByBookingNumber(bookingNumber, culture.ToString(), pageSize, page);    
            return PartialView(_model);
        }

    }
}