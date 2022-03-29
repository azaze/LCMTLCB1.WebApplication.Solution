using LCMTLCB1.WebAPI.Configuration;
using LCMTLCB1WebApplication.Models;
using LCMTLCB1WebApplication.Services.DataModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LCMTLCB1WebApplication.Repositories
{
    public class BerthScheduleRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationSetting _applicationSetting;
        public BerthScheduleRepository(
            IHttpContextAccessor httpContextAccessor,
            ApplicationSetting appplicationSetting)
        {

            _httpContextAccessor = httpContextAccessor;
            _applicationSetting = appplicationSetting;
        }
        public async Task<BerthScheduleViewModel> GetBerthSchedule(string vesslName, string voyageIn, string voyageOut, string PARM_LANG, int pageSize, int? page)
        {
            vesslName = (vesslName ?? "").Trim();
            voyageIn = (voyageIn ?? "").Trim();
            voyageOut = (voyageOut ?? "").Trim();

            BerthScheduleViewModel _berth = new BerthScheduleViewModel();

            string comment = "";
            if (vesslName == "")
            {
                comment += "Vessl name,";
            }
            //if (voyageIn == "")
            //{
            //    comment += "Voyage in,";
            //}
            //if (voyageOut == "")
            //{
            //    comment += "Voyage out,";
            //}

            if (comment != "")
            {
                _berth.msg = "Please insert :" + comment.Substring(0, comment.Length - 1);
                return _berth;
            }
            try
            {

                string clientIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                var url = $"{_applicationSetting.API_Url}/api/BerthSchedule/GetVesselSchedule";
                url += $"?PARM_VESEL_CODE={vesslName}&PARM_VOY_IN={voyageIn}&PARM_VESEL_CODE={voyageOut}&PARM_IP={clientIpAddress}&PARM_LANG={PARM_LANG}";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync(url, null).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    _berth = JsonConvert.DeserializeObject<BerthScheduleViewModel>(jsonString);
                    if (_berth.status == "OK")
                    {
                        for (int i = 0; i < _berth.vesellist.Count; i++)
                        {
                            _berth.vesellist[i].rowId = (i + 1);
                        }
                        _berth.paging = new Paging()
                        {
                            itemsOnPage = pageSize,
                            items = _berth.vesellist.Count,
                            pageNumber = (page == null ? 1 : (int)page)
                        };
                        _berth.vesellist = GetPage(_berth.vesellist.OrderBy(x => x.rowId).ToList(), (int)(page ?? 1), pageSize);
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
        public async Task<BerthScheduleViewModel> GetBerthScheduleEterminal(string PARM_USER, string PARM_LANG,int pageSize,int? page)
        {
            PARM_USER = (PARM_USER ?? "").Trim();
            PARM_LANG = (PARM_LANG ?? "").Trim();


            BerthScheduleViewModel _berth = new BerthScheduleViewModel();

            string comment = "";
            if (PARM_USER == "" || PARM_USER == "")
            {
                comment += "Wrong parameter";
            }

            if (comment != "")
            {
                _berth.msg = comment;
                return _berth;
            }
            try
            {

                string clientIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                var url = $"{_applicationSetting.API_Url}/api/ETerminal/GetVesselBerthing";
                url += $"?PARM_USER={PARM_USER}&PARM_LANG={PARM_LANG}&PARM_IP=" + clientIpAddress;
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync(url, null).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    _berth = JsonConvert.DeserializeObject<BerthScheduleViewModel>(jsonString);
                    for (int i = 0; i < _berth.vesellist.Count; i++)
                    {
                        _berth.vesellist[i].rowId = (i + 1);
                    }
                    _berth.paging = new Paging()
                    {
                        itemsOnPage = pageSize,
                        items = _berth.vesellist.Count,
                        pageNumber = (page == null ? 1 : (int)page)
                    };
                    _berth.vesellist = GetPage(_berth.vesellist.OrderBy(x => x.rowId).ToList(), (int)(page ?? 1), pageSize);
                }

                return _berth;

            }
            catch (Exception ex)
            {
                _berth.msg = ex.Message;
                return _berth;
            }
        }
        public async Task<BerthScheduleViewModel> GetBerthScheduleEterminalDetail(string PARM_VESSELID, string PARM_USER, string PARM_LANG)
        {
            PARM_VESSELID = (PARM_VESSELID ?? "").Trim();
            PARM_USER = (PARM_USER ?? "").Trim();
            PARM_LANG = (PARM_LANG ?? "").Trim();

            BerthScheduleViewModel _berth = new BerthScheduleViewModel();

            string comment = "";
            if (PARM_VESSELID == "" || PARM_USER == "" || PARM_LANG == "")
            {
                comment += "Wrong parameter";
            }

            if (comment != "")
            {
                _berth.msg = comment;
                return _berth;
            }
            try
            {

                string clientIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                var url = $"{_applicationSetting.API_Url}/api/ETerminal/GetVesselBerthingDetail";
                url += $"?PARM_VESSELID={PARM_VESSELID}&PARM_USER={PARM_USER}&PARM_LANG={PARM_LANG}&PARM_IP=" + clientIpAddress;
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync(url, null).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    _berth = JsonConvert.DeserializeObject<BerthScheduleViewModel>(jsonString);
                     
                  
                }

                return _berth;

            }
            catch (Exception ex)
            {
                _berth.msg = ex.Message;
                return _berth;
            }
        }
        public async Task<BerthScheduleViewModel> GetVessel()
        {

            BerthScheduleViewModel _booking = new BerthScheduleViewModel();
            try
            {
                string clientIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                var url = $"{_applicationSetting.API_Url}/api/BerthSchedule/GetVesselList?PARM_IP=" + clientIpAddress;
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync(url, null).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    _booking = JsonConvert.DeserializeObject<BerthScheduleViewModel>(jsonString);
                }

                return _booking;

            }
            catch (Exception ex)
            {
                _booking.msg = ex.Message;
                return _booking;
            }
        }
        List<Vesellist> GetPage(IList<Vesellist> list, int page, int pageSize)
        {
            var pageData = list.Skip((page-1) * pageSize).Take(pageSize).ToList();
            return pageData;
        }

    }
}
