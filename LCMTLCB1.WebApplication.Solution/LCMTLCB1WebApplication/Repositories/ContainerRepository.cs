using LCMTLCB1.WebAPI.Configuration;
using LCMTLCB1WebApplication.Models;
using LCMTLCB1WebApplication.Services.DataModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LCMTLCB1WebApplication.Repositories
{
    public class ContainerRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationSetting _applicationSetting;
        public ContainerRepository(
            IHttpContextAccessor httpContextAccessor,
            ApplicationSetting applicationSetting)
        {

            _httpContextAccessor = httpContextAccessor;
            _applicationSetting = applicationSetting;
        }
        public async Task<ContainerViewModel> GetContainnerNumber(string containerNumber,string PARM_LANG)
        {
            containerNumber = (containerNumber??"").Trim();             
            ContainerViewModel _container = new ContainerViewModel();
            if (containerNumber == "")
            {
                _container.msg = "Please insert container number.";
                return _container  ;
            }
            try
            {               
                string clientIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                var url = $"{_applicationSetting.API_Url}/api/QuickSearch/SearchByContainer";
                url += $"?PARM_CONTAINER={containerNumber}&PARM_IP={clientIpAddress}&PARM_LANG={PARM_LANG}";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync(url, null).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    _container = JsonConvert.DeserializeObject<ContainerViewModel>(jsonString);
                }
                
                return _container;
            }
            catch (Exception ex)
            {
                _container.msg = ex.Message;
                return _container;
            }
        }

        public async Task<ContainerViewModel> GetContainnerNumberEterminal(string PARM_USER, string PARM_CONTAINER, string PARM_LANG)
        {
            PARM_CONTAINER = (PARM_CONTAINER ?? "").Trim();
            ContainerViewModel _container = new ContainerViewModel();
            if (PARM_CONTAINER == "")
            {
                _container.msg = "Please insert container number.";
                return _container;
            }
            try
            {
                string clientIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                var url = $"{_applicationSetting.API_Url}/api/ETerminal/SearchByContainer";
                url += $"?PARM_CONTAINER={PARM_CONTAINER}&PARM_USER={PARM_USER}&PARM_IP={clientIpAddress}&PARM_LANG={PARM_LANG}";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync(url, null).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    _container = JsonConvert.DeserializeObject<ContainerViewModel>(jsonString);
                }

                return _container;
            }
            catch (Exception ex)
            {
                _container.msg = ex.Message;
                return _container;
            }
        }
        public async Task<ContainerViewModel> GetContainnerNumberByHanderingEterminal(string PARM_USER ,string PARM_HANDLINGID,  string PARM_LANG)
        {
            PARM_HANDLINGID = (PARM_HANDLINGID ?? "").Trim();
            ContainerViewModel _container = new ContainerViewModel();
            if (PARM_HANDLINGID == "")
            {
                _container.msg = "Please insert container number.";
                return _container;
            }
            try
            {
                string clientIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                var url = $"{_applicationSetting.API_Url}/api/ETerminal/SearchByHandering";
                url += $"?PARM_HANDLINGID={PARM_HANDLINGID}&PARM_USER={PARM_USER}&PARM_IP={clientIpAddress}&PARM_LANG={PARM_LANG}";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync(url, null).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    _container = JsonConvert.DeserializeObject<ContainerViewModel>(jsonString);
                }
                return _container;
            }
            catch (Exception ex)
            {
                _container.msg = ex.Message;
                return _container;
            }
        }
    }
}
