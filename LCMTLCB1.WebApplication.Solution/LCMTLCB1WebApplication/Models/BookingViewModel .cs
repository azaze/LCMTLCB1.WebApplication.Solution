using LCMTLCB1WebApplication.Services.DataModels;

namespace LCMTLCB1WebApplication.Models
{
    public class BookingViewModel
    {
        public Booking booking { get; set; }
        public string status { get; set; }
        public string? msg { get; set; }
        public Paging paging { get; set; }
    }

}
