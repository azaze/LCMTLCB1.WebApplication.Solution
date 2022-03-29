namespace LCMTLCB1WebApplication.Services.DataModels
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool IsActive { get; set; }
        public List<UserMap> usermap { get; set; }
    }
}
