using LCMTLCB1WebApplication.Services.DataModels;

namespace LCMTLCB1WebApplication.Models
{
    public class NewsListViewModel
    {
        public List<News> NewsList { get; set; }

        public Paging paging { get; set; }
    }
}
