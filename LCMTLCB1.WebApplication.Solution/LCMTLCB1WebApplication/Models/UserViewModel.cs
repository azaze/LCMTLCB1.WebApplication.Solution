using LCMTLCB1WebApplication.Services.DataModels;

namespace LCMTLCB1WebApplication.Models
{
    public class UserViewModel
    {
        public User ssoUser { get; set; }
         
        public string? refreshToken { get; set; }
        public string status { get; set; }
        public string? msg { get; set; }

    }

}
