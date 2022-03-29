namespace LCMTLCB1WebApplication.Services.DataModels
{
    public class Booking
    {
        public double orderid { get; set; }
        public string ordernumber { get; set; }
        public string linecode { get; set; }
        public DateTime? orderdate { get; set; }
        public string type { get; set; }
        public string remark { get; set; }
         
        public List<Unit> unitlist { get; set; }
        public List<Unit> unitlistAll { get; set; }
    }
}
