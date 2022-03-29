using LCMTLCB1.WebAPI.Configuration;
using LCMTLCB1WebApplication.Models;
using LCMTLCB1WebApplication.Services.DataModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LCMTLCB1WebApplication.Repositories
{
    public class LoginRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationSetting _applicationSetting;
        public LoginRepository( 
            IHttpContextAccessor httpContextAccessor,
            ApplicationSetting  appplicationSetting)
        {
            
            _httpContextAccessor = httpContextAccessor;
            _applicationSetting = appplicationSetting;
        }
        public async Task<UserViewModel> Login(string PARM_USERNAME, string PARM_PASSWORD,string PARM_LANG)
        {
            UserViewModel _obj = new UserViewModel();
            try
            {               
                string clientIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                var url = $"{_applicationSetting.API_Url}/api/ETerminal/Login";
                url += $"?PARM_USERNAME={PARM_USERNAME}&PARM_PASSWORD={System.Web.HttpUtility.UrlEncode(PARM_PASSWORD)}&PARM_IP={clientIpAddress}&PARM_LANG={PARM_LANG}";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync(url, null).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    _obj = JsonConvert.DeserializeObject<UserViewModel>(jsonString);


                }

                return _obj;

            }
            catch (Exception ex)
            {
                _obj.msg = ex.Message;
                return _obj;
            }
        }




    }
}
