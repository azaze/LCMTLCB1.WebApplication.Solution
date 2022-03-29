using LCMTLCB1.WebAPI.Configuration;
using LCMTLCB1WebApplication.Models;
using LCMTLCB1WebApplication.Services.DataModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LCMTLCB1WebApplication.Repositories
{
    public class BookingRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationSetting _applicationSetting;
        public BookingRepository( 
            IHttpContextAccessor httpContextAccessor,
            ApplicationSetting  applicationSetting)
        {

            _httpContextAccessor = httpContextAccessor;
            _applicationSetting = applicationSetting;
        }
        public async Task<BookingViewModel> GetBookingByBookingNumber(string bookingNumber,string PARM_LANG, int pageSize, int? page)
        {  
            bookingNumber= (bookingNumber??"").Trim();
            BookingViewModel _berth = new BookingViewModel();
            if (bookingNumber == "")
            {
                _berth.msg = "Please insert booking number.";
                return _berth;
            }
            try
            {
                string clientIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();                
                var url = $"{_applicationSetting.API_Url}/api/QuickSearch/SearchByBook";
                    url += $"?PARM_BOOKING={bookingNumber}&PARM_IP={clientIpAddress}&PARM_LANG={PARM_LANG}";                
                HttpClient client = new HttpClient();                 
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync(url,null).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    
                    _berth = JsonConvert.DeserializeObject<BookingViewModel>(jsonString);
                    if (_berth.status == "OK")
                    {
                        for (int i = 0; i < _berth.booking.unitlist.Count; i++)
                        {
                            _berth.booking.unitlist[i].rowId = (i + 1);
                        }
                        _berth.paging = new Paging()
                        {
                            itemsOnPage = pageSize,
                            items = _berth.booking.unitlist.Count,
                            pageNumber = (page == null ? 1 : (int)page)
                        };
                        _berth.booking.unitlistAll = _berth.booking.unitlist ;
                        _berth.booking.unitlist = GetPage(_berth.booking.unitlist.OrderBy(x => x.rowId).ToList(), (int)(page ?? 1), pageSize);
                    }
                }                 
                return _berth;
            }catch(Exception ex)
            {
                _berth.msg = ex.Message;
                return _berth;
            }
        }
        public async Task<BookingViewModel> GetBookingByBookingEterminal(string PARM_USER, string bookingNumber,string PARM_LANG, int pageSize, int? page)
        {
            bookingNumber = (bookingNumber ?? "").Trim();
            BookingViewModel _berth = new BookingViewModel();
            if (bookingNumber == "")
            {
                _berth.msg = "Please insert booking number.";
                return _berth;
            }
            try
            {
                string clientIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                var url = $"{_applicationSetting.API_Url}/api/ETerminal/SearchByBook";
                url += $"?PARM_USER={PARM_USER}&PARM_BOOKING={bookingNumber}&PARM_IP={clientIpAddress}&PARM_LANG={PARM_LANG}";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync(url, null).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    _berth = JsonConvert.DeserializeObject<BookingViewModel>(jsonString);
                    if (_berth.status == "OK")
                    {
                        for (int i = 0; i < _berth.booking.unitlist.Count; i++)
                        {
                            _berth.booking.unitlist[i].rowId = (i + 1);
                        }
                        _berth.paging = new Paging()
                        {
                            itemsOnPage = pageSize,
                            items = _berth.booking.unitlist.Count,
                            pageNumber = (page == null ? 1 : (int)page)
                        };
                        _berth.booking.unitlistAll = _berth.booking.unitlist;
                        _berth.booking.unitlist = GetPage(_berth.booking.unitlist.OrderBy(x => x.rowId).ToList(), (int)(page ?? 1), pageSize);
                    }
                }
                return _berth;
            }
            catch (Exception ex)
            {
                _berth.msg = ex.Message;
                return _berth;
            }
        }
        public async Task<BookingViewModel> GetBookingByBookingDetailEterminal(string PARM_USER, string bookingNumber, string PARM_LANG)
        {
            bookingNumber = (bookingNumber ?? "").Trim();
            BookingViewModel _berth = new BookingViewModel();
            if (bookingNumber == "")
            {
                _berth.msg = "Please insert booking number.";
                return _berth;
            }
            try
            {
                string clientIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                var url = $"{_applicationSetting.API_Url}/api/QuickSearch/SearchByBook";
                url += $"?PARM_BOOKING={bookingNumber}&PARM_IP={clientIpAddress}&PARM_LANG={PARM_LANG}";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync(url, null).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    _berth = JsonConvert.DeserializeObject<BookingViewModel>(jsonString);


                }

                return _berth;
            }
            catch (Exception ex)
            {
                _berth.msg = ex.Message;
                return _berth;
            }
        }
        List<Unit> GetPage(IList<Unit> list, int page, int pageSize)
        {
            var pageData = list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return pageData;
        }
    }
}
