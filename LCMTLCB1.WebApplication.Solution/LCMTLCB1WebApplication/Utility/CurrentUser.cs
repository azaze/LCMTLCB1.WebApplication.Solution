using LCMTLCB1WebApplication.Services.DataModels;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using LCMTLCB1WebApplication.Models;

namespace LCMTLCB1WebApplication.Utility
{
    public class CurrentUser
    {

        public HttpContext _HttpContext;
        public CurrentUser(HttpContext HttpContext)
        {
            _HttpContext = HttpContext;
        }
        public UserViewModel User
        {
            get
            {
                try
                {
                    string str = _HttpContext.Session.GetString("User");
                    return JsonConvert.DeserializeObject<UserViewModel>(str);
                    //return System.Web.HttpContext.Current.Session["User"] as User;
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
            set
            {
                var str = JsonConvert.SerializeObject(value);
                _HttpContext.Session.SetString("User", str);
                //System.Web.HttpContext.Current.Session["User"] = value;
            }
        }
    }
}
