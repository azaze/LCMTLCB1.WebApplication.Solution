using LCMTLCB1WebApplication.Services.DataModels;

namespace LCMTLCB1WebApplication.Models
{
    public class BerthScheduleViewModel
    {
        public List<Vesellist> vesellist { get; set; }
        public string status { get; set; }
        public string? msg { get; set; }
        public Vesellist vesel { get; set; }
        public Paging paging { get; set; }
    }

}
