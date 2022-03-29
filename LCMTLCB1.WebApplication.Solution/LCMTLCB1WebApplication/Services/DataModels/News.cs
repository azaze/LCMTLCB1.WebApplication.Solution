namespace LCMTLCB1WebApplication.Services.DataModels
{
    public class News
    {
        public int NewsID { get; set; }
        public string Subject { get; set; }

        public string Detail { get; set; }

        public DateTime PublishDate { get; set; }

        public string Thumbnail { get; set; }

        public List<string> Images { get; set; }


    }
}
